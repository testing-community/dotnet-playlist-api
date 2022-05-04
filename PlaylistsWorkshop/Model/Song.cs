namespace PlaylistsWorkshop.Model
{
    public class Song
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public string AlbumName { get; set; }
        public DateTime Created { get; set; }
    }
}
