namespace MusicApp.API.DTOs
{
    public class SongListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public AlbumDTO Album { get; set; }
    }
}