using Microsoft.EntityFrameworkCore;
using PlaylistsWorkshop.Model;
using PlaylistsWorkshop.Repositories;

namespace PlaylistsWorkshop.Services
{
    public class PlaylistsService : IPlaylistsService
    {

        private readonly IPlaylistsRepository _playlistsRepository;

        public PlaylistsService(IPlaylistsRepository playlistsRepository)
        {
            _playlistsRepository = playlistsRepository;
        }

        public async Task<List<Playlist>> GetPlaylists()
        {
            return await _playlistsRepository.GetPlaylists();
        }

        public async Task<Playlist?> GetPlaylist(long playlistId)
        {
            return await _playlistsRepository.GetPlaylist(playlistId);
        }

        public async Task<Playlist> AddPlaylist(Playlist playlist)
        {
            return await _playlistsRepository.AddPlaylist(playlist);
        }

        public async Task<bool> RemovePlaylist(long playlistId)
        {
            var playlist = await _playlistsRepository.GetPlaylist(playlistId);
            if (playlist == null)
            {
                return false;
            }

            await _playlistsRepository.RemovePlaylist(playlist);
            return true;
        }
    }
}
