namespace chillhub.Entities.Auth;
public class PermissionGroup : BaseEntity
{
    public string Name { get; set; } = null!; // Tên hiển thị: "Hệ thống"
    public string Code { get; set; } = null!; // "SYSTEM_SETTING"
    public int SortOrder { get; set; }        // Sắp xếp trên UI
    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
