import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Observable } from 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { Playlist } from './../_models/Playlist';
import { Resolve } from "@angular/router";
import { PlaylistsService } from '../_services/playlists.service';

@Injectable()
export class PlaylistResolver implements Resolve<Playlist> {

    constructor(private playlistService: PlaylistsService,
        private authService: AuthService,
        private alertifyService: AlertifyService) { }

    resolve(): Observable<Playlist> {
        if (this.authService.decodedToken == null)
            this.authService.decodeToken();
        return this.playlistService.getMainPlaylist(this.authService.decodedToken.nameid).catch(error => {
            this.alertifyService.error(error);
            return Observable.of(null);
        })
    }
}