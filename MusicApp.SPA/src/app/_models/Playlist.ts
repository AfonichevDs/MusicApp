import { User } from './User';
import { Song } from './Song';

export interface Playlist {
    id: number;
    name: string;
    description: string;
    isMain: boolean;
    User? : User;
    Songs?: Song[];
}