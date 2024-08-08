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
    }
}
