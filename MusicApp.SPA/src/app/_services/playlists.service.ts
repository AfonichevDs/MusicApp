import { Headers, RequestOptions } from '@angular/http';
import { AuthService } from './auth.service';
import { Observable } from 'rxjs/Rx';
import { AuthHttp } from 'angular2-jwt';
import { Injectable } from '@angular/core';
import { handleError } from './globals';
import { PlaylistDetail } from '../_models/PlaylistDetail';

@Injectable()
export class PlaylistsService {
    baseUrl = 'http://localhost:5000/api/playlists/';

    mainSongs: number[] = new Array<number>();

    constructor(private authHttp: AuthHttp) { }

    public getMainPlaylist(): Observable<PlaylistDetail> {
        return this.authHttp
            .get(this.baseUrl + `getMainPlaylist`)
            .do(x => {
                const playlist: PlaylistDetail = x.json();
                if(this.mainSongs.length === 0)
                playlist.songs.forEach((item, index) => {
                    this.mainSongs.push(item.id);
                });
            })
            .map(response => response.json())
            .catch(err => handleError(err));
    }

    public addToMainPlaylist(idSong: number) {
        let data = { idSong: idSong };
        return this.authHttp
            .post(this.baseUrl + `addSongToMainPlaylist`, data, this.requestOptions())
            .do(data => {
                this.mainSongs.push(idSong);
            })
            .catch(handleError);
    }

    public removeFromMainPlaylist(idSong: number) {
        let data = { idSong: idSong };
        let requestOpt = this.requestOptions();
        requestOpt.body = data;
        return this.authHttp
            .delete(this.baseUrl + `removeSongFromMainPlaylist`, requestOpt)
            .do(data => {
                let index = this.mainSongs.indexOf(idSong);
                if (index > -1) {
                    this.mainSongs.splice(index, 1);
                }
            })
            .catch(handleError);
    }

    private requestOptions() {
        const headers = new Headers({ 'Content-type': 'application/json' });
        return new RequestOptions({ headers: headers });
    }
}
