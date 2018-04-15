using System.Collections.Generic;

namespace MusicApp.API.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public Photo Photo { get; set; }
        public ICollection<Album> Albums { get; set; }

        public Artist()
        {
            Albums = new List<Album>();
        }
    }
}