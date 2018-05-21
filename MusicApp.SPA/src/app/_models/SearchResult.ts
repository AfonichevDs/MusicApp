import { Playlist } from './Playlist';
import { Artist } from './Artist';
import { Song } from "./Song";
import { Album } from "./Album";

export class SearchResult {
    songs: Song[];
    albums : Album[];
    artists: Artist[];
    playlists: Playlist[];
}