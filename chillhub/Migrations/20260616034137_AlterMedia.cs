using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace chillhub.Migrations
{
    /// <inheritdoc />
    public partial class AlterMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-70e2-b433-fbf70e7c46bb"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-7150-9bd8-3dc984224d11"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-729f-8b21-7c417ced5226"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-730f-adcc-73d7e98cd661"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-7327-925e-bd09b30c3085"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-73d9-9082-aca578be0435"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-75b1-bfa1-7e41ccdbc87e"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-75e6-8dbd-0cb45c575260"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-7815-be34-e6e6a88dd275"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-78de-b473-fae27dea0e93"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-79cd-9c89-84f847dc6e18"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-7e30-84ef-4e42718943a5"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-7eea-9c6c-3dd988405222"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-7f3b-806f-4130795acf66"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-7f82-8348-3215c4045e1f"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-7150-9bd8-3dc984224d11"), new Guid("019ec8a9-46be-7cbd-ab33-260ffc78dd0c") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-73d9-9082-aca578be0435"), new Guid("019ec8a9-46be-7cbd-ab33-260ffc78dd0c") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-78de-b473-fae27dea0e93"), new Guid("019ec8a9-46be-7cbd-ab33-260ffc78dd0c") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-79cd-9c89-84f847dc6e18"), new Guid("019ec8a9-46be-7cbd-ab33-260ffc78dd0c") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ec8a9-4884-7f82-8348-3215c4045e1f"), new Guid("019ec8a9-46be-7cbd-ab33-260ffc78dd0c") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("019ec8a9-46be-7455-9c77-7b427c340899"), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4") });

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-4884-70e2-b433-fbf70e7c46bb"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-4884-7150-9bd8-3dc984224d11"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-4884-729f-8b21-7c417ced5226"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-4884-730f-adcc-73d7e98cd661"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-4884-7327-925e-bd09b30c3085"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-4884-73d9-9082-aca578be0435"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-4884-75b1-bfa1-7e41ccdbc87e"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-4884-75e6-8dbd-0cb45c575260"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-4884-7815-be34-e6e6a88dd275"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-4884-78de-b473-fae27dea0e93"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-4884-79cd-9c89-84f847dc6e18"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-4884-7e30-84ef-4e42718943a5"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-4884-7eea-9c6c-3dd988405222"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-4884-7f3b-806f-4130795acf66"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-4884-7f82-8348-3215c4045e1f"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-46be-7455-9c77-7b427c340899"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-46be-7cbd-ab33-260ffc78dd0c"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-46be-7513-aab7-8d669d4101c3"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-46be-78b2-9a4b-26385831c47c"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019ec8a9-46be-7f68-862b-5049f8fd3888"));

            migrationBuilder.AlterColumn<long>(
                name: "duration",
                table: "medias",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<long>(
                name: "view_count",
                table: "medias",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                table: "permission_groups",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "sort_order", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019ece85-30ad-717e-9b67-32b826bcc65c"), "user_group", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3076), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "User", 2, new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3074), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ece85-30ad-7412-88c2-a81a44c998fc"), "auth_group", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3070), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "Auth", 1, new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3067), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ece85-30ad-7504-a60f-00a6471bb3cc"), "rbac_group.admin", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3081), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "RBAC Management", 3, new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3079), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_at", "created_by", "name", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019ece85-30ad-7042-b491-bef0128e8b3e"), new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(2861), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "user", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(2860), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598"), new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(2855), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "admin", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(2852), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "avatar_url", "created_at", "created_by", "email", "external_id", "full_name", "lang", "password", "provider", "updated_at", "updated_by", "username" },
                values: new object[] { new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), null, new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3716), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "admin@chillhub.id.vn", null, "admin", 0, "AQAAAAIAACcQAAAAEJL3PEfuwNrQOTsclnmWeXII/9NzpgehrbMF6gOzBfg4BjsiMVqewvfP5/LtaNKj4w==", null, new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3712), new TimeSpan(0, 0, 0, 0, 0)), null, "admin" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "permission_group_id", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019ece85-3268-7081-9e10-f63ca5c5833c"), "rbac.search_permission_groups", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3234), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "Search Permission Groups", new Guid("019ece85-30ad-7504-a60f-00a6471bb3cc"), new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3230), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ece85-3268-71a3-b32d-2eddd8b953ef"), "user.delete", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3207), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "Delete User", new Guid("019ece85-30ad-717e-9b67-32b826bcc65c"), new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3204), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ece85-3268-7252-966c-5e85038608e7"), "auth.view_session", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3220), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "Get Session", new Guid("019ece85-30ad-717e-9b67-32b826bcc65c"), new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3216), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ece85-3268-7289-a14d-090f988ca849"), "rbac.search_permissions", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3263), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "Search Permissions", new Guid("019ece85-30ad-7504-a60f-00a6471bb3cc"), new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3260), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ece85-3268-740e-9a2e-afee11b34979"), "rbac.save_permission_group", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3226), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "Save Permission Group", new Guid("019ece85-30ad-7504-a60f-00a6471bb3cc"), new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3223), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ece85-3268-7696-8fe3-f5edf1a1c02b"), "user.create", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3189), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "Add New User", new Guid("019ece85-30ad-717e-9b67-32b826bcc65c"), new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3171), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ece85-3268-7743-a256-61730dcbc7a0"), "auth.login", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3148), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "Login", new Guid("019ece85-30ad-7412-88c2-a81a44c998fc"), new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3100), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ece85-3268-789d-a5a2-6eec2bba22ce"), "user.view_users", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3213), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "View Users", new Guid("019ece85-30ad-717e-9b67-32b826bcc65c"), new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3210), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ece85-3268-796e-897a-0657ce3d7014"), "rbac.assign_role", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3269), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "Assign Roles", new Guid("019ece85-30ad-7504-a60f-00a6471bb3cc"), new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3266), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ece85-3268-7a6e-9b09-c11775cb07f0"), "auth.logout", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3161), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "Logout", new Guid("019ece85-30ad-7412-88c2-a81a44c998fc"), new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3157), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ece85-3268-7b6f-8155-c0b13fbcd6de"), "rbac.save_permission", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3257), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "Save Permissions", new Guid("019ece85-30ad-7504-a60f-00a6471bb3cc"), new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3253), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ece85-3268-7bb6-b751-b4e58df5cda3"), "user.read", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3168), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "View User's Details", new Guid("019ece85-30ad-717e-9b67-32b826bcc65c"), new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3164), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ece85-3268-7bd4-8dc1-accc6b6a4c6f"), "rbac.search_roles", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3250), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "Search Roles", new Guid("019ece85-30ad-7504-a60f-00a6471bb3cc"), new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3243), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ece85-3268-7c90-b2bd-f54ca3d55627"), "rbac.save_role", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3240), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "Save Role", new Guid("019ece85-30ad-7504-a60f-00a6471bb3cc"), new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3237), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ece85-3268-7f17-8e7e-1bde323e2985"), "user.update", new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3196), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"), "Update User's Details", new Guid("019ece85-30ad-717e-9b67-32b826bcc65c"), new DateTimeOffset(new DateTime(2026, 6, 16, 3, 41, 36, 232, DateTimeKind.Unspecified).AddTicks(3192), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[] { new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598"), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464") });

            migrationBuilder.InsertData(
                table: "role_permissions",
                columns: new[] { "permission_id", "role_id" },
                values: new object[,]
                {
                    { new Guid("019ece85-3268-7252-966c-5e85038608e7"), new Guid("019ece85-30ad-7042-b491-bef0128e8b3e") },
                    { new Guid("019ece85-3268-7743-a256-61730dcbc7a0"), new Guid("019ece85-30ad-7042-b491-bef0128e8b3e") },
                    { new Guid("019ece85-3268-789d-a5a2-6eec2bba22ce"), new Guid("019ece85-30ad-7042-b491-bef0128e8b3e") },
                    { new Guid("019ece85-3268-7a6e-9b09-c11775cb07f0"), new Guid("019ece85-30ad-7042-b491-bef0128e8b3e") },
                    { new Guid("019ece85-3268-7bb6-b751-b4e58df5cda3"), new Guid("019ece85-30ad-7042-b491-bef0128e8b3e") },
                    { new Guid("019ece85-3268-7081-9e10-f63ca5c5833c"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") },
                    { new Guid("019ece85-3268-71a3-b32d-2eddd8b953ef"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") },
                    { new Guid("019ece85-3268-7252-966c-5e85038608e7"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") },
                    { new Guid("019ece85-3268-7289-a14d-090f988ca849"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") },
                    { new Guid("019ece85-3268-740e-9a2e-afee11b34979"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") },
                    { new Guid("019ece85-3268-7696-8fe3-f5edf1a1c02b"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") },
                    { new Guid("019ece85-3268-7743-a256-61730dcbc7a0"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") },
                    { new Guid("019ece85-3268-789d-a5a2-6eec2bba22ce"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") },
                    { new Guid("019ece85-3268-796e-897a-0657ce3d7014"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") },
                    { new Guid("019ece85-3268-7a6e-9b09-c11775cb07f0"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") },
                    { new Guid("019ece85-3268-7b6f-8155-c0b13fbcd6de"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") },
                    { new Guid("019ece85-3268-7bb6-b751-b4e58df5cda3"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") },
                    { new Guid("019ece85-3268-7bd4-8dc1-accc6b6a4c6f"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") },
                    { new Guid("019ece85-3268-7c90-b2bd-f54ca3d55627"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") },
                    { new Guid("019ece85-3268-7f17-8e7e-1bde323e2985"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-7252-966c-5e85038608e7"), new Guid("019ece85-30ad-7042-b491-bef0128e8b3e") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-7743-a256-61730dcbc7a0"), new Guid("019ece85-30ad-7042-b491-bef0128e8b3e") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-789d-a5a2-6eec2bba22ce"), new Guid("019ece85-30ad-7042-b491-bef0128e8b3e") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-7a6e-9b09-c11775cb07f0"), new Guid("019ece85-30ad-7042-b491-bef0128e8b3e") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-7bb6-b751-b4e58df5cda3"), new Guid("019ece85-30ad-7042-b491-bef0128e8b3e") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-7081-9e10-f63ca5c5833c"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-71a3-b32d-2eddd8b953ef"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-7252-966c-5e85038608e7"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-7289-a14d-090f988ca849"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-740e-9a2e-afee11b34979"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-7696-8fe3-f5edf1a1c02b"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-7743-a256-61730dcbc7a0"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-789d-a5a2-6eec2bba22ce"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-796e-897a-0657ce3d7014"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-7a6e-9b09-c11775cb07f0"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-7b6f-8155-c0b13fbcd6de"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-7bb6-b751-b4e58df5cda3"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-7bd4-8dc1-accc6b6a4c6f"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-7c90-b2bd-f54ca3d55627"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ece85-3268-7f17-8e7e-1bde323e2985"), new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598"), new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464") });

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ece85-3268-7081-9e10-f63ca5c5833c"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ece85-3268-71a3-b32d-2eddd8b953ef"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ece85-3268-7252-966c-5e85038608e7"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ece85-3268-7289-a14d-090f988ca849"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ece85-3268-740e-9a2e-afee11b34979"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ece85-3268-7696-8fe3-f5edf1a1c02b"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ece85-3268-7743-a256-61730dcbc7a0"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ece85-3268-789d-a5a2-6eec2bba22ce"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ece85-3268-796e-897a-0657ce3d7014"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ece85-3268-7a6e-9b09-c11775cb07f0"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ece85-3268-7b6f-8155-c0b13fbcd6de"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ece85-3268-7bb6-b751-b4e58df5cda3"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ece85-3268-7bd4-8dc1-accc6b6a4c6f"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ece85-3268-7c90-b2bd-f54ca3d55627"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ece85-3268-7f17-8e7e-1bde323e2985"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019ece85-30ad-7042-b491-bef0128e8b3e"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019ece85-30ad-76a8-9f2b-7e04a5dcb598"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("019ece85-30ad-7ada-94f1-c2844e5ae464"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019ece85-30ad-717e-9b67-32b826bcc65c"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019ece85-30ad-7412-88c2-a81a44c998fc"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019ece85-30ad-7504-a60f-00a6471bb3cc"));

            migrationBuilder.DropColumn(
                name: "view_count",
                table: "medias");

            migrationBuilder.AlterColumn<int>(
                name: "duration",
                table: "medias",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.InsertData(
                table: "permission_groups",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "sort_order", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019ec8a9-46be-7513-aab7-8d669d4101c3"), "rbac_group.admin", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5300), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "RBAC Management", 3, new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5298), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ec8a9-46be-78b2-9a4b-26385831c47c"), "auth_group", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5290), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "Auth", 1, new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5286), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ec8a9-46be-7f68-862b-5049f8fd3888"), "user_group", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5295), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "User", 2, new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5293), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_at", "created_by", "name", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019ec8a9-46be-7455-9c77-7b427c340899"), new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5027), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "admin", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5024), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ec8a9-46be-7cbd-ab33-260ffc78dd0c"), new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5035), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "user", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5033), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "avatar_url", "created_at", "created_by", "email", "external_id", "full_name", "lang", "password", "provider", "updated_at", "updated_by", "username" },
                values: new object[] { new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), null, new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5880), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "admin@chillhub.id.vn", null, "admin", 0, "AQAAAAIAACcQAAAAEJL3PEfuwNrQOTsclnmWeXII/9NzpgehrbMF6gOzBfg4BjsiMVqewvfP5/LtaNKj4w==", null, new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5876), new TimeSpan(0, 0, 0, 0, 0)), null, "admin" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "permission_group_id", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019ec8a9-4884-70e2-b433-fbf70e7c46bb"), "rbac.search_permissions", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5473), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "Search Permissions", new Guid("019ec8a9-46be-7513-aab7-8d669d4101c3"), new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5470), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ec8a9-4884-7150-9bd8-3dc984224d11"), "user.view_users", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5426), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "View Users", new Guid("019ec8a9-46be-7f68-862b-5049f8fd3888"), new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5423), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ec8a9-4884-729f-8b21-7c417ced5226"), "rbac.search_permission_groups", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5445), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "Search Permission Groups", new Guid("019ec8a9-46be-7513-aab7-8d669d4101c3"), new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5442), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ec8a9-4884-730f-adcc-73d7e98cd661"), "rbac.save_permission", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5468), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "Save Permissions", new Guid("019ec8a9-46be-7513-aab7-8d669d4101c3"), new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5464), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ec8a9-4884-7327-925e-bd09b30c3085"), "user.update", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5410), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "Update User's Details", new Guid("019ec8a9-46be-7f68-862b-5049f8fd3888"), new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5406), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ec8a9-4884-73d9-9082-aca578be0435"), "user.read", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5397), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "View User's Details", new Guid("019ec8a9-46be-7f68-862b-5049f8fd3888"), new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5379), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ec8a9-4884-75b1-bfa1-7e41ccdbc87e"), "rbac.save_permission_group", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5438), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "Save Permission Group", new Guid("019ec8a9-46be-7513-aab7-8d669d4101c3"), new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5434), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ec8a9-4884-75e6-8dbd-0cb45c575260"), "rbac.assign_role", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5479), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "Assign Roles", new Guid("019ec8a9-46be-7513-aab7-8d669d4101c3"), new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5476), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ec8a9-4884-7815-be34-e6e6a88dd275"), "rbac.search_roles", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5462), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "Search Roles", new Guid("019ec8a9-46be-7513-aab7-8d669d4101c3"), new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5458), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ec8a9-4884-78de-b473-fae27dea0e93"), "auth.logout", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5376), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "Logout", new Guid("019ec8a9-46be-78b2-9a4b-26385831c47c"), new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5372), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ec8a9-4884-79cd-9c89-84f847dc6e18"), "auth.login", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5365), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "Login", new Guid("019ec8a9-46be-78b2-9a4b-26385831c47c"), new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5318), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ec8a9-4884-7e30-84ef-4e42718943a5"), "user.create", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5404), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "Add New User", new Guid("019ec8a9-46be-7f68-862b-5049f8fd3888"), new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5400), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ec8a9-4884-7eea-9c6c-3dd988405222"), "rbac.save_role", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5455), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "Save Role", new Guid("019ec8a9-46be-7513-aab7-8d669d4101c3"), new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5448), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ec8a9-4884-7f3b-806f-4130795acf66"), "user.delete", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5420), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "Delete User", new Guid("019ec8a9-46be-7f68-862b-5049f8fd3888"), new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5417), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ec8a9-4884-7f82-8348-3215c4045e1f"), "auth.view_session", new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5432), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4"), "Get Session", new Guid("019ec8a9-46be-7f68-862b-5049f8fd3888"), new DateTimeOffset(new DateTime(2026, 6, 15, 0, 23, 17, 892, DateTimeKind.Unspecified).AddTicks(5429), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[] { new Guid("019ec8a9-46be-7455-9c77-7b427c340899"), new Guid("019ec8a9-46be-7ac6-9ee7-5795c1e53cb4") });

            migrationBuilder.InsertData(
                table: "role_permissions",
                columns: new[] { "permission_id", "role_id" },
                values: new object[,]
                {
                    { new Guid("019ec8a9-4884-70e2-b433-fbf70e7c46bb"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") },
                    { new Guid("019ec8a9-4884-7150-9bd8-3dc984224d11"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") },
                    { new Guid("019ec8a9-4884-729f-8b21-7c417ced5226"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") },
                    { new Guid("019ec8a9-4884-730f-adcc-73d7e98cd661"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") },
                    { new Guid("019ec8a9-4884-7327-925e-bd09b30c3085"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") },
                    { new Guid("019ec8a9-4884-73d9-9082-aca578be0435"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") },
                    { new Guid("019ec8a9-4884-75b1-bfa1-7e41ccdbc87e"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") },
                    { new Guid("019ec8a9-4884-75e6-8dbd-0cb45c575260"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") },
                    { new Guid("019ec8a9-4884-7815-be34-e6e6a88dd275"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") },
                    { new Guid("019ec8a9-4884-78de-b473-fae27dea0e93"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") },
                    { new Guid("019ec8a9-4884-79cd-9c89-84f847dc6e18"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") },
                    { new Guid("019ec8a9-4884-7e30-84ef-4e42718943a5"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") },
                    { new Guid("019ec8a9-4884-7eea-9c6c-3dd988405222"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") },
                    { new Guid("019ec8a9-4884-7f3b-806f-4130795acf66"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") },
                    { new Guid("019ec8a9-4884-7f82-8348-3215c4045e1f"), new Guid("019ec8a9-46be-7455-9c77-7b427c340899") },
                    { new Guid("019ec8a9-4884-7150-9bd8-3dc984224d11"), new Guid("019ec8a9-46be-7cbd-ab33-260ffc78dd0c") },
                    { new Guid("019ec8a9-4884-73d9-9082-aca578be0435"), new Guid("019ec8a9-46be-7cbd-ab33-260ffc78dd0c") },
                    { new Guid("019ec8a9-4884-78de-b473-fae27dea0e93"), new Guid("019ec8a9-46be-7cbd-ab33-260ffc78dd0c") },
                    { new Guid("019ec8a9-4884-79cd-9c89-84f847dc6e18"), new Guid("019ec8a9-46be-7cbd-ab33-260ffc78dd0c") },
                    { new Guid("019ec8a9-4884-7f82-8348-3215c4045e1f"), new Guid("019ec8a9-46be-7cbd-ab33-260ffc78dd0c") }
                });
        }
    }
}
