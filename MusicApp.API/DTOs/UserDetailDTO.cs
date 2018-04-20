using System;

namespace MusicApp.API.DTOs
{
    public class UserDetailDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }

    }
}