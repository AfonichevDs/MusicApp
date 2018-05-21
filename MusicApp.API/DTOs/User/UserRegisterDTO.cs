using System;
using System.ComponentModel.DataAnnotations;

namespace MusicApp.API.DTOs
{
    public class UserRegisterDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage="You must specify password with length between 8 and 20 characters")]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int IdCountry { get; set; }
    }
}