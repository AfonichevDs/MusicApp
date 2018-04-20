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
        public int? AlbumId { get; set; }
        public Album Album { get; set; }     
    }
}