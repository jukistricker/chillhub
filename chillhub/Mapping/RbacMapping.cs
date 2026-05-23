using System.Linq.Expressions;
using chillhub.Entities.Auth;
using chillhub.Models.Dtos.Responses;
using chillhub.Models.Dtos.Responses.Search;

namespace chillhub.Mapping;

public static class RbacMapping
{
    public static PermissionResponse ToPermissionResponse(Permission permission)
    {
        return new PermissionResponse
        {
            Id = permission.Id,
            Code = permission.Code,
            Name = permission.Name,
            PermissionGroupId = permission.PermissionGroupId,

            PermissionGroupName = permission.PermissionGroup != null ? permission.PermissionGroup.Name : string.Empty,

            RoleId = permission.RolePermissions.Select(rp => rp.RoleId).FirstOrDefault(),
            RoleName = permission.RolePermissions.Select(rp => rp.Role.Name).FirstOrDefault() ?? string.Empty,

            CreatedAt = permission.CreatedAt,
            CreatedBy = permission.CreatedBy,
            UpdatedAt = permission.UpdatedAt,
            UpdatedBy = permission.UpdatedBy
        };
    }

    public static CursorResponse<PermissionResponse> ToPermissionResponseCursor(CursorResponse<Permission> source)
    {
        var targetItems = new List<PermissionResponse>(source.Items.Count);

        foreach (var item in source.Items)
        {
            var mapped = ToPermissionResponse(item);
            if (mapped != null)
            {
                targetItems.Add(mapped);
            }
        }

        return new CursorResponse<PermissionResponse>
        {
            Items = targetItems,
            NextCursor = source.NextCursor,
            HasNextPage = source.HasNextPage
        };
    }



  
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