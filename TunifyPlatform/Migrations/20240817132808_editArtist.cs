using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class editArtist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "Created_Date",
                value: new DateTime(2024, 8, 17, 16, 28, 8, 321, DateTimeKind.Local).AddTicks(1763));

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 2,
                column: "Created_Date",
                value: new DateTime(2024, 8, 17, 16, 28, 8, 321, DateTimeKind.Local).AddTicks(1765));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 1,
                column: "Join_Date",
                value: new DateTime(2024, 8, 17, 16, 28, 8, 321, DateTimeKind.Local).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 2,
                column: "Join_Date",
                value: new DateTime(2024, 8, 17, 16, 28, 8, 321, DateTimeKind.Local).AddTicks(1751));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "Created_Date",
                value: new DateTime(2024, 8, 16, 17, 54, 6, 394, DateTimeKind.Local).AddTicks(7445));

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 2,
                column: "Created_Date",
                value: new DateTime(2024, 8, 16, 17, 54, 6, 394, DateTimeKind.Local).AddTicks(7447));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 1,
                column: "Join_Date",
                value: new DateTime(2024, 8, 16, 17, 54, 6, 394, DateTimeKind.Local).AddTicks(7410));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 2,
                column: "Join_Date",
                value: new DateTime(2024, 8, 16, 17, 54, 6, 394, DateTimeKind.Local).AddTicks(7428));
        }
    }
}
