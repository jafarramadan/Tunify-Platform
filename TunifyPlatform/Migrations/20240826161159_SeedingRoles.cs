using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class SeedingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admin", "00000000-0000-0000-0000-000000000000", "Admin", "ADMIN" },
                    { "user", "00000000-0000-0000-0000-000000000000", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "Created_Date",
                value: new DateTime(2024, 8, 26, 19, 11, 58, 879, DateTimeKind.Local).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 2,
                column: "Created_Date",
                value: new DateTime(2024, 8, 26, 19, 11, 58, 879, DateTimeKind.Local).AddTicks(9496));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 1,
                column: "Join_Date",
                value: new DateTime(2024, 8, 26, 19, 11, 58, 879, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 2,
                column: "Join_Date",
                value: new DateTime(2024, 8, 26, 19, 11, 58, 879, DateTimeKind.Local).AddTicks(9477));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user");

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "Created_Date",
                value: new DateTime(2024, 8, 21, 16, 52, 8, 481, DateTimeKind.Local).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 2,
                column: "Created_Date",
                value: new DateTime(2024, 8, 21, 16, 52, 8, 481, DateTimeKind.Local).AddTicks(8031));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 1,
                column: "Join_Date",
                value: new DateTime(2024, 8, 21, 16, 52, 8, 481, DateTimeKind.Local).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 2,
                column: "Join_Date",
                value: new DateTime(2024, 8, 21, 16, 52, 8, 481, DateTimeKind.Local).AddTicks(8012));
        }
    }
}
