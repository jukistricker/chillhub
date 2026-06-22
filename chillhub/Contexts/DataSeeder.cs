using chillhub.Entities;
using chillhub.Entities.Auth;
using chillhub.Models.Enums;
using Microsoft.EntityFrameworkCore;

public static class DataSeeder
{
    // Cố định các GUID để EF Core theo dõi trạng thái dữ liệu (đừng thay đổi các giá trị này sau khi đã chạy migration đầu tiên)
    private static readonly Guid AdminRoleId = Guid.Parse("019eed25-b9ba-7c95-bff5-2f166b4e0112");
    private static readonly Guid UserRoleId = Guid.Parse("019eed25-b9cb-75a5-b4dc-ed6e00d0b41a");

    private static readonly Guid AuthGroupId = Guid.Parse("019eed25-b9cb-72a8-bb2e-cde54dc0f0ae");
    private static readonly Guid UserGroupId = Guid.Parse("019eed25-b9cb-74ad-bd0b-dcc44f4d0e63");
    private static readonly Guid RbacGroupId = Guid.Parse("019eed25-b9cb-7238-aad7-74e3c7d0aa5d");

    private static readonly Guid AdminUserId = Guid.Parse("019eed25-b9cc-7b05-b21b-f4c3f68c9d06");

    private static readonly DateTimeOffset SeedTime = new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);
    public static void Seed(ModelBuilder modelBuilder)
    {
        // 1. Roles
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = AdminRoleId, Name = "admin", CreatedAt = SeedTime, CreatedBy = AdminUserId },
            new Role { Id = UserRoleId, Name = "user", CreatedAt = SeedTime, CreatedBy = AdminUserId }
        );

        // 2. Permission Groups
        modelBuilder.Entity<PermissionGroup>().HasData(
            new PermissionGroup { Id = AuthGroupId, Name = "Auth", Code = "auth_group", SortOrder = 1, CreatedAt = SeedTime, CreatedBy = AdminUserId },
            new PermissionGroup { Id = UserGroupId, Name = "User", Code = "user_group", SortOrder = 2, CreatedAt = SeedTime, CreatedBy = AdminUserId },
            new PermissionGroup {Id = RbacGroupId, Name = "RBAC Management", Code = "rbac_group.admin", SortOrder = 3, CreatedAt = SeedTime, CreatedBy = AdminUserId }
        );

        // 3. Permissions (Cần định nghĩa ID cụ thể cho từng permission)
        var permissions = new List<Permission>
        {
            new() { Id = Guid.Parse("019eed25-b9cc-794c-810b-78aa25c6a3af"), Code = "auth.login", Name = "Login", PermissionGroupId = AuthGroupId, CreatedAt= SeedTime, CreatedBy= AdminUserId },
            new() { Id = Guid.Parse("019eed25-b9cc-714e-a4a5-65b7618479d0"), Code = "auth.logout", Name = "Logout", PermissionGroupId = AuthGroupId, CreatedAt= SeedTime, CreatedBy= AdminUserId},
            new() { Id = Guid.Parse("019eed25-b9cc-7e77-8537-70d11bbbaeb5"), Code = "user.read", Name = "View User's Details", PermissionGroupId = UserGroupId, CreatedAt= SeedTime, CreatedBy= AdminUserId },
            new() { Id = Guid.Parse("019eed25-b9cc-79e1-aa4d-5fdb20386a3a"), Code = "user.create", Name = "Add New User", PermissionGroupId = UserGroupId, CreatedAt= SeedTime, CreatedBy= AdminUserId },
            new() { Id = Guid.Parse("019eed25-b9cc-7dc5-8971-05b0664f7cbc"), Code = "user.update", Name = "Update User's Details", PermissionGroupId = UserGroupId, CreatedAt= SeedTime, CreatedBy= AdminUserId },
            new() { Id = Guid.Parse("019eed25-b9cc-778e-ae06-f9818fbca912"), Code = "user.delete", Name = "Delete User", PermissionGroupId = UserGroupId, CreatedAt= SeedTime, CreatedBy= AdminUserId },
            new() {Id = Guid.Parse("019eed25-b9cc-7443-97b5-a1cb8fff24f5"), Code = "user.view_users", Name = "View Users", PermissionGroupId = UserGroupId, CreatedAt = SeedTime, CreatedBy = AdminUserId},
            new() {Id = Guid.Parse("019eed25-b9cc-74f9-b319-7cb58f050238"), Code = "auth.view_session", Name = "Get Session", PermissionGroupId = UserGroupId, CreatedAt = SeedTime, CreatedBy = AdminUserId},
            new() { Id = Guid.Parse("019eed25-b9cc-7638-a730-8199fc197a58"), Code = "rbac.save_permission_group", Name = "Save Permission Group", PermissionGroupId = RbacGroupId , CreatedAt = SeedTime, CreatedBy = AdminUserId},
            new() { Id = Guid.Parse("019eed25-b9cd-7208-831d-00b76a0ca679"), Code = "rbac.search_permission_groups", Name = "Search Permission Groups", PermissionGroupId = RbacGroupId , CreatedAt = SeedTime, CreatedBy = AdminUserId},
            new() { Id = Guid.Parse("019eed25-b9cd-7b05-9a0d-d4a3576e908a"), Code = "rbac.save_role", Name = "Save Role", PermissionGroupId = RbacGroupId , CreatedAt = SeedTime, CreatedBy = AdminUserId},
            new() { Id = Guid.Parse("019eed25-b9cd-773f-b37b-65f8db97edf2"), Code = "rbac.search_roles", Name = "Search Roles", PermissionGroupId = RbacGroupId , CreatedAt = SeedTime, CreatedBy = AdminUserId },
            new() { Id = Guid.Parse("019eed25-b9cd-77c2-afef-01e092e22359"), Code = "rbac.save_permission", Name = "Save Permissions", PermissionGroupId = RbacGroupId , CreatedAt = SeedTime, CreatedBy = AdminUserId},
            new() { Id = Guid.Parse("019eed25-b9cd-72ee-a00d-dc1e3f02fae6"), Code = "rbac.search_permissions", Name = "Search Permissions", PermissionGroupId = RbacGroupId , CreatedAt = SeedTime, CreatedBy = AdminUserId},
            new() { Id = Guid.Parse("019eed25-b9cd-7175-a2d2-1b8f0b06791a"), Code = "rbac.assign_role", Name = "Assign Roles", PermissionGroupId = RbacGroupId , CreatedAt = SeedTime, CreatedBy = AdminUserId},
            new() { Id = Guid.Parse("019eed25-b9cd-7007-bb65-1eca5d5baa4b"), Code = "media.create_category", Name = "Create Category", PermissionGroupId = RbacGroupId , CreatedAt = SeedTime, CreatedBy = AdminUserId},
            new() { Id = Guid.Parse("019eed25-b9cd-731f-bdc6-037a645e66c2"), Code = "media.media.update_category", Name = "Update Category", PermissionGroupId = RbacGroupId , CreatedAt = SeedTime, CreatedBy = AdminUserId}



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
                Email = "admin@chillhub.id.vn",
                FullName = "admin",
                Password = "AQAAAAIAACcQAAAAEJL3PEfuwNrQOTsclnmWeXII/9NzpgehrbMF6gOzBfg4BjsiMVqewvfP5/LtaNKj4w==",
                Lang = LanguageEnum.Vi,
                CreatedAt = SeedTime,
                CreatedBy = AdminUserId,
            }
        );

        modelBuilder.Entity<UserRole>().HasData(
            new UserRole { UserId = AdminUserId, RoleId = AdminRoleId }
        );
    }
}