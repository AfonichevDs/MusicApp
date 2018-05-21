import { ArtistsService } from './../_services/artists.service';
import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Observable } from 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { AlbumDetail } from '../_models/AlbumDetail';
import { AlbumsService } from '../_services/albums.service';

@Injectable()
export class AlbumResolver implements Resolve<AlbumDetail> {

    constructor(private albumService: AlbumsService,
        private authService: AuthService,
        private alertifyService: AlertifyService) { }

    resolve(route: ActivatedRouteSnapshot): Observable<AlbumDetail> {
        return this.albumService.getAlbum(route.params['id']).catch(error => {
            this.alertifyService.error(error);
            return Observable.of(null);
        })
    }
}