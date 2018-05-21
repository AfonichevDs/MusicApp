import { Album } from "./Album";

export interface Song {
    id:number;
    name: string;
    path: string;
    order: number;
    album: Album;
}