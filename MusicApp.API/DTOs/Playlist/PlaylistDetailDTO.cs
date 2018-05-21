using System.Collections.Generic;
using MusicApp.API.Models;

namespace MusicApp.API.DTOs
{
    public class PlaylistDetailDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsMain { get; set; }
        public List<SongDTO> Songs { get; set; }
        public string Username { get; set; }
    }
}