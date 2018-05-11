using System.Collections.Generic;
using MusicApp.API.Models;

namespace MusicApp.API.DTOs
{
    public class PlaylistDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsMain { get; set; }
        public List<SongListDTO> Songs { get; set; }
        public string Username { get; set; }
    }
}