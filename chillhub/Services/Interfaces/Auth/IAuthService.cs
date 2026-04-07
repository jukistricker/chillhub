using chillhub.Models.Dtos.Requests;

namespace chillhub.Services.Interfaces.Auth;

public interface IAuthService
{
    Task<IResult> SignUpAsync(SignUpDto dto);
    Task<IResult> SignInAsync(SignInDto dto);
    Task<IResult> SignOutAsync(string jti);
    Task<IResult> GetUsersAsync(AuthFilterRequest req);
    Task<IResult> GetPermissionAsync(string jti);
}