using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Requests.Search;

namespace chillhub.Services.Interfaces.Auth;

public interface IAuthService
{
    Task<IResult> SignUpAsync(SignUpDto dto);
    Task<IResult> SignInAsync(SignInDto dto);
    Task<IResult> SignOutAsync();
    Task<IResult> GetUsersAsync(AuthFilterRequest req);
    Task<IResult> GetPermissionAsync();
    Task<IResult> GetPersonalInfo();
    Task<IResult> RefreshTokenAsync(RefreshTokenRequest request);
    Task<IResult> UpdateProfileAsync(UpdateProfileRequest dto);
    Task<IResult> ChangePasswordAsync(ChangePasswordRequest dto);
}