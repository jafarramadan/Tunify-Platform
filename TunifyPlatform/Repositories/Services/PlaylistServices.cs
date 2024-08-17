using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class PlaylistServices : IPlaylists
    {
        private readonly TunifyAppDbContext _context;

        public PlaylistServices(TunifyAppDbContext context)
        {
            _context = context;
        }
        public async Task<Playlist> CreatePlaylist(Playlist playlist)
        {
            _context.Playlist.Add(playlist);
            await _context.SaveChangesAsync();
            return playlist;
        }

        public async Task<Playlist> DeletePlaylist(int playlistId)
        {
            var exPlaylist = await GetPlaylistsById(playlistId);
            _context.Playlist.Remove(exPlaylist);
            await _context.SaveChangesAsync();
            return exPlaylist;
        }

        public async Task<List<Playlist>> GetAllPlaylist()
        {
            var allPlaylist = await _context.Playlist.ToListAsync();
            return allPlaylist;
        }

        public async Task<Playlist> GetPlaylistsById(int playlistId)
        {
            var playlist = await _context.Playlist.FindAsync(playlistId);
            return playlist;
        }

        public async Task<Playlist> UpdatePlaylist(int playlistId, Playlist playlist)
        {
            var exPlaylist = await _context.Playlist.FindAsync(playlistId);
            exPlaylist = playlist;
            _context.SaveChanges();
            return exPlaylist;
        }
        public async Task<bool> AddSongIntoPlaylist(int playlistId, int songId)
        {
            var newSong = new PlaylistSongs()
            {
                PlaylistId = playlistId,
                SongId = songId
            };
            await _context.PlaylistSongs.AddAsync(newSong);
            await _context.SaveChangesAsync();

            return true;

        }
         public async Task<List<Song>> GetAllsongsFromPlaylistId(int playlistId)
        {
            var newSong = await _context.PlaylistSongs
                          .Where(p => p.PlaylistId == playlistId)
                          .Select(s => s.Song)
                          .ToListAsync();

            return newSong;
        }
    }
}