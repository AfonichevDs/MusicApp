using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicApp.API.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public int Order { get; set; }
        public int? AlbumId { get; set; }
        public Album Album { get; set; }

        public ICollection<SongPlaylist> Playlists { get; set; }       
        public Song()
        {
            Playlists = new List<SongPlaylist>();
        }
    }
}