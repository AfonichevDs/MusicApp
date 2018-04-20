using System.ComponentModel.DataAnnotations;

namespace MusicApp.API.Models
{
    public class Photo
    {
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
    }
}