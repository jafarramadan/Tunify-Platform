using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Playlist",
                columns: new[] { "Id", "Created_Date", "PlaylistId", "Playlist_Name" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2018), 1, "Playlist1" });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "SongId", "AlbumId", "ArtistId", "Duration", "Genre", "Title" },
                values: new object[] { 1, 1, 1, new TimeSpan(0, 0, 3, 0, 0), "aaa", "Music1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Join_Date", "SubscriptionId", "Username" },
                values: new object[] { 3, "jafar@gmail.com", new DateTime(2024, 8, 5, 16, 28, 39, 939, DateTimeKind.Local).AddTicks(1634), 1, "Jafar" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Playlist",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "SongId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
