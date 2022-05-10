using Microsoft.EntityFrameworkCore;

namespace PlaylistsWorkshop.Model
{
    public class PlaylistWorkshopContext : DbContext
    {

        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }

        public PlaylistWorkshopContext(DbContextOptions<PlaylistWorkshopContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>()
                .HasMany(p => p.Songs)
                .WithOne()
                .IsRequired();
        }
    }
}
