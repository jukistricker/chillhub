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

    private readonly TimeSpan _sessionTtl = TimeSpan.FromMinutes(15);

    public AuthService(
         IAuthRepository authRepo,
        ISessionRepository sessionRepo,
        TokenUtil tokenUtil,
         IPasswordHasher<User> passwordHasher,
         IHttpContextAccessor httpContextAccessor
        )
    {
        _authRepo = authRepo;
        _sessionRepo = sessionRepo;
        _tokenUtil = tokenUtil;
        _passwordHasher = passwordHasher;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IResult> SignUpAsync(SignUpDto dto)
    {
        if (await _authRepo.EmailExistsAsync(dto.Email))
            return ResponseDto.Create(ResponseCatalog.Conflict, "auth.email_existed");

        Guid? defaultRoleId = await _authRepo.GetDefaultRoleIdAsync();
        if (defaultRoleId == null)
        {
            return ResponseDto.Create(ResponseCatalog.NotFound, "auth.user_role_not_exist");
        }

        LanguageEnum lang = (dto.InitLang == LanguageEnum.En) ? LanguageEnum.En : LanguageEnum.Vi;

        Guid userId = Guid.CreateVersion7();

        User user = new User
        {
            Id = userId,
            Username = dto.Email,
            FullName = dto.Email,
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

        // 1. Xác thực và giải mã JWT cũ (Tắt check Expire, nhưng bắt buộc check Chữ ký số)
        var principal = _tokenUtil.GetPrincipalFromExpiredToken(oldJwtToken);
        if (principal == null)
        {
            return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.invalid_signature");
        }

        // 3. Lấy JTI và Refresh Token từ Payload của JWT
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

        // 4. KIỂM TRA BẢO MẬT: Đối chiếu Refresh Token Client gửi với Refresh Token trong Payload
        // Nếu kẻ gian ăn cắp được JWT cũ nhưng không biết Refresh Token thực sự, chúng sẽ bị chặn ở đây.
        if (request.RefreshToken != refreshTokenFromPayload)
        {
            return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.refresh_token_mismatch");
        }

        // 5. Xóa session cũ theo jti (trường hợp session chưa expire)
        await _sessionRepo.DeleteAsync(oldJti);

        // Lấy thông tin user mới nhất từ DB
        UserFullInfo fullInfo = await _authRepo.GetFullUserInfoAsync(email);
        if (fullInfo == null) return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.user_not_found");


        var (newJwt, newJti, refreshToken) = await _tokenUtil.GenerateToken(fullInfo.User.Id, 
            fullInfo.User.Username,
            fullInfo.User.Email, 
            fullInfo.User.Lang
            );

        var newSession = await CreateUserSession(fullInfo);

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
}