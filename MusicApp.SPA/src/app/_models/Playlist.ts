import { UserDTO } from "./UserDTO";
import { ArtistDTO } from "./ArtistDTO";

export class Playlist {
    id: number;
    name: string;
    description: string;
    songsCount: number;
    user: UserDTO;
    artists: ArtistDTO[];
}