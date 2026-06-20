using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace chillhub.Migrations
{
    /// <inheritdoc />
    public partial class AlterMedia2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "permission_groups",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "sort_order", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019ecede-a234-70e9-aeee-42e6f84927c2"), "user_group", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6472), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "User", 2, new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6469), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ecede-a234-7244-bbfa-e154d0e64613"), "rbac_group.admin", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6477), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "RBAC Management", 3, new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6475), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ecede-a234-7a57-9326-10c4887fd084"), "auth_group", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6465), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "Auth", 1, new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6462), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_at", "created_by", "name", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba"), new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6248), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "admin", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6246), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ecede-a234-7db3-bf6d-878a250b1cfb"), new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6255), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "user", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6254), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "avatar_url", "created_at", "created_by", "email", "external_id", "full_name", "lang", "password", "provider", "updated_at", "updated_by", "username" },
                values: new object[] { new Guid("019ecede-a234-722a-8629-25510beaa97f"), null, new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(7067), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "admin@chillhub.id.vn", null, "admin", 0, "AQAAAAIAACcQAAAAEJL3PEfuwNrQOTsclnmWeXII/9NzpgehrbMF6gOzBfg4BjsiMVqewvfP5/LtaNKj4w==", null, new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(7062), new TimeSpan(0, 0, 0, 0, 0)), null, "admin" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "permission_group_id", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019ecede-a45b-7240-beb9-7f1734b0ad07"), "rbac.search_permissions", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6654), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "Search Permissions", new Guid("019ecede-a234-7244-bbfa-e154d0e64613"), new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6646), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ecede-a45b-7305-b2d6-09fd9c114140"), "user.delete", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6598), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "Delete User", new Guid("019ecede-a234-70e9-aeee-42e6f84927c2"), new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6579), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ecede-a45b-74cb-8f13-dc716549d2e8"), "auth.login", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6538), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "Login", new Guid("019ecede-a234-7a57-9326-10c4887fd084"), new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6497), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ecede-a45b-760f-8d16-be2c03c7af61"), "rbac.save_permission_group", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6617), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "Save Permission Group", new Guid("019ecede-a234-7244-bbfa-e154d0e64613"), new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6613), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ecede-a45b-7769-ad76-8543f6ec20f2"), "auth.view_session", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6610), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "Get Session", new Guid("019ecede-a234-70e9-aeee-42e6f84927c2"), new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6607), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ecede-a45b-7873-a253-5c0f2d8aacd4"), "user.create", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6564), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "Add New User", new Guid("019ecede-a234-70e9-aeee-42e6f84927c2"), new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6560), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ecede-a45b-7a8c-8cb6-593e8d471561"), "user.view_users", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6604), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "View Users", new Guid("019ecede-a234-70e9-aeee-42e6f84927c2"), new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6601), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ecede-a45b-7a9f-9e9b-53c9d3bec744"), "user.update", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6570), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "Update User's Details", new Guid("019ecede-a234-70e9-aeee-42e6f84927c2"), new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6567), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ecede-a45b-7bcf-8965-9b4be2756962"), "rbac.assign_role", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6661), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "Assign Roles", new Guid("019ecede-a234-7244-bbfa-e154d0e64613"), new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6657), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ecede-a45b-7c1f-b68c-d5f5e17c0816"), "rbac.search_roles", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6637), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "Search Roles", new Guid("019ecede-a234-7244-bbfa-e154d0e64613"), new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6634), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ecede-a45b-7c82-86f9-2b6215320d01"), "auth.logout", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6550), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "Logout", new Guid("019ecede-a234-7a57-9326-10c4887fd084"), new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6545), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ecede-a45b-7cc3-aa43-f788774c3782"), "user.read", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6558), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "View User's Details", new Guid("019ecede-a234-70e9-aeee-42e6f84927c2"), new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6553), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ecede-a45b-7e09-b816-103e78db06bd"), "rbac.save_permission", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6643), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "Save Permissions", new Guid("019ecede-a234-7244-bbfa-e154d0e64613"), new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6640), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ecede-a45b-7f3a-8118-8eca2b14240f"), "rbac.save_role", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6631), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "Save Role", new Guid("019ecede-a234-7244-bbfa-e154d0e64613"), new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6628), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ecede-a45b-7f5f-b56c-ae00c9389fa4"), "rbac.search_permission_groups", new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6625), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ecede-a234-722a-8629-25510beaa97f"), "Search Permission Groups", new Guid("019ecede-a234-7244-bbfa-e154d0e64613"), new DateTimeOffset(new DateTime(2026, 6, 16, 5, 19, 18, 107, DateTimeKind.Unspecified).AddTicks(6621), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[] { new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba"), new Guid("019ecede-a234-722a-8629-25510beaa97f") });

            migrationBuilder.InsertData(
                table: "role_permissions",
                columns: new[] { "permission_id", "role_id" },
                values: new object[,]
                {
                    { new Guid("019ecede-a45b-7240-beb9-7f1734b0ad07"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") },
                    { new Guid("019ecede-a45b-7305-b2d6-09fd9c114140"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") },
                    { new Guid("019ecede-a45b-74cb-8f13-dc716549d2e8"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") },
                    { new Guid("019ecede-a45b-760f-8d16-be2c03c7af61"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") },
                    { new Guid("019ecede-a45b-7769-ad76-8543f6ec20f2"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") },
                    { new Guid("019ecede-a45b-7873-a253-5c0f2d8aacd4"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") },
                    { new Guid("019ecede-a45b-7a8c-8cb6-593e8d471561"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") },
                    { new Guid("019ecede-a45b-7a9f-9e9b-53c9d3bec744"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") },
                    { new Guid("019ecede-a45b-7bcf-8965-9b4be2756962"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") },
                    { new Guid("019ecede-a45b-7c1f-b68c-d5f5e17c0816"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") },
                    { new Guid("019ecede-a45b-7c82-86f9-2b6215320d01"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") },
                    { new Guid("019ecede-a45b-7cc3-aa43-f788774c3782"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") },
                    { new Guid("019ecede-a45b-7e09-b816-103e78db06bd"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") },
                    { new Guid("019ecede-a45b-7f3a-8118-8eca2b14240f"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") },
                    { new Guid("019ecede-a45b-7f5f-b56c-ae00c9389fa4"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") },
                    { new Guid("019ecede-a45b-74cb-8f13-dc716549d2e8"), new Guid("019ecede-a234-7db3-bf6d-878a250b1cfb") },
                    { new Guid("019ecede-a45b-7769-ad76-8543f6ec20f2"), new Guid("019ecede-a234-7db3-bf6d-878a250b1cfb") },
                    { new Guid("019ecede-a45b-7a8c-8cb6-593e8d471561"), new Guid("019ecede-a234-7db3-bf6d-878a250b1cfb") },
                    { new Guid("019ecede-a45b-7c82-86f9-2b6215320d01"), new Guid("019ecede-a234-7db3-bf6d-878a250b1cfb") },
                    { new Guid("019ecede-a45b-7cc3-aa43-f788774c3782"), new Guid("019ecede-a234-7db3-bf6d-878a250b1cfb") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-7240-beb9-7f1734b0ad07"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-7305-b2d6-09fd9c114140"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-74cb-8f13-dc716549d2e8"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-760f-8d16-be2c03c7af61"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-7769-ad76-8543f6ec20f2"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-7873-a253-5c0f2d8aacd4"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-7a8c-8cb6-593e8d471561"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-7a9f-9e9b-53c9d3bec744"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-7bcf-8965-9b4be2756962"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-7c1f-b68c-d5f5e17c0816"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-7c82-86f9-2b6215320d01"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-7cc3-aa43-f788774c3782"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-7e09-b816-103e78db06bd"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-7f3a-8118-8eca2b14240f"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-7f5f-b56c-ae00c9389fa4"), new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-74cb-8f13-dc716549d2e8"), new Guid("019ecede-a234-7db3-bf6d-878a250b1cfb") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-7769-ad76-8543f6ec20f2"), new Guid("019ecede-a234-7db3-bf6d-878a250b1cfb") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-7a8c-8cb6-593e8d471561"), new Guid("019ecede-a234-7db3-bf6d-878a250b1cfb") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-7c82-86f9-2b6215320d01"), new Guid("019ecede-a234-7db3-bf6d-878a250b1cfb") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ecede-a45b-7cc3-aa43-f788774c3782"), new Guid("019ecede-a234-7db3-bf6d-878a250b1cfb") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba"), new Guid("019ecede-a234-722a-8629-25510beaa97f") });

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a45b-7240-beb9-7f1734b0ad07"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a45b-7305-b2d6-09fd9c114140"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a45b-74cb-8f13-dc716549d2e8"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a45b-760f-8d16-be2c03c7af61"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a45b-7769-ad76-8543f6ec20f2"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a45b-7873-a253-5c0f2d8aacd4"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a45b-7a8c-8cb6-593e8d471561"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a45b-7a9f-9e9b-53c9d3bec744"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a45b-7bcf-8965-9b4be2756962"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a45b-7c1f-b68c-d5f5e17c0816"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a45b-7c82-86f9-2b6215320d01"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a45b-7cc3-aa43-f788774c3782"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a45b-7e09-b816-103e78db06bd"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a45b-7f3a-8118-8eca2b14240f"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a45b-7f5f-b56c-ae00c9389fa4"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a234-75f3-8b83-b941d7d7f1ba"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a234-7db3-bf6d-878a250b1cfb"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a234-722a-8629-25510beaa97f"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a234-70e9-aeee-42e6f84927c2"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a234-7244-bbfa-e154d0e64613"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019ecede-a234-7a57-9326-10c4887fd084"));

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
    }
}
