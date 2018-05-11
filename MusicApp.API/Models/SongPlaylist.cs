namespace MusicApp.API.Models
{
    public class SongPlaylist
    {
        public int SongId { get; set; }
        public Song Song { get; set; }
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    }
}