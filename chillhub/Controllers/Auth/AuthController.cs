using chillhub.Attributes;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Services.Interfaces.Auth;
using chillhub.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chillhub.Controllers.Auth;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("signup")]
    [AllowAnonymous]
    public async Task<IResult> SignUp([FromBody] SignUpDto dto)
    {
        return await _authService.SignUpAsync(dto);
    }

    [HttpGet("test")]
    [AllowAnonymous]
    public async Task<IResult> test()
    {
        return ResponseDto.Create(ResponseCatalog.Success, "auth.test_success");
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IResult> Login([FromBody] SignInDto dto)
    {
        return await _authService.SignInAsync(dto);
    }

    [HttpPost("logout")]
    [RequiredPermission("auth.logout")]
    public async Task<IResult> LogOut()
    {
        string? jti = HttpContext.GetJti();
        if (jti == null)
        {
            return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.jti_not_found");
        }
        return await _authService.SignOutAsync(jti);
    }
    
    [HttpGet]
    [RequiredPermission("user.view_users")]
    public async Task<IResult> GetAll([FromQuery] AuthFilterRequest req)
    {
        return await _authService.GetUsersAsync(req);
        
    }

    [HttpGet("session")]
    [RequiredPermission("auth.view_session")]
    public async Task<IResult> GetSession()
    {
        string? jti = HttpContext.GetJti();
        if (jti == null)
        {
            return ResponseDto.Create(ResponseCatalog.Unauthorized, "auth.jti_not_found");
        }
        return await _authService.GetPermissionAsync(jti);
    }
}