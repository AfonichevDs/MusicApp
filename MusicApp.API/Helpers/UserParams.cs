namespace MusicApp.API.Helpers
{
    public class UserParams
    {
        public string SearchTerm { get; set; }
        public bool SearchArtists { get; set; }
        public bool SearchAlbums { get; set; }
        public bool SearchSongs { get; set; }
        public bool SearchPlaylists { get; set; }

    }
}