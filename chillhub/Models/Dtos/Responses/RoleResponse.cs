namespace chillhub.Models.Dtos.Responses;

public class RoleResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<PermissionResponse> Permissions { get; set; } = new();
}

