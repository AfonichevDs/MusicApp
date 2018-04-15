using System.Collections.Generic;

namespace MusicApp.API.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public ICollection<Song> Songs { get; set; }
        
        public Playlist()
        {
            Songs = new List<Song>();
        }
    }
}