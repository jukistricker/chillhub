using chillhub.Entities.Auth;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;

namespace chillhub.Repositories.Interfaces;

public interface IPermissionGroupRepository: IRepository<PermissionGroup>
{
    Task<CursorResponse<PermissionGroup>> GetPermissionGroupsAsync(PermissionGroupFilterRequest req);
}
