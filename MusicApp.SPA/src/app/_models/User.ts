import { Country } from './Country';
import { Photo } from "./Photo";
import { Playlist } from './Playlist';

export interface User {
    id: number;
    username: string;
    email: string;
    gender: string;
    dateOfBirth: Date;
    idcountry: number;
    password: string;
}