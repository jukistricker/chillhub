using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace chillhub.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dashboard", x => x.id);
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
                name: "medias",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    thumbnail = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    duration = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    like_count = table.Column<long>(type: "bigint", nullable: false),
                    dislike_count = table.Column<long>(type: "bigint", nullable: false),
                    overall_rating = table.Column<float>(type: "real", nullable: true),
                    media_status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medias", x => x.id);
                    table.ForeignKey(
                        name: "FK_medias_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "media_categories",
                columns: table => new
                {
                    media_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media_categories", x => new { x.media_id, x.category_id });
                    table.ForeignKey(
                        name: "FK_media_categories_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_media_categories_medias_media_id",
                        column: x => x.media_id,
                        principalTable: "medias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_media_categories_category_id",
                table: "media_categories",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_medias_user_id",
                table: "medias",
                column: "user_id");

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
                name: "dashboard");

            migrationBuilder.DropTable(
                name: "media_categories");

            migrationBuilder.DropTable(
                name: "role_permissions");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "medias");

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
