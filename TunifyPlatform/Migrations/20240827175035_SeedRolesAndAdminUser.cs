using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesAndAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -1393440924, "permission", "create", "admin" },
                    { 959871014, "permission", "update", "user" },
                    { 1599777385, "permission", "update", "admin" },
                    { 1628660409, "permission", "delete", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "admin_user_id", 0, "9de1341d-69ed-481d-86b8-42fbd5412acd", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEFsJORSASPyY4n6WbVyORhwEOrjannf8C2VDRm+LAvcn4Q/JzwIkY0oyhSaOF52lxA==", null, false, "85da6fb7-5678-47de-8e91-d921daf73322", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "Created_Date",
                value: new DateTime(2024, 8, 27, 20, 50, 35, 44, DateTimeKind.Local).AddTicks(3036));

            migrationBuilder.UpdateData(
                table: "Playlist",
                keyColumn: "PlaylistId",
                keyValue: 2,
                column: "Created_Date",
                value: new DateTime(2024, 8, 27, 20, 50, 35, 44, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 1,
                column: "Join_Date",
                value: new DateTime(2024, 8, 27, 20, 50, 35, 44, DateTimeKind.Local).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UsersId",
                keyValue: 2,
                column: "Join_Date",
                value: new DateTime(2024, 8, 27, 20, 50, 35, 44, DateTimeKind.Local).AddTicks(3020));

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1603047180, "permission", "full_access", "admin_user_id" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "admin", "admin_user_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1393440924);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 959871014);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1599777385);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1628660409);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1603047180);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "admin", "admin_user_id" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin_user_id");

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
    }
}
