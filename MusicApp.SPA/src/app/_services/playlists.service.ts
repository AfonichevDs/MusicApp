import { Headers } from '@angular/http';
import { AuthService } from './auth.service';
import { Playlist } from './../_models/Playlist';
import { Observable } from 'rxjs/Rx';
import { AuthHttp } from 'angular2-jwt';
import { Injectable } from '@angular/core';

@Injectable()
export class PlaylistsService {
    baseUrl = 'http://localhost:5000/api/playlists/';

    constructor(private authHttp: AuthHttp) { }

    getMainPlaylist(idUser: string):Observable<Playlist> {
        let data = {idUser: idUser};
        return this.authHttp
          .get(this.baseUrl+ `getMainPlaylist`, {params: data })
          .map(response => <Playlist>response.json())
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
