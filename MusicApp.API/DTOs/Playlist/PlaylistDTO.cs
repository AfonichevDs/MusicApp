using System.Collections.Generic;

namespace MusicApp.API.DTOs
{
    public class PlaylistDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SongsCount { get; set; }
        public UserInfoDTO User { get; set; }
        public IList<ArtistInfoDTO> Artists { get; set; }
    }
}