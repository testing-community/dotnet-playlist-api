using PlaylistsWorkshop.Model;

namespace PlaylistsWorkshop.Services
{
    public interface IPlaylistsService
    {
        public Task<List<Playlist>> GetPlaylists();

        public Task<Playlist?> GetPlaylist(long playlistId);

        public Task<Playlist> AddPlaylist(Playlist playlist);

        public Task<bool> RemovePlaylist(long playlistId);
    }
}
