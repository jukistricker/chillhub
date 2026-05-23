using chillhub.Entities;
using chillhub.Entities.Auth;
using chillhub.Models.Enums;
using Microsoft.EntityFrameworkCore;

public static class DataSeeder
{
    // Cố định các GUID để EF Core theo dõi trạng thái dữ liệu (đừng thay đổi các giá trị này sau khi đã chạy migration đầu tiên)
    private static readonly Guid AdminRoleId = Guid.CreateVersion7();
    private static readonly Guid UserRoleId = Guid.CreateVersion7();

    private static readonly Guid AuthGroupId = Guid.CreateVersion7();
    private static readonly Guid UserGroupId = Guid.CreateVersion7();
    private static readonly Guid RbacGroupId = Guid.CreateVersion7();

    private static readonly Guid AdminUserId = Guid.CreateVersion7();

    public static void Seed(ModelBuilder modelBuilder)
    {
        // 1. Roles
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = AdminRoleId, Name = "admin", CreatedAt = DateTimeOffset.UtcNow, CreatedBy = AdminUserId },
            new Role { Id = UserRoleId, Name = "user", CreatedAt = DateTimeOffset.UtcNow, CreatedBy = AdminUserId }
        );

        // 2. Permission Groups
        modelBuilder.Entity<PermissionGroup>().HasData(
            new PermissionGroup { Id = AuthGroupId, Name = "Auth", Code = "auth_group", SortOrder = 1, CreatedAt = DateTimeOffset.UtcNow, CreatedBy = AdminUserId },
            new PermissionGroup { Id = UserGroupId, Name = "User", Code = "user_group", SortOrder = 2, CreatedAt = DateTimeOffset.UtcNow, CreatedBy = AdminUserId },
            new PermissionGroup {Id = RbacGroupId, Name = "RBAC Management", Code = "rbac_group.admin", SortOrder = 3, CreatedAt = DateTimeOffset.UtcNow, CreatedBy = AdminUserId }
        );

        // 3. Permissions (Cần định nghĩa ID cụ thể cho từng permission)
        var permissions = new List<Permission>
        {
            new() { Id = Guid.CreateVersion7(), Code = "auth.login", Name = "Login", PermissionGroupId = AuthGroupId, CreatedAt= DateTimeOffset.UtcNow, CreatedBy= AdminUserId },
            new() { Id = Guid.CreateVersion7(), Code = "auth.logout", Name = "Logout", PermissionGroupId = AuthGroupId, CreatedAt= DateTimeOffset.UtcNow, CreatedBy= AdminUserId},
            new() { Id = Guid.CreateVersion7(), Code = "user.read", Name = "View User's Details", PermissionGroupId = UserGroupId, CreatedAt= DateTimeOffset.UtcNow, CreatedBy= AdminUserId },
            new() { Id = Guid.CreateVersion7(), Code = "user.create", Name = "Add New User", PermissionGroupId = UserGroupId, CreatedAt= DateTimeOffset.UtcNow, CreatedBy= AdminUserId },
            new() { Id = Guid.CreateVersion7(), Code = "user.update", Name = "Update User's Details", PermissionGroupId = UserGroupId, CreatedAt= DateTimeOffset.UtcNow, CreatedBy= AdminUserId },
            new() { Id = Guid.CreateVersion7(), Code = "user.delete", Name = "Delete User", PermissionGroupId = UserGroupId, CreatedAt= DateTimeOffset.UtcNow, CreatedBy= AdminUserId },
            new() {Id = Guid.CreateVersion7(), Code = "user.view_users", Name = "View Users", PermissionGroupId = UserGroupId, CreatedAt = DateTimeOffset.UtcNow, CreatedBy = AdminUserId},
            new() {Id = Guid.CreateVersion7(), Code = "auth.view_session", Name = "Get Session", PermissionGroupId = UserGroupId, CreatedAt = DateTimeOffset.UtcNow, CreatedBy = AdminUserId},
            new() { Id = Guid.CreateVersion7(), Code = "rbac.save_permission_group", Name = "Save Permission Group", PermissionGroupId = RbacGroupId , CreatedAt = DateTimeOffset.UtcNow, CreatedBy = AdminUserId},
            new() { Id = Guid.CreateVersion7(), Code = "rbac.search_permission_groups", Name = "Search Permission Groups", PermissionGroupId = RbacGroupId , CreatedAt = DateTimeOffset.UtcNow, CreatedBy = AdminUserId},
            new() { Id = Guid.CreateVersion7(), Code = "rbac.save_role", Name = "Save Role", PermissionGroupId = RbacGroupId , CreatedAt = DateTimeOffset.UtcNow, CreatedBy = AdminUserId},
            new() { Id = Guid.CreateVersion7(), Code = "rbac.search_roles", Name = "Search Roles", PermissionGroupId = RbacGroupId , CreatedAt = DateTimeOffset.UtcNow, CreatedBy = AdminUserId },
            new() { Id = Guid.CreateVersion7(), Code = "rbac.save_permission", Name = "Save Permissions", PermissionGroupId = RbacGroupId , CreatedAt = DateTimeOffset.UtcNow, CreatedBy = AdminUserId},
            new() { Id = Guid.CreateVersion7(), Code = "rbac.search_permissions", Name = "Search Permissions", PermissionGroupId = RbacGroupId , CreatedAt = DateTimeOffset.UtcNow, CreatedBy = AdminUserId},
            new() { Id = Guid.CreateVersion7(), Code = "rbac.assign_role", Name = "Assign Roles", PermissionGroupId = RbacGroupId , CreatedAt = DateTimeOffset.UtcNow, CreatedBy = AdminUserId}
        };

        modelBuilder.Entity<Permission>().HasData(permissions);

        // 4. RolePermissions (N-N)
        // Admin: lấy toàn bộ quyền
        var rolePermissions = permissions.Select(p => new RolePermission
        {
            RoleId = AdminRoleId,
            PermissionId = p.Id
        }).ToList();

        // User: lấy quyền giới hạn
        var limitedCodes = new[] { "auth.login", "auth.logout", "user.read", "user.view_users", "auth.view_session" };
        rolePermissions.AddRange(permissions
            .Where(p => limitedCodes.Contains(p.Code))
            .Select(p => new RolePermission { RoleId = UserRoleId, PermissionId = p.Id }));

        modelBuilder.Entity<RolePermission>().HasData(rolePermissions);

        // 5. Admin User & UserRole
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = AdminUserId,
                Username = "admin",
                Password = "AQAAAAIAACcQAAAAEJL3PEfuwNrQOTsclnmWeXII/9NzpgehrbMF6gOzBfg4BjsiMVqewvfP5/LtaNKj4w==",
                Lang = LanguageEnum.Vi,
                CreatedAt = DateTimeOffset.UtcNow,
                CreatedBy = AdminUserId,
            }
        );

        modelBuilder.Entity<UserRole>().HasData(
            new UserRole { UserId = AdminUserId, RoleId = AdminRoleId }
        );
    }
}