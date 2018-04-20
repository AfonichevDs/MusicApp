using System.ComponentModel.DataAnnotations;

namespace MusicApp.API.Models
{
    public class Country
    {
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
    }
}