using Microsoft.EntityFrameworkCore;
using MusicApp.API.Models;
using System.Collections.Generic;

namespace MusicApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<SongPlaylist> SongPlaylist { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongPlaylist>()
                .HasKey(bc => new { bc.SongId, bc.PlaylistId });

            modelBuilder.Entity<SongPlaylist>()
                .HasOne(bc => bc.Song)
                .WithMany(b => b.Playlists)
                .HasForeignKey(bc => bc.SongId);

            modelBuilder.Entity<SongPlaylist>()
                .HasOne(bc => bc.Playlist)
                .WithMany(c => c.Songs)
                .HasForeignKey(bc => bc.PlaylistId);
        }
    }
}