using System.Collections.Generic;

namespace MusicApp.API.DTOs
{
    public class ArtistDetailDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string PhotoUrl { get; set; }

        public List<AlbumInfoDTO> Albums { get; set; }
    }
}