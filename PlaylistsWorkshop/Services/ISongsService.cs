using PlaylistsWorkshop.Model;
namespace PlaylistsWorkshop.Services
{
    public interface ISongsService
    {
        public Task<List<Song>> GetSongs();

        public Task<Song?> GetSong(long songId);

        public Task<Song?> AddSong(Song song, long playlistId);

        public Task<bool> RemoveSong(long songId);
    }
}
