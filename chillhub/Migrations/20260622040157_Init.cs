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
                name: "media_reactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    media_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reaction_type = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media_reactions", x => x.id);
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
                name: "subscribers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    subscriber_id = table.Column<Guid>(type: "uuid", nullable: false),
                    channel_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_notice = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscribers", x => x.id);
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
                    is_first_login = table.Column<bool>(type: "boolean", nullable: false),
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
                    duration = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    like_count = table.Column<long>(type: "bigint", nullable: false),
                    dislike_count = table.Column<long>(type: "bigint", nullable: false),
                    overall_rating = table.Column<float>(type: "real", nullable: true),
                    media_status = table.Column<int>(type: "integer", nullable: false),
                    view_count = table.Column<long>(type: "bigint", nullable: false),
                    folder_id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_media_histories_medias_media_id",
                        column: x => x.media_id,
                        principalTable: "medias",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_media_histories_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "permission_groups",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "sort_order", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019eed25-b9cb-7238-aad7-74e3c7d0aa5d"), "rbac_group.admin", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "RBAC Management", 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cb-72a8-bb2e-cde54dc0f0ae"), "auth_group", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "Auth", 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cb-74ad-bd0b-dcc44f4d0e63"), "user_group", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "User", 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_at", "created_by", "name", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "admin", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cb-75a5-b4dc-ed6e00d0b41a"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "user", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "avatar_url", "created_at", "created_by", "email", "external_id", "full_name", "is_first_login", "lang", "password", "provider", "updated_at", "updated_by", "username" },
                values: new object[] { new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), null, new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "admin@chillhub.id.vn", null, "admin", false, 0, "AQAAAAIAACcQAAAAEJL3PEfuwNrQOTsclnmWeXII/9NzpgehrbMF6gOzBfg4BjsiMVqewvfP5/LtaNKj4w==", null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "admin" });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "permission_group_id", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("019eed25-b9cc-714e-a4a5-65b7618479d0"), "auth.logout", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "Logout", new Guid("019eed25-b9cb-72a8-bb2e-cde54dc0f0ae"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cc-7443-97b5-a1cb8fff24f5"), "user.view_users", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "View Users", new Guid("019eed25-b9cb-74ad-bd0b-dcc44f4d0e63"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cc-74f9-b319-7cb58f050238"), "auth.view_session", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "Get Session", new Guid("019eed25-b9cb-74ad-bd0b-dcc44f4d0e63"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cc-7638-a730-8199fc197a58"), "rbac.save_permission_group", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "Save Permission Group", new Guid("019eed25-b9cb-7238-aad7-74e3c7d0aa5d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cc-778e-ae06-f9818fbca912"), "user.delete", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "Delete User", new Guid("019eed25-b9cb-74ad-bd0b-dcc44f4d0e63"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cc-794c-810b-78aa25c6a3af"), "auth.login", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "Login", new Guid("019eed25-b9cb-72a8-bb2e-cde54dc0f0ae"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cc-79e1-aa4d-5fdb20386a3a"), "user.create", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "Add New User", new Guid("019eed25-b9cb-74ad-bd0b-dcc44f4d0e63"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cc-7dc5-8971-05b0664f7cbc"), "user.update", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "Update User's Details", new Guid("019eed25-b9cb-74ad-bd0b-dcc44f4d0e63"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cc-7e77-8537-70d11bbbaeb5"), "user.read", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "View User's Details", new Guid("019eed25-b9cb-74ad-bd0b-dcc44f4d0e63"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cd-7007-bb65-1eca5d5baa4b"), "media.create_category", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "Create Category", new Guid("019eed25-b9cb-7238-aad7-74e3c7d0aa5d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cd-7175-a2d2-1b8f0b06791a"), "rbac.assign_role", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "Assign Roles", new Guid("019eed25-b9cb-7238-aad7-74e3c7d0aa5d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cd-7208-831d-00b76a0ca679"), "rbac.search_permission_groups", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "Search Permission Groups", new Guid("019eed25-b9cb-7238-aad7-74e3c7d0aa5d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cd-72ee-a00d-dc1e3f02fae6"), "rbac.search_permissions", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "Search Permissions", new Guid("019eed25-b9cb-7238-aad7-74e3c7d0aa5d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cd-731f-bdc6-037a645e66c2"), "media.media.update_category", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "Update Category", new Guid("019eed25-b9cb-7238-aad7-74e3c7d0aa5d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cd-773f-b37b-65f8db97edf2"), "rbac.search_roles", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "Search Roles", new Guid("019eed25-b9cb-7238-aad7-74e3c7d0aa5d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cd-77c2-afef-01e092e22359"), "rbac.save_permission", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "Save Permissions", new Guid("019eed25-b9cb-7238-aad7-74e3c7d0aa5d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { new Guid("019eed25-b9cd-7b05-9a0d-d4a3576e908a"), "rbac.save_role", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "Save Role", new Guid("019eed25-b9cb-7238-aad7-74e3c7d0aa5d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[] { new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112"), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06") });

            migrationBuilder.InsertData(
                table: "role_permissions",
                columns: new[] { "permission_id", "role_id" },
                values: new object[,]
                {
                    { new Guid("019eed25-b9cc-714e-a4a5-65b7618479d0"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") },
                    { new Guid("019eed25-b9cc-7443-97b5-a1cb8fff24f5"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") },
                    { new Guid("019eed25-b9cc-74f9-b319-7cb58f050238"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") },
                    { new Guid("019eed25-b9cc-7638-a730-8199fc197a58"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") },
                    { new Guid("019eed25-b9cc-778e-ae06-f9818fbca912"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") },
                    { new Guid("019eed25-b9cc-794c-810b-78aa25c6a3af"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") },
                    { new Guid("019eed25-b9cc-79e1-aa4d-5fdb20386a3a"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") },
                    { new Guid("019eed25-b9cc-7dc5-8971-05b0664f7cbc"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") },
                    { new Guid("019eed25-b9cc-7e77-8537-70d11bbbaeb5"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") },
                    { new Guid("019eed25-b9cd-7007-bb65-1eca5d5baa4b"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") },
                    { new Guid("019eed25-b9cd-7175-a2d2-1b8f0b06791a"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") },
                    { new Guid("019eed25-b9cd-7208-831d-00b76a0ca679"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") },
                    { new Guid("019eed25-b9cd-72ee-a00d-dc1e3f02fae6"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") },
                    { new Guid("019eed25-b9cd-731f-bdc6-037a645e66c2"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") },
                    { new Guid("019eed25-b9cd-773f-b37b-65f8db97edf2"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") },
                    { new Guid("019eed25-b9cd-77c2-afef-01e092e22359"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") },
                    { new Guid("019eed25-b9cd-7b05-9a0d-d4a3576e908a"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") },
                    { new Guid("019eed25-b9cc-714e-a4a5-65b7618479d0"), new Guid("019eed25-b9cb-75a5-b4dc-ed6e00d0b41a") },
                    { new Guid("019eed25-b9cc-7443-97b5-a1cb8fff24f5"), new Guid("019eed25-b9cb-75a5-b4dc-ed6e00d0b41a") },
                    { new Guid("019eed25-b9cc-74f9-b319-7cb58f050238"), new Guid("019eed25-b9cb-75a5-b4dc-ed6e00d0b41a") },
                    { new Guid("019eed25-b9cc-794c-810b-78aa25c6a3af"), new Guid("019eed25-b9cb-75a5-b4dc-ed6e00d0b41a") },
                    { new Guid("019eed25-b9cc-7e77-8537-70d11bbbaeb5"), new Guid("019eed25-b9cb-75a5-b4dc-ed6e00d0b41a") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_media_categories_category_id",
                table: "media_categories",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_media_histories_media_id",
                table: "media_histories",
                column: "media_id");

            migrationBuilder.CreateIndex(
                name: "IX_media_histories_user_id_media_id",
                table: "media_histories",
                columns: new[] { "user_id", "media_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_media_reactions_user_id_media_id",
                table: "media_reactions",
                columns: new[] { "user_id", "media_id" },
                unique: true);

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
                name: "IX_subscribers_channel_id",
                table: "subscribers",
                column: "channel_id");

            migrationBuilder.CreateIndex(
                name: "IX_subscribers_channel_id_subscriber_id",
                table: "subscribers",
                columns: new[] { "channel_id", "subscriber_id" },
                filter: "\"is_notice\" = true");

            migrationBuilder.CreateIndex(
                name: "IX_subscribers_subscriber_id",
                table: "subscribers",
                column: "subscriber_id");

            migrationBuilder.CreateIndex(
                name: "IX_subscribers_subscriber_id_channel_id",
                table: "subscribers",
                columns: new[] { "subscriber_id", "channel_id" },
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
                name: "media_histories");

            migrationBuilder.DropTable(
                name: "media_reactions");

            migrationBuilder.DropTable(
                name: "role_permissions");

            migrationBuilder.DropTable(
                name: "subscribers");

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
