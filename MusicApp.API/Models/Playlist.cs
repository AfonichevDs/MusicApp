using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicApp.API.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsMain { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public ICollection<SongPlaylist> Songs { get; set; }
        
        public Playlist()
        {
            Songs = new List<SongPlaylist>();
        }
    }
}