import { User } from './User';
import { Song } from './Song';

export interface PlaylistDetail {
    name: string;
    description: string;
    isMain: boolean;
    songs: Song[];
    username: string;
}