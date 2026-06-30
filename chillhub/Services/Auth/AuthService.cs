using chillhub.Entities.Auth;
using chillhub.Mapping;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Requests.Search;
using chillhub.Models.Dtos.Responses;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Models.Enums;
using chillhub.Repositories.Interfaces;
using chillhub.Services.Interfaces.Auth;
using chillhub.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace chillhub.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepo;
    private readonly ISessionRepository _sessionRepo;
    private readonly TokenUtil _tokenUtil;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ICacheService _cacheService;
    private readonly string _defaultRoleKey;
    private readonly TimeSpan _sessionTtl = TimeSpan.FromMinutes(30);

    public AuthService(
         IAuthRepository authRepo,
        ISessionRepository sessionRepo,
        TokenUtil tokenUtil,
         IPasswordHasher<User> passwordHasher,
         IHttpContextAccessor httpContextAccessor,
         ICacheService cacheService)
    {
        _authRepo = authRepo;
        _sessionRepo = sessionRepo;
        _tokenUtil = tokenUtil;
        _passwordHasher = passwordHasher;
        _httpContextAccessor = httpContextAccessor;
        _cacheService = cacheService;
        _defaultRoleKey ="auth:default_role_id";
    }

    public async Task<IResult> SignUpAsync(SignUpDto dto)
    {
        if (await _authRepo.UsernameExistsAsync(dto.Username))
            return ResponseDto.Create(ResponseCatalog.BadRequest, "auth.username_existed");
        if (await _authRepo.EmailExistsAsync(dto.Email))
            return ResponseDto.Create(ResponseCatalog.BadRequest, "auth.email_existed");

        Guid? defaultRoleId = await _cacheService.GetAsync<Guid?>(_defaultRoleKey);

        if (defaultRoleId == null)
        {
            defaultRoleId = await _authRepo.GetDefaultRoleIdAsync();
            
            await _cacheService.SetAsync("auth:default_role_id", defaultRoleId, TimeSpan.FromDays(1));
        }

        LanguageEnum lang = (dto.InitLang == LanguageEnum.En) ? LanguageEnum.En : LanguageEnum.Vi;

        Guid userId = Guid.CreateVersion7();

        User user = new User
        {
            Id = userId,
            Username = dto.Username,
            FullName = GenerateDefaultName(),
            Email = dto.Email,
            Lang = lang,
            CreatedBy = userId,
            UpdatedBy = userId,
            UserRoles = new List<UserRole>
            {
                new UserRole { UserId = userId, RoleId = defaultRoleId.Value }
            }
        };

        user.Password = _passwordHasher.HashPassword(user, dto.Password);

        await _authRepo.AddAsync(user);
        await _authRepo.SaveChangesAsync();

        return ResponseDto.Create(ResponseCatalog.Created, "auth.signup_success");
    }

    public async Task<IResult> SignInAsync(SignInDto dto)
    {
        UserFullInfo fullInfo = await _authRepo.GetFullUserInfoAsync(dto.Email);

        if (fullInfo == null)
            return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.invalid_credential");

        PasswordVerificationResult verificationResult = _passwordHasher.VerifyHashedPassword(
            fullInfo.User,
            fullInfo.User.Password,
            dto.Password
        );

        if (verificationResult == PasswordVerificationResult.Failed)
        {
            return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.invalid_credential");
        }

        UserSession session = await CreateUserSession(fullInfo);

        var (token, jti, refreshToken) = await _tokenUtil.GenerateToken(fullInfo.User.Id, fullInfo.User.Username,fullInfo.User.Email, fullInfo.User.Lang);

        await _sessionRepo.StoreAsync(jti, session, _sessionTtl);

        UserResponse responseData = UserMapping.ToResponse(fullInfo.User);

        return ResponseDto.Create(ResponseCatalog.Success, "auth.login_success", new { Token = token, User = responseData, RefreshToken= refreshToken  });
    }

    public async Task<IResult> SignOutAsync()
    {
        var context = _httpContextAccessor.HttpContext;

        if (context == null)
        {
            return ResponseDto.Create(ResponseCatalog.Internal, "system.http_context_not_found");
        }

        string? jti = HttpContextUtil.GetJti(context);
        await _sessionRepo.DeleteAsync(jti);
        return Results.NoContent();
    }

    public async Task<IResult> GetUsersAsync(AuthFilterRequest req)
    {
        CursorResponse<User> pagedUsers = await _authRepo.GetUsersAsync(req);
        CursorResponse<UserResponse> response = UserMapping.ToCursorResponse(pagedUsers);
        return ResponseDto.Create(ResponseCatalog.Success, "auth.users_list", response);
    }

    public async Task<IResult> GetPersonalInfo()
    {
        UserSession? session = HttpContextUtil.GetUserSession(_httpContextAccessor.HttpContext);
        if (session == null)
        {
            return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.session_not_found");
        }

        UserFullInfo? userFullInfo = await _authRepo.GetFullUserInfoAsync(session.Email);
        if (userFullInfo == null)
        {
            return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.user_not_found");
        }

        UserResponse responseData = UserMapping.ToResponse(userFullInfo.User);

        return ResponseDto.Create(ResponseCatalog.Success, "auth.user_info", responseData);
    }

    public async Task<IResult> GetPermissionAsync()
    {

        UserSession? session = HttpContextUtil.GetUserSession(_httpContextAccessor.HttpContext);
        if (session == null)
        {
            return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.session_not_found");
        }

        return ResponseDto.Create(ResponseCatalog.Success, "auth.session_info", session.Permissions);
    }

    public async Task<IResult> RefreshTokenAsync(RefreshTokenRequest request)
{
    var oldJwtToken = request.AccessToken;

    // 1. Xác thực và giải mã JWT cũ (Tắt check Expire, bắt buộc check chữ ký)
    var principal = _tokenUtil.GetPrincipalFromExpiredToken(oldJwtToken);
    if (principal == null)
    {
        return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.invalid_signature");
    }

    // 2. Lấy JTI và các claims từ Payload của JWT
    var oldJti = principal.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
    var refreshTokenFromPayload = principal.FindFirst("refresh_token")?.Value;
    var email = principal?.FindFirstValue("email");
    
    if (email == null)
    {
        return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.email_not_found");
    }

    if (string.IsNullOrEmpty(oldJti) || string.IsNullOrEmpty(refreshTokenFromPayload))
    {
        return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.invalid_payload");
    }

    if (request.RefreshToken != refreshTokenFromPayload)
    {
        return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.refresh_token_mismatch");
    }
    UserSession? oldSession = await _sessionRepo.GetAsync(oldJti);

    UserSession newSession;
    Guid userId;
    string username;
    LanguageEnum lang;

    if (oldSession != null)
    {
        // có cache: Tái sử dụng toàn bộ thông tin từ Redis
        userId = oldSession.UserId;
        username = oldSession.Username;
        lang = oldSession.Lang;

        newSession = new UserSession
        {
            UserId = oldSession.UserId,
            Username = oldSession.Username,
            Email = oldSession.Email,
            RoleIds = oldSession.RoleIds,
            Permissions = oldSession.Permissions,
            Lang = oldSession.Lang,
            IssuedAt = DateTimeOffset.UtcNow,
            ExpiresAt = DateTimeOffset.UtcNow.Add(_sessionTtl)
        };
    }
    else
    {
        // miss cache 
        UserFullInfo fullInfo = await _authRepo.GetFullUserInfoAsync(email);
        if (fullInfo == null) return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.user_not_found");

        userId = fullInfo.User.Id;
        username = fullInfo.User.Username;
        lang = fullInfo.User.Lang;

        newSession = await CreateUserSession(fullInfo);
    }

    // 4. Xóa session cũ (vì đã clone xong dữ liệu sang newSession)
    await _sessionRepo.DeleteAsync(oldJti);
    var (newJwt, newJti, refreshToken) = await _tokenUtil.GenerateToken(userId, username, email, lang);

    await _sessionRepo.StoreAsync(newJti, newSession, _sessionTtl);

    return ResponseDto.Create(ResponseCatalog.Success, "auth.refresh_success", new
    {
        Token = newJwt,
        RefreshToken = refreshToken
    });
}
    public async Task<UserSession> CreateUserSession(UserFullInfo fullInfo)
    {
        return new UserSession
        {
            UserId = fullInfo.User.Id,
            Username = fullInfo.User.Username,
            Email = fullInfo.User.Email,
            RoleIds = fullInfo.RoleIds,
            Permissions = fullInfo.Permissions,
            Lang = fullInfo.User.Lang,
            IssuedAt = DateTimeOffset.UtcNow,
            ExpiresAt = DateTimeOffset.UtcNow.Add(_sessionTtl)
        };
    }

    public async Task<IResult> UpdateProfileAsync(UpdateProfileRequest dto)
    {
        var context = _httpContextAccessor.HttpContext;
        if (context == null)
        {
            return ResponseDto.Create(ResponseCatalog.Internal, "system.http_context_not_found");
        }

        UserSession? session = HttpContextUtil.GetUserSession(context);
        if (session == null)
        {
            return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.session_not_found");
        }

        User? user = await _authRepo.GetByIdAsync(session.UserId);
        if (user == null)
        {
            return ResponseDto.Create(ResponseCatalog.NotFound, "auth.user_not_found");
        }

        if (dto.AvatarUrl != null)
        {
            user.AvatarUrl = dto.AvatarUrl;
        }
        user.FullName = dto.FullName;
        user.Lang = dto.Lang;
        user.UpdatedBy = session.UserId;

        // Lưu thay đổi vào Database
        await _authRepo.SaveChangesAsync();

        string? jti = HttpContextUtil.GetJti(context);
        if (!string.IsNullOrEmpty(jti))
        {
            session.FullName=dto.FullName;
            session.Lang = dto.Lang;
            await _sessionRepo.StoreAsync(jti, session, _sessionTtl);
        }

        UserResponse responseData = UserMapping.ToResponse(user);
        return ResponseDto.Create(ResponseCatalog.Success, "auth.profile_updated_success", responseData);
    }

    public async Task<IResult> ChangePasswordAsync(ChangePasswordRequest dto)
    {
        var context = _httpContextAccessor.HttpContext;
        if (context == null)
        {
            return ResponseDto.Create(ResponseCatalog.Internal, "system.http_context_not_found");
        }

        UserSession? session = HttpContextUtil.GetUserSession(context);
        if (session == null)
        {
            return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.session_not_found");
        }

        User? user = await _authRepo.GetByIdAsync(session.UserId);
        if (user == null)
        {
            return ResponseDto.Create(ResponseCatalog.NotFound, "auth.user_not_found");
        }

        // 1. Kiểm tra mật khẩu hiện tại
        PasswordVerificationResult verificationResult = _passwordHasher.VerifyHashedPassword(
            user,
            user.Password,
            dto.CurrentPassword
        );

        if (verificationResult == PasswordVerificationResult.Failed)
        {
            return ResponseDto.Create(ResponseCatalog.BadRequest, "auth.invalid_current_password");
        }

        // 2. Mã hóa và cập nhật mật khẩu mới
        user.Password = _passwordHasher.HashPassword(user, dto.NewPassword);
        user.UpdatedBy = session.UserId;

        await _authRepo.SaveChangesAsync();

        // 3. (Tùy chọn) Nếu muốn bắt user đăng xuất ở tất cả thiết bị khi đổi mật khẩu, 
        // bạn có thể gọi: await _sessionRepo.DeleteAsync(HttpContextUtil.GetJti(context));

        return ResponseDto.Create(ResponseCatalog.Success, "auth.change_password_success");
    }

    private static string GenerateDefaultName()
    {
        int randomNumber = Random.Shared.Next(0, 100000000);

        return $"User {randomNumber:D8}";
    }
}