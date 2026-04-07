namespace chillhub.Entities.Auth;

public class RolePermission
{
    public Guid RoleId { get; set; }
    public Guid PermissionId { get; set; }
    public virtual Permission Permission { get; set; } = null!;
    public virtual Role Role { get; set; } = null!;
}