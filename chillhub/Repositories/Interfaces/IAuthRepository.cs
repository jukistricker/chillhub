using chillhub.Entities.Auth;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses;

namespace chillhub.Repositories.Interfaces;

public interface IAuthRepository
{
    Task<bool> UsernameExistsAsync(string username);
    Task<User?> GetByUsernameAsync(string username);

    Task<Guid?> GetDefaultRoleIdAsync();
    Task<List<Guid>> GetExistingRoleIdsAsync(HashSet<Guid> roleIds);

    Task<HashSet<Guid>> GetUserRoleIdsAsync(Guid userId);
    Task<HashSet<string>> GetUserPermissionCodesAsync(Guid userId);
    Task<UserFullInfo> GetFullUserInfoAsync(string username);
    Task AddUserAsync(User user);
    Task AddUserRolesAsync(IEnumerable<UserRole> roles);
    Task<(List<UserResponse> Items, string? NextCursor)> GetUsersAsync(AuthFilterRequest req);

    Task SaveChangesAsync();
}