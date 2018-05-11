import { Photo } from './Photo';
import { ArtistDTO } from "./ArtistDTO";

export class Album {
    id: number;
    name: string;
    photoUrl: string;
    artist: ArtistDTO;
}