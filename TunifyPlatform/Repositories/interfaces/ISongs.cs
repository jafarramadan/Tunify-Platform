using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.interfaces
{
    public interface ISongs
    {
        Task<Song> CreateSong(Song song);
        Task<List<Song>> GetAllSongs();
        Task<Song> GetSongById(int songId);
        Task<Song> UpdateSong(int songId, Song song);
        Task<Song> DeleteSong(int songId);
    }
}
