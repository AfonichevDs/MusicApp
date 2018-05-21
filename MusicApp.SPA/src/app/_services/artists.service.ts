import { Headers } from '@angular/http';
import { AuthService } from './auth.service';
import { Playlist } from './../_models/Playlist';
import { Observable } from 'rxjs/Rx';
import { AuthHttp } from 'angular2-jwt';
import { Injectable } from '@angular/core';
import { ArtistDetail } from '../_models/ArtistDetail';
import { handleError } from './globals';

@Injectable()
export class ArtistsService {
    artistsUrl = 'http://localhost:5000/api/artists/';

    constructor(private authHttp: AuthHttp) { }

    getArtist(idArtist: number):Observable<ArtistDetail> {
        let data = {idArtist: idArtist};
        return this.authHttp
          .get(this.artistsUrl+ `getArtist`, {params: data })
          .map(response => <ArtistDetail>response.json())
          .catch(handleError);
    }
}