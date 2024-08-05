using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Models;

namespace TunifyPlatform.Data
{
    public class TunifyAppDbContext : DbContext
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
            modelBuilder.Entity<Users>().HasData(
            new Users { Id = 3, Username = "Jafar", Email = "jafar@gmail.com", Join_Date = DateTime.Now, SubscriptionId = 1 }
        );
           
            modelBuilder.Entity<Song>().HasData(
                new Song { SongId = 1, Title = "Music1", ArtistId = 1, AlbumId = 1, Duration = TimeSpan.FromMinutes(3), Genre = "aaa" }
                );
            modelBuilder.Entity<Playlist>().HasData(
                 new Playlist { PlaylistId = 1,Id = 1, Playlist_Name = "Playlist1", Created_Date = new DateTime(2020 - 01 - 01) }
               );
        }


    }
}
