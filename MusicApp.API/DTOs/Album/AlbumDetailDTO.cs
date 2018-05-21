using System.Collections.Generic;

namespace MusicApp.API.DTOs
{
    public class AlbumDetailDTO
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string CoverUrl { get; set; }
        public List<SongAlbumListDTO> Songs { get; set; }
    }
}