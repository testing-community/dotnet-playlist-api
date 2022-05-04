using PlaylistsWorkshop.Model;

namespace PlaylistsWorkshop.Controllers.Dto
{
    public class SongDto
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public string AlbumName { get; set; }
        public DateTime Created { get; set; }

        public Song ToSong()
        {
            return new Song
            {
                Author = Author,
                Name = Name,
                AlbumName = AlbumName,
                Created = Created
            };
        }
    }
}
