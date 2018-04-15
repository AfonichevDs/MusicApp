namespace MusicApp.API.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int? AlbumId { get; set; }
        public Album Album { get; set; }     
    }
}