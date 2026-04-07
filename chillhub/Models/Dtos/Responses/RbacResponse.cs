using chillhub.Models.Dtos.Responses.Shared;

namespace chillhub.Models.Dtos.Responses;

public class PermissionGroupResponse:BaseResponse
{
    public string Name { get; set; } = null!; 
    public string Code { get; set; } = null!; 
    public int SortOrder { get; set; }        
}

public class PermissionResponse:BaseResponse
{
    public string Name { get; set; } = null!; 
    public string Code { get; set; } = null!; 
    public Guid PermissionGroupId { get; set; }
    public string PermissionGroupName { get; set; }
    public Guid RoleId { get; set; }
    public string RoleName { get; set; }
}