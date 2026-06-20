using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace chillhub.Migrations
{
    /// <inheritdoc />
    public partial class FolderId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "folder_id",
                table: "medias",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "permission_groups",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "sort_order", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019edb50-40c7-7109-9bbb-96387b8c213a"), "auth_group", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7598), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "Auth", 1, new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7594), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019edb50-40c7-7158-a0cd-8b5f26e9fc65"), "rbac_group.admin", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7608), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "RBAC Management", 3, new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7606), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019edb50-40c7-77ef-a98d-c68bcc301ba0"), "user_group", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7603), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "User", 2, new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7601), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_at", "created_by", "name", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019edb50-40c7-7150-b1ea-641086199b58"), new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7400), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "user", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7399), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159"), new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7394), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "admin", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7391), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "avatar_url", "created_at", "created_by", "email", "external_id", "full_name", "lang", "password", "provider", "updated_at", "updated_by", "username" },
                values: new object[] { new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), null, new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(8267), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "admin@chillhub.id.vn", null, "admin", 0, "AQAAAAIAACcQAAAAEJL3PEfuwNrQOTsclnmWeXII/9NzpgehrbMF6gOzBfg4BjsiMVqewvfP5/LtaNKj4w==", null, new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(8262), new TimeSpan(0, 0, 0, 0, 0)), null, "admin" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "permission_group_id", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019edb50-4285-71c1-ad15-1bf2b42e0325"), "user.view_users", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7733), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "View Users", new Guid("019edb50-40c7-77ef-a98d-c68bcc301ba0"), new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7730), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019edb50-4285-7497-823d-2cc04576f88b"), "auth.logout", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7684), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "Logout", new Guid("019edb50-40c7-7109-9bbb-96387b8c213a"), new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7679), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019edb50-4285-754f-8900-b4be6bc61e6b"), "rbac.save_permission", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7774), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "Save Permissions", new Guid("019edb50-40c7-7158-a0cd-8b5f26e9fc65"), new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7766), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019edb50-4285-7633-8e98-abb9736248a9"), "rbac.assign_role", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7785), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "Assign Roles", new Guid("019edb50-40c7-7158-a0cd-8b5f26e9fc65"), new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7782), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019edb50-4285-791b-8c98-940a39daf07e"), "user.create", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7696), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "Add New User", new Guid("019edb50-40c7-77ef-a98d-c68bcc301ba0"), new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7693), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019edb50-4285-7a05-a769-248efecfea40"), "rbac.search_permission_groups", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7752), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "Search Permission Groups", new Guid("019edb50-40c7-7158-a0cd-8b5f26e9fc65"), new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7749), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019edb50-4285-7a88-9e7f-e7ed9df1f997"), "rbac.save_permission_group", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7745), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "Save Permission Group", new Guid("019edb50-40c7-7158-a0cd-8b5f26e9fc65"), new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7742), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019edb50-4285-7bac-b441-e6bb5b2be127"), "rbac.save_role", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7758), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "Save Role", new Guid("019edb50-40c7-7158-a0cd-8b5f26e9fc65"), new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7755), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019edb50-4285-7c4a-8752-463a87cec46b"), "user.read", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7690), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "View User's Details", new Guid("019edb50-40c7-77ef-a98d-c68bcc301ba0"), new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7687), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019edb50-4285-7d91-88db-ea77cf84c88d"), "auth.login", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7673), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "Login", new Guid("019edb50-40c7-7109-9bbb-96387b8c213a"), new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7626), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019edb50-4285-7e79-8991-bbbc0de4bc0a"), "user.update", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7715), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "Update User's Details", new Guid("019edb50-40c7-77ef-a98d-c68bcc301ba0"), new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7699), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019edb50-4285-7e79-be3a-281072f32552"), "user.delete", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7727), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "Delete User", new Guid("019edb50-40c7-77ef-a98d-c68bcc301ba0"), new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7724), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019edb50-4285-7edf-904b-d406f3ae5b9e"), "auth.view_session", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7739), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "Get Session", new Guid("019edb50-40c7-77ef-a98d-c68bcc301ba0"), new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7736), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019edb50-4285-7ef0-ad15-2b3ae7e7cc6b"), "rbac.search_permissions", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7780), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "Search Permissions", new Guid("019edb50-40c7-7158-a0cd-8b5f26e9fc65"), new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7776), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019edb50-4285-7f0c-a635-dc69c4576d0b"), "rbac.search_roles", new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7764), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"), "Search Roles", new Guid("019edb50-40c7-7158-a0cd-8b5f26e9fc65"), new DateTimeOffset(new DateTime(2026, 6, 18, 15, 18, 50, 757, DateTimeKind.Unspecified).AddTicks(7761), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[] { new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159"), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5") });

            migrationBuilder.InsertData(
                table: "role_permissions",
                columns: new[] { "permission_id", "role_id" },
                values: new object[,]
                {
                    { new Guid("019edb50-4285-71c1-ad15-1bf2b42e0325"), new Guid("019edb50-40c7-7150-b1ea-641086199b58") },
                    { new Guid("019edb50-4285-7497-823d-2cc04576f88b"), new Guid("019edb50-40c7-7150-b1ea-641086199b58") },
                    { new Guid("019edb50-4285-7c4a-8752-463a87cec46b"), new Guid("019edb50-40c7-7150-b1ea-641086199b58") },
                    { new Guid("019edb50-4285-7d91-88db-ea77cf84c88d"), new Guid("019edb50-40c7-7150-b1ea-641086199b58") },
                    { new Guid("019edb50-4285-7edf-904b-d406f3ae5b9e"), new Guid("019edb50-40c7-7150-b1ea-641086199b58") },
                    { new Guid("019edb50-4285-71c1-ad15-1bf2b42e0325"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") },
                    { new Guid("019edb50-4285-7497-823d-2cc04576f88b"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") },
                    { new Guid("019edb50-4285-754f-8900-b4be6bc61e6b"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") },
                    { new Guid("019edb50-4285-7633-8e98-abb9736248a9"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") },
                    { new Guid("019edb50-4285-791b-8c98-940a39daf07e"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") },
                    { new Guid("019edb50-4285-7a05-a769-248efecfea40"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") },
                    { new Guid("019edb50-4285-7a88-9e7f-e7ed9df1f997"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") },
                    { new Guid("019edb50-4285-7bac-b441-e6bb5b2be127"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") },
                    { new Guid("019edb50-4285-7c4a-8752-463a87cec46b"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") },
                    { new Guid("019edb50-4285-7d91-88db-ea77cf84c88d"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") },
                    { new Guid("019edb50-4285-7e79-8991-bbbc0de4bc0a"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") },
                    { new Guid("019edb50-4285-7e79-be3a-281072f32552"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") },
                    { new Guid("019edb50-4285-7edf-904b-d406f3ae5b9e"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") },
                    { new Guid("019edb50-4285-7ef0-ad15-2b3ae7e7cc6b"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") },
                    { new Guid("019edb50-4285-7f0c-a635-dc69c4576d0b"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-71c1-ad15-1bf2b42e0325"), new Guid("019edb50-40c7-7150-b1ea-641086199b58") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-7497-823d-2cc04576f88b"), new Guid("019edb50-40c7-7150-b1ea-641086199b58") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-7c4a-8752-463a87cec46b"), new Guid("019edb50-40c7-7150-b1ea-641086199b58") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-7d91-88db-ea77cf84c88d"), new Guid("019edb50-40c7-7150-b1ea-641086199b58") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-7edf-904b-d406f3ae5b9e"), new Guid("019edb50-40c7-7150-b1ea-641086199b58") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-71c1-ad15-1bf2b42e0325"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-7497-823d-2cc04576f88b"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-754f-8900-b4be6bc61e6b"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-7633-8e98-abb9736248a9"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-791b-8c98-940a39daf07e"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-7a05-a769-248efecfea40"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-7a88-9e7f-e7ed9df1f997"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-7bac-b441-e6bb5b2be127"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-7c4a-8752-463a87cec46b"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-7d91-88db-ea77cf84c88d"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-7e79-8991-bbbc0de4bc0a"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-7e79-be3a-281072f32552"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-7edf-904b-d406f3ae5b9e"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-7ef0-ad15-2b3ae7e7cc6b"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019edb50-4285-7f0c-a635-dc69c4576d0b"), new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159"), new Guid("019edb50-40c7-79d8-835d-dae47469b4f5") });

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019edb50-4285-71c1-ad15-1bf2b42e0325"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019edb50-4285-7497-823d-2cc04576f88b"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019edb50-4285-754f-8900-b4be6bc61e6b"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019edb50-4285-7633-8e98-abb9736248a9"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019edb50-4285-791b-8c98-940a39daf07e"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019edb50-4285-7a05-a769-248efecfea40"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019edb50-4285-7a88-9e7f-e7ed9df1f997"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019edb50-4285-7bac-b441-e6bb5b2be127"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019edb50-4285-7c4a-8752-463a87cec46b"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019edb50-4285-7d91-88db-ea77cf84c88d"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019edb50-4285-7e79-8991-bbbc0de4bc0a"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019edb50-4285-7e79-be3a-281072f32552"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019edb50-4285-7edf-904b-d406f3ae5b9e"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019edb50-4285-7ef0-ad15-2b3ae7e7cc6b"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019edb50-4285-7f0c-a635-dc69c4576d0b"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019edb50-40c7-7150-b1ea-641086199b58"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019edb50-40c7-7d5e-9a20-1ff76a9a7159"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("019edb50-40c7-79d8-835d-dae47469b4f5"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019edb50-40c7-7109-9bbb-96387b8c213a"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019edb50-40c7-7158-a0cd-8b5f26e9fc65"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019edb50-40c7-77ef-a98d-c68bcc301ba0"));

            migrationBuilder.DropColumn(
                name: "folder_id",
                table: "medias");

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
    }
}
