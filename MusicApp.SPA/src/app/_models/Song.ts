import { Album } from "./Album";

export interface Song {
    id:number;
    name: string;
    path: string;
    album: Album;
}