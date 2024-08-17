using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.interfaces;

namespace TunifyPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylists _context;

        public PlaylistsController(IPlaylists context)
        {
            _context = context;
        }

        // GET: api/Playlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylist()
        {
                return await _context.GetAllPlaylist();
        }

        // GET: api/Playlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetPlaylist(int id)
        {
          return await _context.GetPlaylistsById(id);

        }

        // PUT: api/Playlists/5
        // To protect from overposting attacks,see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylist(int id, Playlist playlist)
        {
            var updatedPlaylist = await _context.UpdatePlaylist(id ,playlist);
            return Ok(updatedPlaylist);
        }

        // POST: api/Playlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist(Playlist playlist)
        {
          return await _context.CreatePlaylist(playlist);
        }

        // DELETE: api/Playlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            var deletedPlaylist= await _context.DeletePlaylist(id);
            return Ok(deletedPlaylist);
        }

        //post song to playlist
        //api/playlists/{playlistId}/songs/{songId}
        [HttpPost]
        [Route("api/playlists/{playlistId}/songs/{songId}")]
        public async Task<IActionResult> AddSongIntoPlaylist(int playlistId , int songId)
        {
            var newSong = await _context.AddSongIntoPlaylist(playlistId , songId);
            return Ok(newSong);
        }
        [HttpGet]
        [Route("{playlistId}/songs")]
        public async Task<List<Song>> GetAllsongsFromPlaylistId(int playlistId)
        {
            return await _context.GetAllsongsFromPlaylistId(playlistId);
             
        }
    }
}
