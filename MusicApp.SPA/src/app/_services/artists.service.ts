import { Headers } from '@angular/http';
import { AuthService } from './auth.service';
import { Playlist } from './../_models/Playlist';
import { Observable } from 'rxjs/Rx';
import { AuthHttp } from 'angular2-jwt';
import { Injectable } from '@angular/core';
import { ArtistDetail } from '../_models/ArtistDetail';

@Injectable()
export class ArtistsService {
    artistsUrl = 'http://localhost:5000/api/artists/';

    constructor(private authHttp: AuthHttp) { }

    getArtist(idArtist: number):Observable<ArtistDetail> {
        let data = {idArtist: idArtist};
        return this.authHttp
          .get(this.artistsUrl+ `getArtist`, {params: data })
          .map(response => <ArtistDetail>response.json())
          .catch(this.handleError);
    }

    private handleError(error:any) {
        const applicationError = error.headers.get('Application-Error');
        if(applicationError) {
            return Observable.throw(applicationError);
        }

        const serverError = error.json();
        let modelStateErrors = '';
        if(serverError) {
            for (const key in serverError) {
                if(serverError[key]) {
                    modelStateErrors += serverError[key] + '\n';
                }
            }
        }
        return Observable.throw(
            modelStateErrors || 'Server Error'
        );
    }
}