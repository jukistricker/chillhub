using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace chillhub.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "permission_groups",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "sort_order", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019e536e-d4c0-73f0-8efa-3decc75e8521"), "rbac_group.admin", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6477), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "RBAC Management", 3, new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6475), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019e536e-d4c0-7524-939f-1e1ff4b0cbba"), "auth_group", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6466), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "Auth", 1, new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6463), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019e536e-d4c0-753a-8840-d6cb51f38090"), "user_group", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6471), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "User", 2, new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6470), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_at", "created_by", "name", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019e536e-d4c0-7123-9344-5ae57959cf47"), new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6185), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "user", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6184), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2"), new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6178), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "admin", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6176), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "avatar_url", "created_at", "created_by", "email", "external_id", "full_name", "lang", "password", "provider", "updated_at", "updated_by", "username" },
                values: new object[] { new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), null, new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(7132), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), null, null, null, 0, "AQAAAAIAACcQAAAAEJL3PEfuwNrQOTsclnmWeXII/9NzpgehrbMF6gOzBfg4BjsiMVqewvfP5/LtaNKj4w==", null, new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(7129), new TimeSpan(0, 0, 0, 0, 0)), null, "admin" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "permission_group_id", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019e536e-d69a-712a-9950-670784a5c901"), "rbac.save_permission_group", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6621), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "Save Permission Group", new Guid("019e536e-d4c0-73f0-8efa-3decc75e8521"), new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6617), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019e536e-d69a-751b-bee8-b1d05cc80b26"), "user.update", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6576), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "Update User's Details", new Guid("019e536e-d4c0-753a-8840-d6cb51f38090"), new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6572), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019e536e-d69a-751e-ad70-f47a2ea7b5ab"), "rbac.save_role", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6636), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "Save Role", new Guid("019e536e-d4c0-73f0-8efa-3decc75e8521"), new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6632), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019e536e-d69a-7618-a780-0223df6f973d"), "rbac.search_permissions", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6660), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "Search Permissions", new Guid("019e536e-d4c0-73f0-8efa-3decc75e8521"), new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6652), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019e536e-d69a-765f-b3b9-effc4f028dc0"), "auth.login", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6546), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "Login", new Guid("019e536e-d4c0-7524-939f-1e1ff4b0cbba"), new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6498), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019e536e-d69a-7691-895e-f1001d0e3387"), "user.delete", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6602), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "Delete User", new Guid("019e536e-d4c0-753a-8840-d6cb51f38090"), new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6584), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019e536e-d69a-7962-94ce-155c394d71ce"), "rbac.search_roles", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6643), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "Search Roles", new Guid("019e536e-d4c0-73f0-8efa-3decc75e8521"), new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6639), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019e536e-d69a-7a1c-889e-96d15911bb8e"), "auth.logout", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6555), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "Logout", new Guid("019e536e-d4c0-7524-939f-1e1ff4b0cbba"), new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6551), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019e536e-d69a-7b9a-827a-b259bc3fee34"), "rbac.search_permission_groups", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6629), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "Search Permission Groups", new Guid("019e536e-d4c0-73f0-8efa-3decc75e8521"), new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6626), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019e536e-d69a-7d0e-8795-31cf3c3d7683"), "user.view_users", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6608), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "View Users", new Guid("019e536e-d4c0-753a-8840-d6cb51f38090"), new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6605), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019e536e-d69a-7dff-a555-2794489e53d7"), "user.create", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6570), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "Add New User", new Guid("019e536e-d4c0-753a-8840-d6cb51f38090"), new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6566), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019e536e-d69a-7e12-bc0d-65a1c0f3cbe5"), "auth.view_session", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6614), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "Get Session", new Guid("019e536e-d4c0-753a-8840-d6cb51f38090"), new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6611), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019e536e-d69a-7f86-bc71-fb4ef40a52cf"), "rbac.save_permission", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6649), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "Save Permissions", new Guid("019e536e-d4c0-73f0-8efa-3decc75e8521"), new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6646), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019e536e-d69a-7fcd-b34e-da6584e58bf8"), "user.read", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6563), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "View User's Details", new Guid("019e536e-d4c0-753a-8840-d6cb51f38090"), new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6558), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019e536e-d69a-7fd4-92c5-5a95c8df7c0a"), "rbac.assign_role", new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6667), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"), "Assign Roles", new Guid("019e536e-d4c0-73f0-8efa-3decc75e8521"), new DateTimeOffset(new DateTime(2026, 5, 23, 6, 3, 53, 370, DateTimeKind.Unspecified).AddTicks(6664), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[] { new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2"), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48") });

            migrationBuilder.InsertData(
                table: "role_permissions",
                columns: new[] { "permission_id", "role_id" },
                values: new object[,]
                {
                    { new Guid("019e536e-d69a-765f-b3b9-effc4f028dc0"), new Guid("019e536e-d4c0-7123-9344-5ae57959cf47") },
                    { new Guid("019e536e-d69a-7a1c-889e-96d15911bb8e"), new Guid("019e536e-d4c0-7123-9344-5ae57959cf47") },
                    { new Guid("019e536e-d69a-7d0e-8795-31cf3c3d7683"), new Guid("019e536e-d4c0-7123-9344-5ae57959cf47") },
                    { new Guid("019e536e-d69a-7e12-bc0d-65a1c0f3cbe5"), new Guid("019e536e-d4c0-7123-9344-5ae57959cf47") },
                    { new Guid("019e536e-d69a-7fcd-b34e-da6584e58bf8"), new Guid("019e536e-d4c0-7123-9344-5ae57959cf47") },
                    { new Guid("019e536e-d69a-712a-9950-670784a5c901"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") },
                    { new Guid("019e536e-d69a-751b-bee8-b1d05cc80b26"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") },
                    { new Guid("019e536e-d69a-751e-ad70-f47a2ea7b5ab"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") },
                    { new Guid("019e536e-d69a-7618-a780-0223df6f973d"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") },
                    { new Guid("019e536e-d69a-765f-b3b9-effc4f028dc0"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") },
                    { new Guid("019e536e-d69a-7691-895e-f1001d0e3387"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") },
                    { new Guid("019e536e-d69a-7962-94ce-155c394d71ce"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") },
                    { new Guid("019e536e-d69a-7a1c-889e-96d15911bb8e"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") },
                    { new Guid("019e536e-d69a-7b9a-827a-b259bc3fee34"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") },
                    { new Guid("019e536e-d69a-7d0e-8795-31cf3c3d7683"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") },
                    { new Guid("019e536e-d69a-7dff-a555-2794489e53d7"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") },
                    { new Guid("019e536e-d69a-7e12-bc0d-65a1c0f3cbe5"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") },
                    { new Guid("019e536e-d69a-7f86-bc71-fb4ef40a52cf"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") },
                    { new Guid("019e536e-d69a-7fcd-b34e-da6584e58bf8"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") },
                    { new Guid("019e536e-d69a-7fd4-92c5-5a95c8df7c0a"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-765f-b3b9-effc4f028dc0"), new Guid("019e536e-d4c0-7123-9344-5ae57959cf47") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-7a1c-889e-96d15911bb8e"), new Guid("019e536e-d4c0-7123-9344-5ae57959cf47") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-7d0e-8795-31cf3c3d7683"), new Guid("019e536e-d4c0-7123-9344-5ae57959cf47") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-7e12-bc0d-65a1c0f3cbe5"), new Guid("019e536e-d4c0-7123-9344-5ae57959cf47") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-7fcd-b34e-da6584e58bf8"), new Guid("019e536e-d4c0-7123-9344-5ae57959cf47") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-712a-9950-670784a5c901"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-751b-bee8-b1d05cc80b26"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-751e-ad70-f47a2ea7b5ab"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-7618-a780-0223df6f973d"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-765f-b3b9-effc4f028dc0"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-7691-895e-f1001d0e3387"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-7962-94ce-155c394d71ce"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-7a1c-889e-96d15911bb8e"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-7b9a-827a-b259bc3fee34"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-7d0e-8795-31cf3c3d7683"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-7dff-a555-2794489e53d7"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-7e12-bc0d-65a1c0f3cbe5"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-7f86-bc71-fb4ef40a52cf"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-7fcd-b34e-da6584e58bf8"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019e536e-d69a-7fd4-92c5-5a95c8df7c0a"), new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2"), new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48") });

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d69a-712a-9950-670784a5c901"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d69a-751b-bee8-b1d05cc80b26"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d69a-751e-ad70-f47a2ea7b5ab"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d69a-7618-a780-0223df6f973d"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d69a-765f-b3b9-effc4f028dc0"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d69a-7691-895e-f1001d0e3387"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d69a-7962-94ce-155c394d71ce"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d69a-7a1c-889e-96d15911bb8e"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d69a-7b9a-827a-b259bc3fee34"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d69a-7d0e-8795-31cf3c3d7683"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d69a-7dff-a555-2794489e53d7"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d69a-7e12-bc0d-65a1c0f3cbe5"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d69a-7f86-bc71-fb4ef40a52cf"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d69a-7fcd-b34e-da6584e58bf8"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d69a-7fd4-92c5-5a95c8df7c0a"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d4c0-7123-9344-5ae57959cf47"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d4c0-72ba-b860-6d3fda8b61d2"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d4c0-7586-a234-9f4ec68d0f48"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d4c0-73f0-8efa-3decc75e8521"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d4c0-7524-939f-1e1ff4b0cbba"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019e536e-d4c0-753a-8840-d6cb51f38090"));
        }
    }
}
