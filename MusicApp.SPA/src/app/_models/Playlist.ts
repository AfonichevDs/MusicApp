import { User } from './User';
import { Song } from './Song';

export interface Playlist {
    name: string;
    description: string;
    isMain: boolean;
    songs: Song[];
    username: string;
}