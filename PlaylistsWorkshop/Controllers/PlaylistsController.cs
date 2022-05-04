using Microsoft.AspNetCore.Mvc;
using PlaylistsWorkshop.Model;
using PlaylistsWorkshop.Services;
using PlaylistsWorkshop.Controllers.Dto;

namespace PlaylistsWorkshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylistsService _playlistService;

        public PlaylistsController(IPlaylistsService playlistsService)
        {
            _playlistService = playlistsService;
        }

        // GET: api/Playlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            return await _playlistService.GetPlaylists();
        }

        // GET: api/Playlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetPlaylist(long id)
        {
            var playlist = await _playlistService.GetPlaylist(id);

            if (playlist == null)
            {
                return NotFound();
            }

            return playlist;
        }

        // POST: api/Playlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist(PlaylistDto playlist)
        {
            var playlistToAdd = playlist.ToPlaylist();
            var playlistCreated = await _playlistService.AddPlaylist(playlistToAdd);

            return CreatedAtAction("GetPlaylist", new { id = playlistCreated.Id }, playlistCreated);
        }

        // DELETE: api/Playlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(long id)
        {
            if (await _playlistService.RemovePlaylist(id))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
