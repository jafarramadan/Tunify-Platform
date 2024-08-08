using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class SongServices : ISongs
    {
        private readonly TunifyAppDbContext _context;

        public SongServices(TunifyAppDbContext context)
        {
            _context = context;
        }
        public async Task<Song> CreateSong(Song song)
        {
            _context.Song.Add(song);
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task<Song> DeleteSong(int songId)
        {
            var exSong = await GetSongById(songId);
            _context.Song.Remove(exSong);
            await _context.SaveChangesAsync();
            return exSong;
        }

        public async Task<List<Song>> GetAllSongs()
        {
            var allSong = await _context.Song.ToListAsync();
            return allSong;
        }

        public async Task<Song> GetSongById(int songId)
        {
            var song = await _context.Song.FindAsync(songId);
            return song;
        }

        public async Task<Song> UpdateSong(int songId, Song song)
        {
            var exSong = await _context.Song.FindAsync(songId);
            exSong = song;
            _context.SaveChanges();
            return exSong;
        }
    }
}
