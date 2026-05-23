using chillhub.Entities.Auth;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;

namespace chillhub.Repositories.Interfaces;

public interface IRoleRepository : IRepository<Role>
{
    Task<CursorResponse<Role>> GetRolesAsync(RoleFilterRequest request);
}
