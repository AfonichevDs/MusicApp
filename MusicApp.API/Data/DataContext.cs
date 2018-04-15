using Microsoft.EntityFrameworkCore;
using MusicApp.API.Models;

namespace MusicApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) {}
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}