namespace chillhub.Entities.Auth;

public class Permission:BaseEntity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public Guid PermissionGroupId { get; set; }
    // --- NAVIGATION PROPERTIES ---
    // Giúp map tới bảng PermissionGroup
    public virtual PermissionGroup PermissionGroup { get; set; } = null!;

    // Giúp map tới bảng trung gian RolePermission
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}