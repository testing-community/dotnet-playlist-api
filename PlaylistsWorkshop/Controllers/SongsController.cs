using Microsoft.AspNetCore.Mvc;
using PlaylistsWorkshop.Controllers.Dto;
using PlaylistsWorkshop.Model;
using PlaylistsWorkshop.Services;

namespace PlaylistsWorkshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongsService _songsService;

        public SongsController(ISongsService songsService)
        {
            _songsService = songsService;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _songsService.GetSongs();
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(long id)
        {
            var song = await _songsService.GetSong(id);

            if (song == null)
            {
                return NotFound();
            }

            return song;
        }

        // POST: api/Songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{playlistId}")]
        public async Task<ActionResult<Song>> PostSong(long playlistId, SongDto song)
        {
            var songToAdd = song.ToSong();
            var songCreated = await _songsService.AddSong(songToAdd, playlistId);

            if(songCreated == null) return NotFound();

            return CreatedAtAction("GetSong", new { id = songCreated.Id }, songCreated);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(long id)
        {
            var song = await _songsService.RemoveSong(id);
            if (song)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
