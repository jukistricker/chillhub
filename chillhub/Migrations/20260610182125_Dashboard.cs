using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace chillhub.Migrations
{
    /// <inheritdoc />
    public partial class Dashboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-7009-8dc3-dc7e9a182b2e"), new Guid("019eb2c1-3d08-7559-b203-dbfcf9bfe2c1") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-746f-9b2b-50cf1f8fc239"), new Guid("019eb2c1-3d08-7559-b203-dbfcf9bfe2c1") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-74dd-8690-16b4a40c5197"), new Guid("019eb2c1-3d08-7559-b203-dbfcf9bfe2c1") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-7b98-85c1-6e279ac7cfbb"), new Guid("019eb2c1-3d08-7559-b203-dbfcf9bfe2c1") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-7ccf-a0d6-d344eb18e813"), new Guid("019eb2c1-3d08-7559-b203-dbfcf9bfe2c1") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-7009-8dc3-dc7e9a182b2e"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-7281-a7bb-ae874c027be8"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-7316-8881-ffe3b855b8c3"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-746f-9b2b-50cf1f8fc239"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-74dd-8690-16b4a40c5197"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-7656-9ff1-678df50c79ce"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-777e-9acb-478ff84fae6e"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-786b-a576-8952818fc44a"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-78db-a485-81366fde8682"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-7aae-b777-ed227bb48f43"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-7b54-af8a-3caadb61587c"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-7b98-85c1-6e279ac7cfbb"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-7c38-aa58-21bdad397eb3"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-7ccf-a0d6-d344eb18e813"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c1-3eb3-7e5b-aa41-c99a4b96912c"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2"), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57") });

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3eb3-7009-8dc3-dc7e9a182b2e"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3eb3-7281-a7bb-ae874c027be8"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3eb3-7316-8881-ffe3b855b8c3"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3eb3-746f-9b2b-50cf1f8fc239"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3eb3-74dd-8690-16b4a40c5197"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3eb3-7656-9ff1-678df50c79ce"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3eb3-777e-9acb-478ff84fae6e"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3eb3-786b-a576-8952818fc44a"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3eb3-78db-a485-81366fde8682"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3eb3-7aae-b777-ed227bb48f43"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3eb3-7b54-af8a-3caadb61587c"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3eb3-7b98-85c1-6e279ac7cfbb"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3eb3-7c38-aa58-21bdad397eb3"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3eb3-7ccf-a0d6-d344eb18e813"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3eb3-7e5b-aa41-c99a4b96912c"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3d08-7559-b203-dbfcf9bfe2c1"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3d08-705f-9139-d4d227b3dec1"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3d08-7223-b8b8-716fd37cc0d0"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eb2c1-3d08-7781-b41b-9018dbcb8746"));

            migrationBuilder.InsertData(
                table: "permission_groups",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "sort_order", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019eb2c4-8808-713e-a003-79fffee5235c"), "rbac_group.admin", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7567), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "RBAC Management", 3, new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7566), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c4-8808-7abe-b09a-ce89d9fc0ac9"), "auth_group", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7557), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "Auth", 1, new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7555), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c4-8808-7f34-bb5b-519f9694b5a2"), "user_group", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7563), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "User", 2, new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7561), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_at", "created_by", "name", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019eb2c4-8808-7446-b3aa-7cb1f0661715"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7345), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "user", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7344), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7339), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "admin", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7337), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "avatar_url", "created_at", "created_by", "email", "external_id", "full_name", "lang", "password", "provider", "updated_at", "updated_by", "username" },
                values: new object[] { new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), null, new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(8125), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "admin@chillhub.id.vn", null, "admin", 0, "AQAAAAIAACcQAAAAEJL3PEfuwNrQOTsclnmWeXII/9NzpgehrbMF6gOzBfg4BjsiMVqewvfP5/LtaNKj4w==", null, new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(8120), new TimeSpan(0, 0, 0, 0, 0)), null, "admin" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "permission_group_id", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019eb2c4-89b2-7053-b5a5-8b793b78b7ea"), "rbac.save_role", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7716), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "Save Role", new Guid("019eb2c4-8808-713e-a003-79fffee5235c"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7713), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c4-89b2-729b-b8cc-e6371926275d"), "rbac.save_permission_group", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7703), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "Save Permission Group", new Guid("019eb2c4-8808-713e-a003-79fffee5235c"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7700), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c4-89b2-74ff-a8ca-2952c4f011d7"), "user.delete", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7685), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "Delete User", new Guid("019eb2c4-8808-7f34-bb5b-519f9694b5a2"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7682), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c4-89b2-772e-8429-026f51558c58"), "rbac.assign_role", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7745), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "Assign Roles", new Guid("019eb2c4-8808-713e-a003-79fffee5235c"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7742), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c4-89b2-7869-b09c-3a9e40163ec5"), "rbac.search_permission_groups", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7710), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "Search Permission Groups", new Guid("019eb2c4-8808-713e-a003-79fffee5235c"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7707), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c4-89b2-7882-a28d-33bc71958934"), "user.view_users", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7691), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "View Users", new Guid("019eb2c4-8808-7f34-bb5b-519f9694b5a2"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7688), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c4-89b2-78d6-ba34-2e99f697ffdf"), "auth.login", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7628), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "Login", new Guid("019eb2c4-8808-7abe-b09a-ce89d9fc0ac9"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7585), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c4-89b2-7945-959b-bcb905ed6d56"), "rbac.save_permission", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7733), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "Save Permissions", new Guid("019eb2c4-8808-713e-a003-79fffee5235c"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7725), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c4-89b2-7958-9bb4-d052d3532b6d"), "user.create", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7652), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "Add New User", new Guid("019eb2c4-8808-7f34-bb5b-519f9694b5a2"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7649), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c4-89b2-79c8-afba-21e149cfc195"), "rbac.search_permissions", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7740), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "Search Permissions", new Guid("019eb2c4-8808-713e-a003-79fffee5235c"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7736), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c4-89b2-7a2d-9858-bedc226816da"), "auth.view_session", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7697), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "Get Session", new Guid("019eb2c4-8808-7f34-bb5b-519f9694b5a2"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7694), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c4-89b2-7c67-a6af-13feb44ab201"), "user.read", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7646), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "View User's Details", new Guid("019eb2c4-8808-7f34-bb5b-519f9694b5a2"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7642), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c4-89b2-7c95-aa96-40d46f2e8899"), "rbac.search_roles", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7722), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "Search Roles", new Guid("019eb2c4-8808-713e-a003-79fffee5235c"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7719), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c4-89b2-7eea-8c6a-a308e4e72a71"), "user.update", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7673), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "Update User's Details", new Guid("019eb2c4-8808-7f34-bb5b-519f9694b5a2"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7655), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c4-89b2-7fb7-a86a-3e7c27d5a740"), "auth.logout", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7639), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"), "Logout", new Guid("019eb2c4-8808-7abe-b09a-ce89d9fc0ac9"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 21, 25, 298, DateTimeKind.Unspecified).AddTicks(7635), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[] { new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a"), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9") });

            migrationBuilder.InsertData(
                table: "role_permissions",
                columns: new[] { "permission_id", "role_id" },
                values: new object[,]
                {
                    { new Guid("019eb2c4-89b2-7882-a28d-33bc71958934"), new Guid("019eb2c4-8808-7446-b3aa-7cb1f0661715") },
                    { new Guid("019eb2c4-89b2-78d6-ba34-2e99f697ffdf"), new Guid("019eb2c4-8808-7446-b3aa-7cb1f0661715") },
                    { new Guid("019eb2c4-89b2-7a2d-9858-bedc226816da"), new Guid("019eb2c4-8808-7446-b3aa-7cb1f0661715") },
                    { new Guid("019eb2c4-89b2-7c67-a6af-13feb44ab201"), new Guid("019eb2c4-8808-7446-b3aa-7cb1f0661715") },
                    { new Guid("019eb2c4-89b2-7fb7-a86a-3e7c27d5a740"), new Guid("019eb2c4-8808-7446-b3aa-7cb1f0661715") },
                    { new Guid("019eb2c4-89b2-7053-b5a5-8b793b78b7ea"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") },
                    { new Guid("019eb2c4-89b2-729b-b8cc-e6371926275d"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") },
                    { new Guid("019eb2c4-89b2-74ff-a8ca-2952c4f011d7"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") },
                    { new Guid("019eb2c4-89b2-772e-8429-026f51558c58"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") },
                    { new Guid("019eb2c4-89b2-7869-b09c-3a9e40163ec5"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") },
                    { new Guid("019eb2c4-89b2-7882-a28d-33bc71958934"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") },
                    { new Guid("019eb2c4-89b2-78d6-ba34-2e99f697ffdf"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") },
                    { new Guid("019eb2c4-89b2-7945-959b-bcb905ed6d56"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") },
                    { new Guid("019eb2c4-89b2-7958-9bb4-d052d3532b6d"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") },
                    { new Guid("019eb2c4-89b2-79c8-afba-21e149cfc195"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") },
                    { new Guid("019eb2c4-89b2-7a2d-9858-bedc226816da"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") },
                    { new Guid("019eb2c4-89b2-7c67-a6af-13feb44ab201"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") },
                    { new Guid("019eb2c4-89b2-7c95-aa96-40d46f2e8899"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") },
                    { new Guid("019eb2c4-89b2-7eea-8c6a-a308e4e72a71"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") },
                    { new Guid("019eb2c4-89b2-7fb7-a86a-3e7c27d5a740"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-7882-a28d-33bc71958934"), new Guid("019eb2c4-8808-7446-b3aa-7cb1f0661715") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-78d6-ba34-2e99f697ffdf"), new Guid("019eb2c4-8808-7446-b3aa-7cb1f0661715") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-7a2d-9858-bedc226816da"), new Guid("019eb2c4-8808-7446-b3aa-7cb1f0661715") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-7c67-a6af-13feb44ab201"), new Guid("019eb2c4-8808-7446-b3aa-7cb1f0661715") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-7fb7-a86a-3e7c27d5a740"), new Guid("019eb2c4-8808-7446-b3aa-7cb1f0661715") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-7053-b5a5-8b793b78b7ea"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-729b-b8cc-e6371926275d"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-74ff-a8ca-2952c4f011d7"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-772e-8429-026f51558c58"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-7869-b09c-3a9e40163ec5"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-7882-a28d-33bc71958934"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-78d6-ba34-2e99f697ffdf"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-7945-959b-bcb905ed6d56"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-7958-9bb4-d052d3532b6d"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-79c8-afba-21e149cfc195"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-7a2d-9858-bedc226816da"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-7c67-a6af-13feb44ab201"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-7c95-aa96-40d46f2e8899"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-7eea-8c6a-a308e4e72a71"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019eb2c4-89b2-7fb7-a86a-3e7c27d5a740"), new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a"), new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9") });

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-89b2-7053-b5a5-8b793b78b7ea"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-89b2-729b-b8cc-e6371926275d"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-89b2-74ff-a8ca-2952c4f011d7"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-89b2-772e-8429-026f51558c58"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-89b2-7869-b09c-3a9e40163ec5"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-89b2-7882-a28d-33bc71958934"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-89b2-78d6-ba34-2e99f697ffdf"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-89b2-7945-959b-bcb905ed6d56"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-89b2-7958-9bb4-d052d3532b6d"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-89b2-79c8-afba-21e149cfc195"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-89b2-7a2d-9858-bedc226816da"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-89b2-7c67-a6af-13feb44ab201"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-89b2-7c95-aa96-40d46f2e8899"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-89b2-7eea-8c6a-a308e4e72a71"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-89b2-7fb7-a86a-3e7c27d5a740"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-8808-7446-b3aa-7cb1f0661715"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-8808-7d24-9999-758c0d5a976a"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-8808-7602-91b5-fdf7caf2b8a9"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-8808-713e-a003-79fffee5235c"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-8808-7abe-b09a-ce89d9fc0ac9"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eb2c4-8808-7f34-bb5b-519f9694b5a2"));

            migrationBuilder.InsertData(
                table: "permission_groups",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "sort_order", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019eb2c1-3d08-705f-9139-d4d227b3dec1"), "auth_group", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(433), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "Auth", 1, new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(431), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c1-3d08-7223-b8b8-716fd37cc0d0"), "rbac_group.admin", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(444), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "RBAC Management", 3, new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(442), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c1-3d08-7781-b41b-9018dbcb8746"), "user_group", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(439), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "User", 2, new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(437), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_at", "created_by", "name", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019eb2c1-3d08-7559-b203-dbfcf9bfe2c1"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(214), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "user", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(213), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(207), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "admin", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(203), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "avatar_url", "created_at", "created_by", "email", "external_id", "full_name", "lang", "password", "provider", "updated_at", "updated_by", "username" },
                values: new object[] { new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), null, new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(1019), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "admin@chillhub.id.vn", null, "admin", 0, "AQAAAAIAACcQAAAAEJL3PEfuwNrQOTsclnmWeXII/9NzpgehrbMF6gOzBfg4BjsiMVqewvfP5/LtaNKj4w==", null, new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(1016), new TimeSpan(0, 0, 0, 0, 0)), null, "admin" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "permission_group_id", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019eb2c1-3eb3-7009-8dc3-dc7e9a182b2e"), "auth.view_session", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(572), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "Get Session", new Guid("019eb2c1-3d08-7781-b41b-9018dbcb8746"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(554), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c1-3eb3-7281-a7bb-ae874c027be8"), "rbac.search_permission_groups", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(586), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "Search Permission Groups", new Guid("019eb2c1-3d08-7223-b8b8-716fd37cc0d0"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(583), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c1-3eb3-7316-8881-ffe3b855b8c3"), "rbac.search_permissions", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(609), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "Search Permissions", new Guid("019eb2c1-3d08-7223-b8b8-716fd37cc0d0"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(606), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c1-3eb3-746f-9b2b-50cf1f8fc239"), "user.read", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(524), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "View User's Details", new Guid("019eb2c1-3d08-7781-b41b-9018dbcb8746"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(520), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c1-3eb3-74dd-8690-16b4a40c5197"), "auth.login", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(507), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "Login", new Guid("019eb2c1-3d08-705f-9139-d4d227b3dec1"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(462), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c1-3eb3-7656-9ff1-678df50c79ce"), "user.delete", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(545), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "Delete User", new Guid("019eb2c1-3d08-7781-b41b-9018dbcb8746"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(542), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c1-3eb3-777e-9acb-478ff84fae6e"), "user.update", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(536), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "Update User's Details", new Guid("019eb2c1-3d08-7781-b41b-9018dbcb8746"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(532), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c1-3eb3-786b-a576-8952818fc44a"), "rbac.assign_role", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(615), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "Assign Roles", new Guid("019eb2c1-3d08-7223-b8b8-716fd37cc0d0"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(612), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c1-3eb3-78db-a485-81366fde8682"), "user.create", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(530), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "Add New User", new Guid("019eb2c1-3d08-7781-b41b-9018dbcb8746"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(527), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c1-3eb3-7aae-b777-ed227bb48f43"), "rbac.save_role", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(592), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "Save Role", new Guid("019eb2c1-3d08-7223-b8b8-716fd37cc0d0"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(589), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c1-3eb3-7b54-af8a-3caadb61587c"), "rbac.save_permission", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(603), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "Save Permissions", new Guid("019eb2c1-3d08-7223-b8b8-716fd37cc0d0"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(600), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c1-3eb3-7b98-85c1-6e279ac7cfbb"), "user.view_users", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(551), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "View Users", new Guid("019eb2c1-3d08-7781-b41b-9018dbcb8746"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(548), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c1-3eb3-7c38-aa58-21bdad397eb3"), "rbac.search_roles", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(598), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "Search Roles", new Guid("019eb2c1-3d08-7223-b8b8-716fd37cc0d0"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(595), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c1-3eb3-7ccf-a0d6-d344eb18e813"), "auth.logout", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(517), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "Logout", new Guid("019eb2c1-3d08-705f-9139-d4d227b3dec1"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(513), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eb2c1-3eb3-7e5b-aa41-c99a4b96912c"), "rbac.save_permission_group", new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(578), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57"), "Save Permission Group", new Guid("019eb2c1-3d08-7223-b8b8-716fd37cc0d0"), new DateTimeOffset(new DateTime(2026, 6, 10, 18, 17, 49, 491, DateTimeKind.Unspecified).AddTicks(575), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[] { new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2"), new Guid("019eb2c1-3d08-74f8-9a12-2b806f3d4b57") });

            migrationBuilder.InsertData(
                table: "role_permissions",
                columns: new[] { "permission_id", "role_id" },
                values: new object[,]
                {
                    { new Guid("019eb2c1-3eb3-7009-8dc3-dc7e9a182b2e"), new Guid("019eb2c1-3d08-7559-b203-dbfcf9bfe2c1") },
                    { new Guid("019eb2c1-3eb3-746f-9b2b-50cf1f8fc239"), new Guid("019eb2c1-3d08-7559-b203-dbfcf9bfe2c1") },
                    { new Guid("019eb2c1-3eb3-74dd-8690-16b4a40c5197"), new Guid("019eb2c1-3d08-7559-b203-dbfcf9bfe2c1") },
                    { new Guid("019eb2c1-3eb3-7b98-85c1-6e279ac7cfbb"), new Guid("019eb2c1-3d08-7559-b203-dbfcf9bfe2c1") },
                    { new Guid("019eb2c1-3eb3-7ccf-a0d6-d344eb18e813"), new Guid("019eb2c1-3d08-7559-b203-dbfcf9bfe2c1") },
                    { new Guid("019eb2c1-3eb3-7009-8dc3-dc7e9a182b2e"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") },
                    { new Guid("019eb2c1-3eb3-7281-a7bb-ae874c027be8"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") },
                    { new Guid("019eb2c1-3eb3-7316-8881-ffe3b855b8c3"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") },
                    { new Guid("019eb2c1-3eb3-746f-9b2b-50cf1f8fc239"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") },
                    { new Guid("019eb2c1-3eb3-74dd-8690-16b4a40c5197"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") },
                    { new Guid("019eb2c1-3eb3-7656-9ff1-678df50c79ce"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") },
                    { new Guid("019eb2c1-3eb3-777e-9acb-478ff84fae6e"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") },
                    { new Guid("019eb2c1-3eb3-786b-a576-8952818fc44a"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") },
                    { new Guid("019eb2c1-3eb3-78db-a485-81366fde8682"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") },
                    { new Guid("019eb2c1-3eb3-7aae-b777-ed227bb48f43"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") },
                    { new Guid("019eb2c1-3eb3-7b54-af8a-3caadb61587c"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") },
                    { new Guid("019eb2c1-3eb3-7b98-85c1-6e279ac7cfbb"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") },
                    { new Guid("019eb2c1-3eb3-7c38-aa58-21bdad397eb3"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") },
                    { new Guid("019eb2c1-3eb3-7ccf-a0d6-d344eb18e813"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") },
                    { new Guid("019eb2c1-3eb3-7e5b-aa41-c99a4b96912c"), new Guid("019eb2c1-3d08-7dfd-b826-f3a006a76ab2") }
                });
        }
    }
}
