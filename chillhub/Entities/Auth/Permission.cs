namespace chillhub.Entities.Auth;

public class Permission:BaseEntity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public Guid PermissionGroupId { get; set; }

    public virtual PermissionGroup PermissionGroup { get; set; } = null!;
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}