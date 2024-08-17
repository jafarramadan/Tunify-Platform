using Moq;
using System.Runtime.CompilerServices;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.interfaces;

namespace TunifyPlatform_Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetSongsForPlaylist_ReturnsCorrectSongs()
        {
            // Arrange
            var playlistId = 1;
            var songs = new List<Song>
             {
                new Song { SongId = 3, Title = "Song 1", ArtistId = 1, AlbumId = 1, Duration =new TimeSpan(4), Genre = "1" },
                new Song { SongId = 4, Title = "Song 2", ArtistId = 2, AlbumId = 2, Duration =new TimeSpan(4), Genre = "2" }
             };
            var mockRepository = new Mock<IPlaylists>();
            mockRepository.Setup(repo => repo.GetAllsongsFromPlaylistId(playlistId))
                          .ReturnsAsync(songs);
            // Act
            var result = await mockRepository.Object.GetAllsongsFromPlaylistId(playlistId);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, s => s.Title == "Song 1");
            Assert.Contains(result, s => s.Title == "Song 2");
            Assert.Equal(songs.ToString(), result.ToString());
        }
    }
}