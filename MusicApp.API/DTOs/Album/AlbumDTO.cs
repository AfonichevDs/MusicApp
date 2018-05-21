namespace MusicApp.API.DTOs
{
    public class AlbumDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CoverUrl { get; set; }
        public ArtistInfoDTO Artist { get; set; }
    }
}