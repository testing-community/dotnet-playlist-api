using PlaylistsWorkshop.Model;

namespace PlaylistsWorkshop.Controllers.Dto
{
    public class PlaylistDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Playlist ToPlaylist()
        {
            return new Playlist
            {
                Name = Name,
                Description = Description
            };
        }
    }
}
