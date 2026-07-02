using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chillhub.Migrations
{
    /// <inheritdoc />
    public partial class CommentAndRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    entity_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reference_comment_id = table.Column<Guid>(type: "uuid", nullable: true),
                    has_children = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_comments_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-7238-aad7-74e3c7d0aa5d"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(6994), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-72a8-bb2e-cde54dc0f0ae"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(5650), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-74ad-bd0b-dcc44f4d0e63"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(6988), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-714e-a4a5-65b7618479d0"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(9255), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7443-97b5-a1cb8fff24f5"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(9387), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-74f9-b319-7cb58f050238"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(9391), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7638-a730-8199fc197a58"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(9396), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-778e-ae06-f9818fbca912"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(9382), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-794c-810b-78aa25c6a3af"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(8154), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-79e1-aa4d-5fdb20386a3a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(9362), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7dc5-8971-05b0664f7cbc"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(9368), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7e77-8537-70d11bbbaeb5"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(9265), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7007-bb65-1eca5d5baa4b"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(9460), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7175-a2d2-1b8f0b06791a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(9455), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7208-831d-00b76a0ca679"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(9402), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-72ee-a00d-dc1e3f02fae6"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(9451), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-731f-bdc6-037a645e66c2"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(9465), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-773f-b37b-65f8db97edf2"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(9442), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-77c2-afef-01e092e22359"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(9447), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7b05-9a0d-d4a3576e908a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 543, DateTimeKind.Unspecified).AddTicks(9438), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 542, DateTimeKind.Unspecified).AddTicks(1425), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-75a5-b4dc-ed6e00d0b41a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 542, DateTimeKind.Unspecified).AddTicks(5971), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 24, 21, 4, 7, 545, DateTimeKind.Unspecified).AddTicks(522), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_comments_user_id",
                table: "comments",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.UpdateData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-7238-aad7-74e3c7d0aa5d"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(5473), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-72a8-bb2e-cde54dc0f0ae"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(4061), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-74ad-bd0b-dcc44f4d0e63"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(5468), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-714e-a4a5-65b7618479d0"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(8053), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7443-97b5-a1cb8fff24f5"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(8229), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-74f9-b319-7cb58f050238"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(8234), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7638-a730-8199fc197a58"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(8238), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-778e-ae06-f9818fbca912"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(8224), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-794c-810b-78aa25c6a3af"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(6967), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-79e1-aa4d-5fdb20386a3a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(8205), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7dc5-8971-05b0664f7cbc"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(8209), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7e77-8537-70d11bbbaeb5"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(8165), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7007-bb65-1eca5d5baa4b"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(8270), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7175-a2d2-1b8f0b06791a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(8266), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7208-831d-00b76a0ca679"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(8244), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-72ee-a00d-dc1e3f02fae6"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(8261), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-731f-bdc6-037a645e66c2"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(8274), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-773f-b37b-65f8db97edf2"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(8253), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-77c2-afef-01e092e22359"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(8257), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7b05-9a0d-d4a3576e908a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 408, DateTimeKind.Unspecified).AddTicks(8249), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 406, DateTimeKind.Unspecified).AddTicks(8715), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-75a5-b4dc-ed6e00d0b41a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 407, DateTimeKind.Unspecified).AddTicks(3710), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 25, 58, 410, DateTimeKind.Unspecified).AddTicks(1332), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
