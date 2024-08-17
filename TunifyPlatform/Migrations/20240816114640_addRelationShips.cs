using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyPlatform.Migrations
{
    /// <inheritdoc />
    public partial class addRelationShips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_SubscriptionId",
                table: "Users",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Song_AlbumId",
                table: "Song",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Song_ArtistId",
                table: "Song",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSongs_PlaylistId",
                table: "PlaylistSongs",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSongs_SongId",
                table: "PlaylistSongs",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_UsersId",
                table: "Playlist",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistId",
                table: "Album",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlist_Users_UsersId",
                table: "Playlist",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "UsersId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Playlist_PlaylistId",
                table: "PlaylistSongs",
                column: "PlaylistId",
                principalTable: "Playlist",
                principalColumn: "PlaylistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Song_SongId",
                table: "PlaylistSongs",
                column: "SongId",
                principalTable: "Song",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Artist_ArtistId",
                table: "Song",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Subscription_SubscriptionId",
                table: "Users",
                column: "SubscriptionId",
                principalTable: "Subscription",
                principalColumn: "SubscriptionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlist_Users_UsersId",
                table: "Playlist");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Playlist_PlaylistId",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Song_SongId",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song");

            migrationBuilder.DropForeignKey(
                name: "FK_Song_Artist_ArtistId",
                table: "Song");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Subscription_SubscriptionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SubscriptionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Song_AlbumId",
                table: "Song");

            migrationBuilder.DropIndex(
                name: "IX_Song_ArtistId",
                table: "Song");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistSongs_PlaylistId",
                table: "PlaylistSongs");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistSongs_SongId",
                table: "PlaylistSongs");

            migrationBuilder.DropIndex(
                name: "IX_Playlist_UsersId",
                table: "Playlist");

            migrationBuilder.DropIndex(
                name: "IX_Album_ArtistId",
                table: "Album");
        }
    }
}
