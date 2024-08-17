using Microsoft.AspNetCore.Mvc;
using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.interfaces
{
    public interface IArtists
    {
        Task<Artist> CreateArtist(Artist artist);
        Task<List<Artist>> GetAllArtist();
        Task<Artist> GetArtistById(int artistId);
        Task<Artist> UpdateArtist(int ArtistId, Artist artist);
        Task<Artist> DeleteArtist(int artistId);
        Task<Song> AddSongToArtist(int artistId, int songId);
        Task<List<Song>> GetAllsongsFromArtistId(int artistId);


    }
}
