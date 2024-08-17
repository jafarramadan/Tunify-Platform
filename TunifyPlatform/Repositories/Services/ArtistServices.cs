using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class ArtistServices : IArtists
    {
        private readonly TunifyAppDbContext _context;

        public ArtistServices(TunifyAppDbContext context)
        {
            _context = context;
        }
        public async Task<Artist> CreateArtist(Artist artist)
        {
            _context.Artist.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task<Artist> DeleteArtist(int artistId)
        {
            var exArtist = await GetArtistById(artistId);
            _context.Artist.Remove(exArtist);
            await _context.SaveChangesAsync();
            return exArtist;
        }

        public async Task<List<Artist>> GetAllArtist()
        {
            var allArtists = await _context.Artist.ToListAsync();
            return allArtists;
        }

        public async Task<Artist> GetArtistById(int artistId)
        {
            var artist = await _context.Artist.FindAsync(artistId);
            return artist;
        }

        public async Task<Artist> UpdateArtist(int ArtistId, Artist artist)
        {
            var exUser = await _context.Artist.FindAsync(ArtistId);
            exUser = artist;
            _context.SaveChanges();
            return exUser;
        }
        public async Task<Song> AddSongToArtist(int artistId, int songId)
        {
            var song = await _context.Song.FindAsync(songId);
            if (song != null)
            {
                song.ArtistId = artistId;
                _context.Entry(song).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            var songs = _context.Song.Where(a => a.ArtistId == artistId).FirstOrDefault();
            return songs;
        }
        public async Task<List<Song>> GetAllsongsFromArtistId(int artistId)
        {
            var songs = await _context.Song
                             .Where(s => s.ArtistId == artistId)
                             .ToListAsync();

            return songs;
        }

        
    }
}
