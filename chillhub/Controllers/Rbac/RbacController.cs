using System.Runtime.CompilerServices;
using chillhub.Attributes;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Requests.Search;
using chillhub.Services.Interfaces.Rbac;
using Microsoft.AspNetCore.Mvc;

namespace chillhub.Controllers.Rbac;

[ApiController]
[Route("rbac")]
public class RbacController:ControllerBase
{
    private readonly IRbacService _rbacService;

    public RbacController(IRbacService rbacService)
    {
        _rbacService = rbacService;
    }

    [HttpPost("permission-group")]  
    [RequiredPermission("rbac.save_permission_group")]
    public async Task<IResult> CreatePermissionGroup([FromBody] PermissionGroupSaveRequest request)
    {
        return await _rbacService.CreatePermissionGroupAsync(request);
    }
    
    [HttpPut("permission-group")]  
    [RequiredPermission("rbac.save_permission_group")]
    public async Task<IResult> UpdatePermissionGroup([FromBody] PermissionGroupSaveRequest request)
    {
        return await _rbacService.UpdatePermissionGroupAsync(request);
    }
    
    [HttpGet("permission-groups")]
    [RequiredPermission("rbac.search_permission_groups")]
    public async Task<IResult> SearchPermissionGroups([FromQuery] PermissionGroupFilterRequest request)
    {        
        return await _rbacService.SearchPermissionGroupsAsync(request);
    }
    
    [HttpPost("role")]  
    [RequiredPermission("rbac.save_role")]
    public async Task<IResult> CreateRole([FromBody] RoleSaveRequest request)
    {
        return await _rbacService.CreateRoleAsync(request);
    }
    
    [HttpPut("role")]  
    [RequiredPermission("rbac.save_role")]
    public async Task<IResult> UpdateRole([FromBody] RoleSaveRequest request)
    {
        return await _rbacService.UpdateRoleAsync(request);
    }
    
    [HttpGet("roles")]
    [RequiredPermission("rbac.search_roles")]
    public async Task<IResult> SearchRoles([FromQuery] RoleFilterRequest request)
    {        
        return await _rbacService.SearchRolesAsync(request);
    }
    
    [HttpPost("permission")]  
    [RequiredPermission("rbac.save_permission")]
    public async Task<IResult> CreatePermission([FromBody] List<PermissionSaveRequest> request)
    {
        return await _rbacService.CreatePermissionAsync(request);
    }
    
    [HttpPut("permission")]  
    [RequiredPermission("rbac.save_permission")]
    public async Task<IResult> UpdatePermission([FromBody] List<PermissionSaveRequest> request)
    {
        return await _rbacService.UpdatePermissionAsync(request);
    }
    
    [HttpGet("permissions")]
    [RequiredPermission("rbac.search_permissions")]
    public async Task<IResult> SearchPermissions([FromQuery] PermissionFilterRequest request)
    {        
        return await _rbacService.SearchPermissionsAsync(request);
    }
    
    [HttpPut("assign-role")]
    [RequiredPermission("rbac.assign_role")]
    public async Task<IResult> AssignRole([FromBody] UserRoleAssignRequest request)
    {        return await _rbacService.AssignRoleAsync(request);
    }
}