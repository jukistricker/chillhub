using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Requests.Search;

namespace chillhub.Services.Interfaces.Rbac;

public interface IRbacService
{
    Task<IResult> CreatePermissionGroupAsync(PermissionGroupSaveRequest request);
    Task<IResult> UpdatePermissionGroupAsync(PermissionGroupSaveRequest request);
    Task<IResult> SearchPermissionGroupsAsync(PermissionGroupFilterRequest request);
    Task<IResult> CreateRoleAsync(RoleSaveRequest request);
    Task<IResult> UpdateRoleAsync(RoleSaveRequest request);
    Task<IResult> SearchRolesAsync(RoleFilterRequest request);
    Task<IResult> CreatePermissionAsync(List<PermissionSaveRequest> request);
    Task<IResult> UpdatePermissionAsync(List<PermissionSaveRequest> request);
    Task<IResult> SearchPermissionsAsync(PermissionFilterRequest request);
    Task<IResult> AssignRoleAsync(UserRoleAssignRequest request);
}