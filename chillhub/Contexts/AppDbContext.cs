using chillhub.Entities;
using chillhub.Entities.Auth;
using chillhub.Entities.Media;
using chillhub.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

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
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Media> Medias => Set<Media>();
    public DbSet<MediaCategory> MediaCategories  => Set<MediaCategory>();
    public DbSet<MediaHistory> MediaHistories => Set<MediaHistory>();
    public DbSet<MediaReaction> MediaReactions => Set<MediaReaction>();
    public DbSet<Subscriber> Subscribers => Set<Subscriber>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // Đổi tên Table: PermissionGroup -> permission_groups
            var tableName = StringUtil.ToSnakeCase(entity.GetTableName() ?? entity.ClrType.Name);
            entity.SetTableName(tableName);

            foreach (var property in entity.GetProperties())
            {
                // Đổi tên Column: PermissionGroupId -> permission_group_id
                property.SetColumnName(StringUtil.ToSnakeCase(property.Name));
            }
        }
        DataSeeder.Seed(modelBuilder);
        try
        {
            // Ép EF Core chạy thử cơ chế kiểm tra Model xem có gì bất thường không
            var model = modelBuilder.Model;
        }
        catch (Exception ex)
        {
            // Đặt một Breakpoint tại dòng này nếu bạn dùng Visual Studio / VS Code để Debug
            var ghi_nho_loi = ex.Message;
            throw;
        }
    }

}