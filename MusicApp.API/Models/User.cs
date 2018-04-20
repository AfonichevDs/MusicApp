using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicApp.API.Models
{
    public class User
    {
        public int Id { get; set; }  
        [Required]
        public string UserName { get; set; }  
        [Required]
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; } 
        public byte[] PasswordSalt { get; set; }    
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int? CountryId { get; set; }
        public Country Country { get; set; }

        public int? PhotoId { get; set; }
        public Photo ProfilePhoto { get; set; }
        public ICollection<Playlist> Playlists { get; set; }

        public User()
        {
            Playlists = new List<Playlist>();
        }
    }
}