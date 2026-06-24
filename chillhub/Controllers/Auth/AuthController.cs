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
[Authorize]
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
        return await _authService.SignOutAsync();
    }
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<IResult> GetAll([FromQuery] AuthFilterRequest req)
    {
        return await _authService.GetUsersAsync(req);
        
    }

    [HttpGet("session")]
    [RequiredPermission("auth.view_session")]
    public async Task<IResult> GetSession()
    {
        return await _authService.GetPermissionAsync();
    }

    [HttpGet("info")]
    [RequiredPermission("auth.view_session")]
    public async Task<IResult> GetPersonalInfo()
    {
        return await _authService.GetPersonalInfo();
    }

    [HttpPost("refresh-token")]
    [AllowAnonymous]
    public async Task<IResult> RefreshTokenAsync(RefreshTokenRequest request)
    {
        return await _authService.RefreshTokenAsync(request);
    }

    [HttpPut("profile")]
    public async Task<IResult> UpdateProfile(UpdateProfileRequest request)
    {
        return await _authService.UpdateProfileAsync(request);
    }

    [HttpPut("password")]
    public async Task<IResult> ChangePassword(ChangePasswordRequest request)
    {
        return await _authService.ChangePasswordAsync(request);
    }
}