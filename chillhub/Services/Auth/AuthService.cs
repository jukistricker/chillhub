using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace chillhub.Services.Auth;

using chillhub.Mapping;
using chillhub.Models.Dtos.Requests.Search;
using Entities.Auth;
using Models.Dtos.Requests;
using Models.Dtos.Responses.Shared;
using Repositories.Interfaces;
using Services.Interfaces.Auth;
using Utils;


public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepo;
    private readonly ISessionRepository _sessionRepo;
    private readonly TokenUtil _tokenUtil;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly TimeSpan _sessionTtl = TimeSpan.FromHours(2);

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
        if (await _authRepo.UsernameExistsAsync(dto.Username))
            return ResponseDto.Create(ResponseCatalog.Conflict, "auth.username_exists");

        Guid? defaultRoleId = await _authRepo.GetDefaultRoleIdAsync();
        if(defaultRoleId == null)
        {
            ResponseDto.Create(ResponseCatalog.NotFound, "auth.user_role_not_exist");
        }

        LanguageEnum lang = (dto.InitLang == LanguageEnum.En) ? LanguageEnum.En : LanguageEnum.Vi;

        Guid userId = Guid.CreateVersion7();
    

        User user = new User
        {
            Id = userId,
            Username = dto.Username,
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
        UserFullInfo fullInfo = await _authRepo.GetFullUserInfoAsync(dto.Username);

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

        var session = new UserSession
        {
            UserId = fullInfo.User.Id,
            Username = fullInfo.User.Username,
            RoleIds = fullInfo.RoleIds,
            Permissions = fullInfo.Permissions,
            Lang = fullInfo.User.Lang,
            IssuedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.Add(_sessionTtl)
        };

        var (token, jti) = await _tokenUtil.GenerateToken(fullInfo.User.Id, fullInfo.User.Username, fullInfo.User.Lang);

        await _sessionRepo.StoreAsync(jti, session, _sessionTtl);

        return ResponseDto.Create(ResponseCatalog.Success, "auth.login_success", token);
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
        var pagedUsers = await _authRepo.GetUsersAsync(req);
        CursorResponse<UserResponse> response=  UserMapping.ToCursorResponse(pagedUsers);
        return ResponseDto.Create(ResponseCatalog.Success, "auth.users_list", response);
    }

    public async Task<IResult> GetPermissionAsync()
    {
        var context = _httpContextAccessor.HttpContext;

        if (context == null)
        {
            return ResponseDto.Create(ResponseCatalog.Internal, "system.http_context_not_found");
        }

        string? jti = HttpContextUtil.GetJti(context);
        UserSession? session = await _sessionRepo.GetAsync(jti);
        if (session == null)
        {
            return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.session_not_found");
        }

        return ResponseDto.Create(ResponseCatalog.Success, "auth.session_info", session.Permissions);
    }
}