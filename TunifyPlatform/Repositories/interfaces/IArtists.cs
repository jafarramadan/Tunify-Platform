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
    }
}
