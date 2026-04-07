using chillhub.Entities.Auth;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Requests.Search;
using chillhub.Models.Dtos.Responses;

namespace chillhub.Repositories.Interfaces;

public interface IRbacRepository
{
    // Queries
    Task<List<PermissionGroup>> GetAllGroupsAsync();
    // Task<PermissionGroupDetailDto?> GetGroupPermissionDetailAsync(Guid groupId);
    Task<bool> CheckGroupCodeExistsAsync(string code, Guid? excludeId = null);
    Task<PermissionGroup> SavePermissionGroupAsync(PermissionGroup entity, bool isUpdate);
    Task<(List<PermissionGroupResponse> Items, string? NextCursor)> GetPermissionGroupsAsync(PermissionGroupFilterRequest req);
    // Commands
    Task Update<T>(T entity) where T : class;
    
    void Add<T>(T entity) where T : class;
    Task AddAsync<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    Task UpdateRolePermissionsAsync(Guid roleId, List<Guid> permissionIds);
    Task<bool> SaveChangesAsync();
    void Remove<T>(T entity) where T : class;
    Task<Role> SaveRoleAsync(Role entity, bool isUpdate);
    Task<(List<Role> Items, string? NextCursor)> GetRolesAsync(RoleFilterRequest request);
    Task<List<string>> ValidPermissionCodes(List<string> codes);
    Task<List<Guid>> ValidPermissionGroups(List<Guid> groupIds);
    Task<List<Guid>> ValidRoles(List<Guid> roleIds);
    Task<bool> SavePermissionBatchAsync(List<Permission> permissions, List<RolePermission> rolePermissions);
    Task<List<Permission>> GetPermissionsByIds(List<Guid> ids);
    Task<bool> UpsertPermissionsBatchAsync(List<Guid> idsToUpdate, List<Permission> permissions, List<RolePermission> rolePermissions);
    Task<(List<PermissionResponse> Items, string? NextCursor)> GetPermissionsAsync(PermissionFilterRequest request);
    Task<List<UserRole>> GetUserRolesAsync(Guid userId);
}