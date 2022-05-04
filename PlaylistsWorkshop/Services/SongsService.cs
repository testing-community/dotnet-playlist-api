using PlaylistsWorkshop.Model;
using PlaylistsWorkshop.Repositories;

namespace PlaylistsWorkshop.Services
{
    public class SongsService : ISongsService
    {
        private readonly ISongsRepository _songsRepository;
        private readonly IPlaylistsRepository _playlistsRepository;

        public SongsService(ISongsRepository songsRepository, IPlaylistsRepository playlistsRepository)
        {
            _songsRepository = songsRepository;
            _playlistsRepository = playlistsRepository;
        }
        public async Task<Song?> AddSong(Song song, long playlistId)
        {
            var playlist = await _playlistsRepository.GetPlaylist(playlistId);
            return playlist == null ? null : await _songsRepository.AddSong(song, playlist);

        }

        public Task<Song?> GetSong(long songId)
        {
            return _songsRepository.GetSong(songId);
        }

        public Task<List<Song>> GetSongs()
        {
            return _songsRepository.GetSongs();
        }

        public async Task<bool> RemoveSong(long songId)
        {
            var song = await _songsRepository.GetSong(songId);
            if (song == null) { return false; }

            await _songsRepository.RemoveSong(song);
            return true;
        }
    }
}
