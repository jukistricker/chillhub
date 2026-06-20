using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace chillhub.Migrations
{
    /// <inheritdoc />
    public partial class MediaHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "is_first_login",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "media_histories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    media_id = table.Column<Guid>(type: "uuid", nullable: true),
                    progress = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media_histories", x => x.id);
                    //table.ForeignKey(
                    //    name: "FK_media_histories_medias_media_id",
                    //    column: x => x.media_id,
                    //    principalTable: "medias",
                    //    principalColumn: "id");
                    //table.ForeignKey(
                    //    name: "FK_media_histories_users_user_id",
                    //    column: x => x.user_id,
                    //    principalTable: "users",
                    //    principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "permission_groups",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "sort_order", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019ee492-437a-722b-a863-4004f5dd63a4"), "rbac_group.admin", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5460), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "RBAC Management", 3, new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5458), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-437a-7b6d-acdb-bc80f47e3804"), "auth_group", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5450), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "Auth", 1, new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5447), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-437a-7e75-92c7-8dfe993b92db"), "user_group", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5455), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "User", 2, new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5453), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_at", "created_by", "name", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019ee492-437a-798d-b2eb-716564ab3357"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5233), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "admin", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5231), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-437a-7b4c-8d51-9259bc6a23a8"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5240), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "user", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5239), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "avatar_url", "created_at", "created_by", "email", "external_id", "full_name", "is_first_login", "lang", "password", "provider", "updated_at", "updated_by", "username" },
                values: new object[] { new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), null, new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(6079), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "admin@chillhub.id.vn", null, "admin", false, 0, "AQAAAAIAACcQAAAAEJL3PEfuwNrQOTsclnmWeXII/9NzpgehrbMF6gOzBfg4BjsiMVqewvfP5/LtaNKj4w==", null, new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(6075), new TimeSpan(0, 0, 0, 0, 0)), null, "admin" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "permission_group_id", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019ee492-4553-70e6-b912-0e9a9a316e83"), "auth.login", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5526), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "Login", new Guid("019ee492-437a-7b6d-acdb-bc80f47e3804"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5476), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-4553-73b0-a5cb-72b82b9b250e"), "media.media.update_category", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5654), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "Update Category", new Guid("019ee492-437a-722b-a863-4004f5dd63a4"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5651), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-4553-7459-b7af-758c231df61b"), "user.create", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5564), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "Add New User", new Guid("019ee492-437a-7e75-92c7-8dfe993b92db"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5546), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-4553-745a-a5c0-a946c7dd99cc"), "user.view_users", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5588), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "View Users", new Guid("019ee492-437a-7e75-92c7-8dfe993b92db"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5585), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-4553-75bb-bcec-2544be5bcccf"), "rbac.save_permission_group", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5600), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "Save Permission Group", new Guid("019ee492-437a-722b-a863-4004f5dd63a4"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5597), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-4553-765f-9c12-0508f1c17c93"), "rbac.search_permission_groups", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5608), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "Search Permission Groups", new Guid("019ee492-437a-722b-a863-4004f5dd63a4"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5604), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-4553-7734-90f0-76227c22c772"), "auth.view_session", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5594), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "Get Session", new Guid("019ee492-437a-7e75-92c7-8dfe993b92db"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5591), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-4553-77d3-956b-59fed414e80e"), "user.read", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5543), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "View User's Details", new Guid("019ee492-437a-7e75-92c7-8dfe993b92db"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5539), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-4553-7b29-b5b6-6ad8ce8864e3"), "auth.logout", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5537), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "Logout", new Guid("019ee492-437a-7b6d-acdb-bc80f47e3804"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5533), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-4553-7b67-a02d-b79aae970c39"), "rbac.save_role", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5614), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "Save Role", new Guid("019ee492-437a-722b-a863-4004f5dd63a4"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5610), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-4553-7c0c-90ef-27cbf610a822"), "rbac.assign_role", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5642), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "Assign Roles", new Guid("019ee492-437a-722b-a863-4004f5dd63a4"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5639), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-4553-7c8f-accf-2120e5119604"), "user.delete", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5582), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "Delete User", new Guid("019ee492-437a-7e75-92c7-8dfe993b92db"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5579), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-4553-7cfb-8990-25ff62fd65df"), "user.update", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5571), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "Update User's Details", new Guid("019ee492-437a-7e75-92c7-8dfe993b92db"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5568), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-4553-7ef4-91ca-367ab189972a"), "media.create_category", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5648), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "Create Category", new Guid("019ee492-437a-722b-a863-4004f5dd63a4"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5645), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-4553-7f33-8fcb-134d97443ccd"), "rbac.search_permissions", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5636), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "Search Permissions", new Guid("019ee492-437a-722b-a863-4004f5dd63a4"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5633), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-4553-7fbf-a579-bdcee8437dfd"), "rbac.search_roles", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5625), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "Search Roles", new Guid("019ee492-437a-722b-a863-4004f5dd63a4"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5617), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019ee492-4553-7fc7-a292-f3493138756d"), "rbac.save_permission", new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5631), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"), "Save Permissions", new Guid("019ee492-437a-722b-a863-4004f5dd63a4"), new DateTimeOffset(new DateTime(2026, 6, 20, 10, 27, 31, 795, DateTimeKind.Unspecified).AddTicks(5627), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[] { new Guid("019ee492-437a-798d-b2eb-716564ab3357"), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1") });

            migrationBuilder.InsertData(
                table: "role_permissions",
                columns: new[] { "permission_id", "role_id" },
                values: new object[,]
                {
                    { new Guid("019ee492-4553-70e6-b912-0e9a9a316e83"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") },
                    { new Guid("019ee492-4553-73b0-a5cb-72b82b9b250e"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") },
                    { new Guid("019ee492-4553-7459-b7af-758c231df61b"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") },
                    { new Guid("019ee492-4553-745a-a5c0-a946c7dd99cc"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") },
                    { new Guid("019ee492-4553-75bb-bcec-2544be5bcccf"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") },
                    { new Guid("019ee492-4553-765f-9c12-0508f1c17c93"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") },
                    { new Guid("019ee492-4553-7734-90f0-76227c22c772"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") },
                    { new Guid("019ee492-4553-77d3-956b-59fed414e80e"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") },
                    { new Guid("019ee492-4553-7b29-b5b6-6ad8ce8864e3"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") },
                    { new Guid("019ee492-4553-7b67-a02d-b79aae970c39"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") },
                    { new Guid("019ee492-4553-7c0c-90ef-27cbf610a822"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") },
                    { new Guid("019ee492-4553-7c8f-accf-2120e5119604"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") },
                    { new Guid("019ee492-4553-7cfb-8990-25ff62fd65df"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") },
                    { new Guid("019ee492-4553-7ef4-91ca-367ab189972a"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") },
                    { new Guid("019ee492-4553-7f33-8fcb-134d97443ccd"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") },
                    { new Guid("019ee492-4553-7fbf-a579-bdcee8437dfd"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") },
                    { new Guid("019ee492-4553-7fc7-a292-f3493138756d"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") },
                    { new Guid("019ee492-4553-70e6-b912-0e9a9a316e83"), new Guid("019ee492-437a-7b4c-8d51-9259bc6a23a8") },
                    { new Guid("019ee492-4553-745a-a5c0-a946c7dd99cc"), new Guid("019ee492-437a-7b4c-8d51-9259bc6a23a8") },
                    { new Guid("019ee492-4553-7734-90f0-76227c22c772"), new Guid("019ee492-437a-7b4c-8d51-9259bc6a23a8") },
                    { new Guid("019ee492-4553-77d3-956b-59fed414e80e"), new Guid("019ee492-437a-7b4c-8d51-9259bc6a23a8") },
                    { new Guid("019ee492-4553-7b29-b5b6-6ad8ce8864e3"), new Guid("019ee492-437a-7b4c-8d51-9259bc6a23a8") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_media_histories_media_id",
                table: "media_histories",
                column: "media_id");

            migrationBuilder.CreateIndex(
                name: "IX_media_histories_user_id",
                table: "media_histories",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "media_histories");

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-70e6-b912-0e9a9a316e83"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-73b0-a5cb-72b82b9b250e"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-7459-b7af-758c231df61b"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-745a-a5c0-a946c7dd99cc"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-75bb-bcec-2544be5bcccf"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-765f-9c12-0508f1c17c93"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-7734-90f0-76227c22c772"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-77d3-956b-59fed414e80e"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-7b29-b5b6-6ad8ce8864e3"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-7b67-a02d-b79aae970c39"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-7c0c-90ef-27cbf610a822"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-7c8f-accf-2120e5119604"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-7cfb-8990-25ff62fd65df"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-7ef4-91ca-367ab189972a"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-7f33-8fcb-134d97443ccd"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-7fbf-a579-bdcee8437dfd"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-7fc7-a292-f3493138756d"), new Guid("019ee492-437a-798d-b2eb-716564ab3357") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-70e6-b912-0e9a9a316e83"), new Guid("019ee492-437a-7b4c-8d51-9259bc6a23a8") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-745a-a5c0-a946c7dd99cc"), new Guid("019ee492-437a-7b4c-8d51-9259bc6a23a8") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-7734-90f0-76227c22c772"), new Guid("019ee492-437a-7b4c-8d51-9259bc6a23a8") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-77d3-956b-59fed414e80e"), new Guid("019ee492-437a-7b4c-8d51-9259bc6a23a8") });

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019ee492-4553-7b29-b5b6-6ad8ce8864e3"), new Guid("019ee492-437a-7b4c-8d51-9259bc6a23a8") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { new Guid("019ee492-437a-798d-b2eb-716564ab3357"), new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1") });

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ee492-4553-70e6-b912-0e9a9a316e83"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ee492-4553-73b0-a5cb-72b82b9b250e"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ee492-4553-7459-b7af-758c231df61b"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ee492-4553-745a-a5c0-a946c7dd99cc"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ee492-4553-75bb-bcec-2544be5bcccf"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ee492-4553-765f-9c12-0508f1c17c93"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ee492-4553-7734-90f0-76227c22c772"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ee492-4553-77d3-956b-59fed414e80e"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ee492-4553-7b29-b5b6-6ad8ce8864e3"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ee492-4553-7b67-a02d-b79aae970c39"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ee492-4553-7c0c-90ef-27cbf610a822"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ee492-4553-7c8f-accf-2120e5119604"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ee492-4553-7cfb-8990-25ff62fd65df"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ee492-4553-7ef4-91ca-367ab189972a"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ee492-4553-7f33-8fcb-134d97443ccd"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ee492-4553-7fbf-a579-bdcee8437dfd"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019ee492-4553-7fc7-a292-f3493138756d"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019ee492-437a-798d-b2eb-716564ab3357"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019ee492-437a-7b4c-8d51-9259bc6a23a8"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("019ee492-437a-72f2-b5aa-d52c8d85e2e1"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019ee492-437a-722b-a863-4004f5dd63a4"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019ee492-437a-7b6d-acdb-bc80f47e3804"));

            migrationBuilder.DeleteData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019ee492-437a-7e75-92c7-8dfe993b92db"));

            migrationBuilder.DropColumn(
                name: "is_first_login",
                table: "users");

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
    }
}
