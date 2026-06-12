using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace chillhub.Services.Auth;

using chillhub.Mapping;
using chillhub.Models.Dtos.Requests.Search;
using Entities.Auth;
using Microsoft.EntityFrameworkCore;
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
        if(defaultRoleId == null)
        {
            ResponseDto.Create(ResponseCatalog.NotFound, "auth.user_role_not_exist");
        }

        LanguageEnum lang = (dto.InitLang == LanguageEnum.En) ? LanguageEnum.En : LanguageEnum.Vi;

        Guid userId = Guid.CreateVersion7();
    

        User user = new User
        {
            Id = userId,
            Username = dto.Email,
            FullName = dto.Email,
            Email= dto.Email,
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

        var session = new UserSession
        {
            UserId = fullInfo.User.Id,
            Username = fullInfo.User.Username,
            Email= fullInfo.User.Email,
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

    public async Task<IResult> GetPersonalInfo()
    {
        UserSession? session = HttpContextUtil.GetUserSession(_httpContextAccessor.HttpContext);
        if (session == null)
        {
            return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.session_not_found");
        }
        UserFullInfo? user =await _authRepo.GetFullUserInfoAsync(session.Email);
        if (user == null)
        {
            return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.user_not_found");
        }
        return ResponseDto.Create(ResponseCatalog.Success, "auth.user_info", user);
    }

    public async Task<IResult> GetPermissionAsync()
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

        return ResponseDto.Create(ResponseCatalog.Success, "auth.session_info", session.Permissions);
    }
}