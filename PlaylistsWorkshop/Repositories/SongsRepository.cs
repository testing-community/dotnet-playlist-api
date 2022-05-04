using PlaylistsWorkshop.Model;
using Microsoft.EntityFrameworkCore;

namespace PlaylistsWorkshop.Repositories
{
    public class SongsRepository : ISongsRepository
    {
        private readonly PlaylistWorkshopContext _context;
        public SongsRepository(PlaylistWorkshopContext context)
        {
            _context = context;
        }

        public async Task<Song> AddSong(Song song, Playlist playlist)
        {
            playlist.AddSong(song);
            await _context.SaveChangesAsync();

            return song;
        }

        public async Task<Song?> GetSong(long songId)
        {
            return await _context.Songs.FindAsync(songId);
        }

        public async Task<List<Song>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        public async Task RemoveSong(Song song)
        {
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
        }
    }
}
