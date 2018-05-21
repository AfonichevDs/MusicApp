export class SearchOptions {
    searchArtists: boolean;
    searchAlbums: boolean;
    searchSongs: boolean;
    searchPlaylists: boolean;

    constructor() {
        this.searchArtists = true;
        this.searchAlbums = true;
        this.searchSongs = true;
        this.searchPlaylists = true;
    }
}