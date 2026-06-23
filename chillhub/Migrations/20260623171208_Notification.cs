using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chillhub.Migrations
{
    /// <inheritdoc />
    public partial class Notification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_at",
                table: "users",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_at",
                table: "roles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_at",
                table: "permissions",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_at",
                table: "permission_groups",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_at",
                table: "medias",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_at",
                table: "media_histories",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_at",
                table: "categories",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateTable(
                name: "user_notifications",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    media_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    thumbnail = table.Column<string>(type: "text", nullable: false),
                    is_read = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_notifications", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-7238-aad7-74e3c7d0aa5d"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 395, DateTimeKind.Unspecified).AddTicks(9962), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-72a8-bb2e-cde54dc0f0ae"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 395, DateTimeKind.Unspecified).AddTicks(8713), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-74ad-bd0b-dcc44f4d0e63"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 395, DateTimeKind.Unspecified).AddTicks(9956), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-714e-a4a5-65b7618479d0"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 396, DateTimeKind.Unspecified).AddTicks(2023), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7443-97b5-a1cb8fff24f5"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 396, DateTimeKind.Unspecified).AddTicks(2058), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-74f9-b319-7cb58f050238"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 396, DateTimeKind.Unspecified).AddTicks(2114), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7638-a730-8199fc197a58"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 396, DateTimeKind.Unspecified).AddTicks(2118), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-778e-ae06-f9818fbca912"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 396, DateTimeKind.Unspecified).AddTicks(2053), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-794c-810b-78aa25c6a3af"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 396, DateTimeKind.Unspecified).AddTicks(949), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-79e1-aa4d-5fdb20386a3a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 396, DateTimeKind.Unspecified).AddTicks(2037), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7dc5-8971-05b0664f7cbc"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 396, DateTimeKind.Unspecified).AddTicks(2042), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7e77-8537-70d11bbbaeb5"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 396, DateTimeKind.Unspecified).AddTicks(2032), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7007-bb65-1eca5d5baa4b"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 396, DateTimeKind.Unspecified).AddTicks(2153), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7175-a2d2-1b8f0b06791a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 396, DateTimeKind.Unspecified).AddTicks(2149), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7208-831d-00b76a0ca679"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 396, DateTimeKind.Unspecified).AddTicks(2125), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-72ee-a00d-dc1e3f02fae6"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 396, DateTimeKind.Unspecified).AddTicks(2144), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-731f-bdc6-037a645e66c2"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 396, DateTimeKind.Unspecified).AddTicks(2157), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-773f-b37b-65f8db97edf2"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 396, DateTimeKind.Unspecified).AddTicks(2134), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-77c2-afef-01e092e22359"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 396, DateTimeKind.Unspecified).AddTicks(2140), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7b05-9a0d-d4a3576e908a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 396, DateTimeKind.Unspecified).AddTicks(2130), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 394, DateTimeKind.Unspecified).AddTicks(3816), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-75a5-b4dc-ed6e00d0b41a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 394, DateTimeKind.Unspecified).AddTicks(8672), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(2026, 6, 23, 17, 12, 5, 397, DateTimeKind.Unspecified).AddTicks(4635), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_notifications");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_at",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_at",
                table: "roles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_at",
                table: "permissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_at",
                table: "permission_groups",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_at",
                table: "medias",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_at",
                table: "media_histories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "updated_at",
                table: "categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-7238-aad7-74e3c7d0aa5d"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-72a8-bb2e-cde54dc0f0ae"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permission_groups",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-74ad-bd0b-dcc44f4d0e63"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-714e-a4a5-65b7618479d0"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7443-97b5-a1cb8fff24f5"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-74f9-b319-7cb58f050238"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7638-a730-8199fc197a58"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-778e-ae06-f9818fbca912"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-794c-810b-78aa25c6a3af"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-79e1-aa4d-5fdb20386a3a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7dc5-8971-05b0664f7cbc"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7e77-8537-70d11bbbaeb5"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7007-bb65-1eca5d5baa4b"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7175-a2d2-1b8f0b06791a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7208-831d-00b76a0ca679"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-72ee-a00d-dc1e3f02fae6"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-731f-bdc6-037a645e66c2"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-773f-b37b-65f8db97edf2"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-77c2-afef-01e092e22359"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cd-7b05-9a0d-d4a3576e908a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9ba-7c95-bff5-2f166b4e0112"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cb-75a5-b4dc-ed6e00d0b41a"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("019eed25-b9cc-7b05-b21b-f4c3f68c9d06"),
                column: "updated_at",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
