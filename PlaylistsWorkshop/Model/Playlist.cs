namespace PlaylistsWorkshop.Model
{
    public class Playlist
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        private List<Song> _songs = new ();
        public IReadOnlyCollection<Song> Songs => _songs;

        public void AddSong(Song song)
        {
            _songs.Add(song);
        }
    }
}
