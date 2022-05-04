using PlaylistsWorkshop.Model;
namespace PlaylistsWorkshop.Repositories
{
    public interface ISongsRepository
    {
        public Task<List<Song>> GetSongs();

        public Task<Song?> GetSong(long songId);

        public Task<Song> AddSong(Song song, Playlist playlist);

        public Task RemoveSong(Song song);
    }
}
