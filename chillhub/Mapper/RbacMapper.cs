using System.Linq.Expressions;
using chillhub.Entities.Auth;
using chillhub.Models.Dtos.Responses;

namespace chillhub.Mapper;

public static class RbacMapper
{
    // Mapper cho Permission
    public static Expression<Func<Permission, PermissionResponse>> ToPermissionResponse => p => new PermissionResponse
    {
        Id = p.Id,
        Code = p.Code,
        Name = p.Name,
        PermissionGroupId = p.PermissionGroupId,
        
        // Truy cập qua Navigation Property đã thêm ở trên
        PermissionGroupName = p.PermissionGroup != null ? p.PermissionGroup.Name : string.Empty,
        
        // Lấy Role đầu tiên từ bảng trung gian
        RoleId = p.RolePermissions.Select(rp => rp.RoleId).FirstOrDefault(),
        RoleName = p.RolePermissions.Select(rp => rp.Role.Name).FirstOrDefault() ?? string.Empty,

        CreatedAt = p.CreatedAt,
        CreatedBy = p.CreatedBy,
        UpdatedAt = p.UpdatedAt,
        UpdatedBy = p.UpdatedBy
    };

    // Mapper cho PermissionGroup
    public static Expression<Func<PermissionGroup, PermissionGroupResponse>> ToGroupResponse => g => new PermissionGroupResponse
    {
        Id = g.Id,
        Name = g.Name,
        Code = g.Code,
        SortOrder = g.SortOrder,
        
        CreatedAt = g.CreatedAt,
        CreatedBy = g.CreatedBy,
        UpdatedAt = g.UpdatedAt,
        UpdatedBy = g.UpdatedBy
    };
}