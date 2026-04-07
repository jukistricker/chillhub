using chillhub.Entities;
using chillhub.Entities.Auth;
using chillhub.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace chillhub.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();

    public DbSet<PermissionGroup> PermissionGroups => Set<PermissionGroup>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // Định nghĩa khóa chính tổ hợp cho RolePermission
        modelBuilder.Entity<RolePermission>()
            .HasKey(rp => new { rp.RoleId, rp.PermissionId });

        // Định nghĩa khóa chính tổ hợp cho UserRole
        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(ur => new { ur.UserId, ur.RoleId });

            entity.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            entity.HasOne(ur => ur.Role)
                .WithMany() // Nếu class Role không có List<UserRole> thì để trống
                .HasForeignKey(ur => ur.RoleId);
        });

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // Đổi tên Table: PermissionGroup -> permission_groups
            var tableName = StringUtil.ToSnakeCase(entity.GetTableName() ?? entity.ClrType.Name);
            entity.SetTableName(tableName);

            foreach (var property in entity.GetProperties())
                // Đổi tên Column: PermissionGroupId -> permission_group_id
                property.SetColumnName(StringUtil.ToSnakeCase(property.Name));
        }
    }

    public override int SaveChanges()
    {
        ApplyAuditLog();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        ApplyAuditLog();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyAuditLog()
    {
        var now = DateTimeOffset.UtcNow;
        var rawUserId = HttpContextUtil.CurrentUserId; // chuỗi string từ token

        // Chỉ lọc những thực thể kế thừa IAuditEntity
        foreach (var entry in ChangeTracker.Entries<IAuditEntity>())
        {
            // 1. Cập nhật thời gian (Common cho cả Add và Update)
            entry.Entity.UpdatedAt = now;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = now;

                // 2. Xử lý ID tự động (Chỉ gán nếu là Guid và đang trống)
                var idProp = entry.Property("Id");
                if (idProp.Metadata.ClrType == typeof(Guid) && (Guid)idProp.CurrentValue! == Guid.Empty)
                    idProp.CurrentValue = Guid.CreateVersion7();

                // 3. Gán người tạo/người sửa
                SetAuditUser(entry, "CreatedBy", rawUserId);
                SetAuditUser(entry, "UpdatedBy", rawUserId);
            }
            else if (entry.State == EntityState.Modified)
            {
                // 4. Chỉ gán người sửa khi cập nhật
                SetAuditUser(entry, "UpdatedBy", rawUserId);

                // Bảo vệ các trường không cho phép sửa
                entry.Property("CreatedAt").IsModified = false;
                entry.Property("CreatedBy").IsModified = false;
            }
        }
    }

    private void SetAuditUser(EntityEntry entry, string propName, string? rawUserId)
    {
        PropertyEntry prop = entry.Property(propName);
    
        // Lấy kiểu thực sự bên dưới (nếu là Guid? thì lấy Guid)
        Type targetType = Nullable.GetUnderlyingType(prop.Metadata.ClrType) ?? prop.Metadata.ClrType;

        if (targetType == typeof(Guid))
        {
            // Nếu có Token và Parse được thành Guid
            if (Guid.TryParse(rawUserId, out Guid userId))
            {
                prop.CurrentValue = userId;
            }
            // Nếu không có Token (Trường hợp SignUp hoặc System chạy ngầm)
            else
            {
                
                // prop.CurrentValue = null; 
            }
        }
    }
}