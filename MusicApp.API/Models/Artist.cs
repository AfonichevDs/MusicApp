using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicApp.API.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Photo Photo { get; set; }
        public ICollection<Album> Albums { get; set; }

        public Artist()
        {
            Albums = new List<Album>();
        }
    }
}