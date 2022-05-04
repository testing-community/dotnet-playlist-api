using PlaylistsWorkshop.Model;
using Microsoft.EntityFrameworkCore;

namespace PlaylistsWorkshop.Repositories
{
    public class PlaylistsRepository : IPlaylistsRepository
    {
        private readonly PlaylistWorkshopContext _context;
        public PlaylistsRepository(PlaylistWorkshopContext context)
        {
            _context = context;
        }
        public async Task<Playlist> AddPlaylist(Playlist playlist)
        {
            var playlistAdded = await _context.Playlists.AddAsync(playlist);
            await _context.SaveChangesAsync();

            return playlistAdded.Entity;
        }

        public async Task<Playlist?> GetPlaylist(long playlistId)
        {
            return await _context.Playlists.Include(p => p.Songs).SingleOrDefaultAsync(p => p.Id == playlistId);
        }

        public async Task<List<Playlist>> GetPlaylists()
        {
            return await _context.Playlists.ToListAsync();
        }

        public async Task RemovePlaylist(Playlist playlist)
        {
            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();
        }
    }
}
