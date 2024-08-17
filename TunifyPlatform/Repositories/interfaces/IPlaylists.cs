using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.interfaces
{
    public interface IPlaylists
    {
        Task<Playlist> CreatePlaylist(Playlist playlist);
        Task<List<Playlist>> GetAllPlaylist();
        Task<Playlist> GetPlaylistsById(int playlistId);
        Task<Playlist> UpdatePlaylist(int playlistId, Playlist playlist);
        Task<Playlist> DeletePlaylist(int playlistId);
        Task<bool> AddSongIntoPlaylist(int playlistId, int songId);
       Task<List<Song>> GetAllsongsFromPlaylistId(int playlistId);
    }
}
