using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MusicApp.API.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Photo Cover { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Song> Songs { get; set; }

        public Album()
        {
            Songs = new List<Song>();
        }
    }
}