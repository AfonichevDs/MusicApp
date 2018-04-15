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
    }
}