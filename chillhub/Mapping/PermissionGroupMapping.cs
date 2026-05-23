using chillhub.Entities.Auth;
using chillhub.Models.Dtos.Responses;
using chillhub.Models.Dtos.Responses.Search;

namespace chillhub.Mapping;

public static class PermissionGroupMapping
{
    public static PermissionGroupResponse? ToPermissionGroupResponse(PermissionGroup? permissionGroup)
    {
        if (permissionGroup == null) return null;

        return new PermissionGroupResponse
        {
            Id = permissionGroup.Id,
            CreatedAt = permissionGroup.CreatedAt,
            CreatedBy = permissionGroup.CreatedBy,
            UpdatedAt = permissionGroup.UpdatedAt,
            UpdatedBy = permissionGroup.UpdatedBy,
            
            Code= permissionGroup.Code,
            SortOrder= permissionGroup.SortOrder,
            Name= permissionGroup.Name,

        };
    }

    public static CursorResponse<PermissionGroupResponse> ToPermissionGroupResponseCursor(CursorResponse<PermissionGroup> source)
    {
        var targetItems = new List<PermissionGroupResponse>(source.Items.Count);

        foreach (var item in source.Items)
        {
            var mapped = ToPermissionGroupResponse(item);
            if (mapped != null)
            {
                targetItems.Add(mapped);
            }
        }

        return new CursorResponse<PermissionGroupResponse>
        {
            Items = targetItems,
            NextCursor = source.NextCursor,
            HasNextPage = source.HasNextPage
        };
    }
}
