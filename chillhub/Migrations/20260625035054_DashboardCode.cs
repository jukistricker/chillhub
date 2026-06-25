using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chillhub.Migrations
{
    /// <inheritdoc />
    public partial class DashboardCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movie_ratings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    movie_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rating_count = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie_ratings", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-7238-aad7-74e3c7d0aa5d"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(5838), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-72a8-bb2e-cde54dc0f0ae"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(4668), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-74ad-bd0b-dcc44f4d0e63"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(5779), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-714e-a4a5-65b7618479d0"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(9430), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7443-97b5-a1cb8fff24f5"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(9466), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-74f9-b319-7cb58f050238"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(9470), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7638-a730-8199fc197a58"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(9474), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-778e-ae06-f9818fbca912"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(9462), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-794c-810b-78aa25c6a3af"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(6943), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-79e1-aa4d-5fdb20386a3a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(9446), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7dc5-8971-05b0664f7cbc"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(9451), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7e77-8537-70d11bbbaeb5"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(9441), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7007-bb65-1eca5d5baa4b"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(9553), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7175-a2d2-1b8f0b06791a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(9548), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7208-831d-00b76a0ca679"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(9527), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-72ee-a00d-dc1e3f02fae6"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(9544), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-731f-bdc6-037a645e66c2"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(9557), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-773f-b37b-65f8db97edf2"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(9536), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-77c2-afef-01e092e22359"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(9540), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7b05-9a0d-d4a3576e908a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(9531), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "code", "created_at", "created_by", "name", "permission_group_id", "updated_at", "updated_by" },
                values: new object[] { new Guid("019efce4-bbe7-72cc-b9f3-148451491a87"), "admin.dashboard", new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"), "Admin Dashboard", new Guid("019eed25-b9cb-7238-aad7-74e3c7d0aa5d"), new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 544, DateTimeKind.Unspecified).AddTicks(9563), new TimeSpan(0, 0, 0, 0, 0)), null });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 542, DateTimeKind.Unspecified).AddTicks(7746), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-75a5-b4dc-ed6e00d0b41a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 543, DateTimeKind.Unspecified).AddTicks(3588), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 25, 3, 50, 53, 546, DateTimeKind.Unspecified).AddTicks(3227), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "role_permissions",
                columns: new[] { "permission_id", "role_id" },
                values: new object[] { new Guid("019efce4-bbe7-72cc-b9f3-148451491a87"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") });

            migrationBuilder.CreateIndex(
                name: "IX_movie_ratings_movie_id_user_id",
                table: "movie_ratings",
                columns: new[] { "movie_id", "user_id" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_subscribers_users_channel_id",
                table: "subscribers",
                column: "channel_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subscribers_users_channel_id",
                table: "subscribers");

            migrationBuilder.DropTable(
                name: "movie_ratings");

            migrationBuilder.DeleteData(
                table: "role_permissions",
                keyColumns: new[] { "permission_id", "role_id" },
                keyValues: new object[] { new Guid("019efce4-bbe7-72cc-b9f3-148451491a87"), new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112") });

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019efce4-bbe7-72cc-b9f3-148451491a87"));

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
        }
    }
}
