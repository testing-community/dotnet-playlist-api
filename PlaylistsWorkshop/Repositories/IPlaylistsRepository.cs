using PlaylistsWorkshop.Model;

namespace PlaylistsWorkshop.Repositories
{
    public interface IPlaylistsRepository
    {
        public Task<List<Playlist>> GetPlaylists();

        public Task<Playlist?> GetPlaylist(long playlistId);

        public Task<Playlist> AddPlaylist(Playlist playlist);

        public Task RemovePlaylist(Playlist playlist);
    }
}
