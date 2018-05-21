using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MusicApp.API.Models
{
    public class Album
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Year { get; set; }
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