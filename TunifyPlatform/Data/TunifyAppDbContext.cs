using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TunifyPlatform.Models;

namespace TunifyPlatform.Data
{
    public class TunifyAppDbContext : IdentityDbContext<ApplicationUser>
    {

        public TunifyAppDbContext(DbContextOptions<TunifyAppDbContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<PlaylistSongs> PlaylistSongs { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<Subscription> Subscription { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          //  modelBuilder.Entity<PlaylistSongs>().HasKey(pk => new { pk.SongId, pk.PlaylistId });
         //   modelBuilder.Entity<Users>().HasKey(pk => pk.UsersId);

            modelBuilder.Entity<PlaylistSongs>()
                .HasOne(pk => pk.Song)
                .WithMany(pk => pk.playlistSongs)
                .HasForeignKey(pk => pk.SongId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<PlaylistSongs>()
                .HasOne(pk => pk.Playlist)
                .WithMany(pk => pk.playlistSongs)
                .HasForeignKey(pk => pk.PlaylistId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Song>()
                .HasOne(pk => pk.Artist)
                .WithMany(pk => pk.Songs)
                .HasForeignKey(pk => pk.ArtistId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Song>()
                .HasOne(pk => pk.Album)
                .WithMany(pk => pk.Songs)
                .HasForeignKey(pk => pk.AlbumId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Album>()
                .HasOne(pk => pk.Artist)
                .WithMany(pk => pk.Albums)
                .HasForeignKey(pk => pk.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Users>()
               .HasOne(pk => pk.Subscription)
               .WithMany(pk => pk.Users)
               .HasForeignKey(pk => pk.SubscriptionId)
               .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Playlist>()
                .HasOne(pk => pk.Users)
               .WithMany(pk => pk.Playlists)
               .HasForeignKey(pk => pk.UsersId)
               .OnDelete(DeleteBehavior.Restrict);

            // Seeding Subscription data
            modelBuilder.Entity<Subscription>().HasData(
                new Subscription { SubscriptionId = 1, Subscription_Type = "Basic", Price = 9.99 },
                new Subscription { SubscriptionId = 2, Subscription_Type = "Premium", Price = 19.99 }
            );

            // Seeding Artist data
            modelBuilder.Entity<Artist>().HasData(
                new Artist { ArtistId = 1, Name = "Artist One", Bio = "Bio of Artist One" },
                new Artist { ArtistId = 2, Name = "Artist Two", Bio = "Bio of Artist Two" }
            );

            // Seeding Album data
            modelBuilder.Entity<Album>().HasData(
                new Album { AlbumId = 1, Album_Name = "Album One", Release_Date = new DateTime(2023, 1, 1), ArtistId = 1 },
                new Album { AlbumId = 2, Album_Name = "Album Two", Release_Date = new DateTime(2023, 6, 1), ArtistId = 2 }
            );

            // Seeding Song data
            modelBuilder.Entity<Song>().HasData(
                new Song { SongId = 1, Title = "Song One", ArtistId = 1, AlbumId = 1, Duration = TimeSpan.FromMinutes(3), Genre = "Pop" },
                new Song { SongId = 2, Title = "Song Two", ArtistId = 2, AlbumId = 2, Duration = TimeSpan.FromMinutes(4), Genre = "Rock" }
            );

            // Seeding User data
            modelBuilder.Entity<Users>().HasData(
                new Users { UsersId = 1, Username = "user1", Email = "user1@example.com", Join_Date = DateTime.Now, SubscriptionId = 1 },
                new Users { UsersId = 2, Username = "user2", Email = "user2@example.com", Join_Date = DateTime.Now, SubscriptionId = 2 }
            );

            // Seeding Playlist data
            modelBuilder.Entity<Playlist>().HasData(
                new Playlist { PlaylistId = 1, UsersId = 1, Playlist_Name = "Playlist One", Created_Date = DateTime.Now },
                new Playlist { PlaylistId = 2, UsersId = 2, Playlist_Name = "Playlist Two", Created_Date = DateTime.Now }
            );

            // Seeding PlaylistSongs data
            modelBuilder.Entity<PlaylistSongs>().HasData(
                new PlaylistSongs { PlaylistSongsId = 1, PlaylistId = 1, SongId = 1 },
                new PlaylistSongs { PlaylistSongsId = 2, PlaylistId = 2, SongId = 2 }
            );

        }
    }
}