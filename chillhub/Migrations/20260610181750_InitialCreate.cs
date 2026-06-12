using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace chillhub.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dashboard",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    users_count = table.Column<int>(type: "integer", nullable: false),
                    roles_count = table.Column<int>(type: "integer", nullable: false),
                    permissions_count = table.Column<int>(type: "integer", nullable: false),
                    permission_groups_count = table.Column<int>(type: "integer", nullable: false),
                    medias_count = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dashboard", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "medias",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    thumbnail = table.Column<string>(type: "text", nullable: true),
                    duration = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    like_count = table.Column<long>(type: "bigint", nullable: false),
                    dislike_count = table.Column<long>(type: "bigint", nullable: false),
                    overall_rating = table.Column<float>(type: "real", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permission_groups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    sort_order = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission_groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    password = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    full_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    avatar_url = table.Column<string>(type: "text", nullable: true),
                    provider = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    external_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    lang = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    code = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    permission_group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.id);
                    table.ForeignKey(
                        name: "FK_permissions_permission_groups_permission_group_id",
                        column: x => x.permission_group_id,
                        principalTable: "permission_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_user_roles_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_roles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "role_permissions",
                columns: table => new
                {
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    permission_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_permissions", x => new { x.role_id, x.permission_id });
                    table.ForeignKey(
                        name: "FK_role_permissions_permissions_permission_id",
                        column: x => x.permission_id,
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_role_permissions_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_permission_groups_code",
                table: "permission_groups",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissions_code",
                table: "permissions",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissions_permission_group_id",
                table: "permissions",
                column: "permission_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_permissions_permission_id",
                table: "role_permissions",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_roles_name",
                table: "roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_role_id",
                table: "user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_username",
                table: "users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "dashboard");

            migrationBuilder.DropTable(
                name: "medias");

            migrationBuilder.DropTable(
                name: "role_permissions");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "permission_groups");
        }
    }
}
