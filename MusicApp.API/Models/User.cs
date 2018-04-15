using System;
using System.Collections.Generic;

namespace MusicApp.API.Models
{
    public class User
    {
        public int Id { get; set; }  
        public string UserName { get; set; }  
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; } 
        public byte[] PasswordSalt { get; set; }    
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Country Country { get; set; }
        public Photo ProfilePhoto { get; set; }
        public ICollection<Playlist> Playlists { get; set; }

        public User()
        {
            Playlists = new List<Playlist>();
        }
    }
}