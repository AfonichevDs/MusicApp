import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Observable } from 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { Resolve } from "@angular/router";
import { PlaylistsService } from '../_services/playlists.service';
import { PlaylistDetail } from '../_models/PlaylistDetail';

@Injectable()
export class PlaylistResolver implements Resolve<PlaylistDetail> {

    constructor(private playlistService: PlaylistsService,
        private alertifyService: AlertifyService) { }

    resolve(): Observable<PlaylistDetail> {
        return this.playlistService.getMainPlaylist().catch(error => {
            this.alertifyService.error(error);
            return Observable.of(null);
        })
    }
}