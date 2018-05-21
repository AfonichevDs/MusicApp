using System.Collections.Generic;
using MusicApp.API.DTOs;

namespace MusicApp.API.Helpers
{
    public class SearchResult
    {
        public IList<ArtistDTO> Artists { get; set; }
        public IList<AlbumDTO> Albums { get; set; }
        public IList<SongDTO> Songs { get; set; }
        public IList<PlaylistDTO> Playlists { get; set; }
    }
}