namespace MusicApp.API.DTOs
{
    public class SongDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int Order { get; set; }
        public AlbumDTO Album { get; set; }
    }
}