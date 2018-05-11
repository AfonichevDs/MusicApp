import { ArtistsService } from './../_services/artists.service';
import { ArtistDetail } from './../_models/ArtistDetail';
import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Observable } from 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";

@Injectable()
export class ArtistResolver implements Resolve<ArtistDetail> {

    constructor(private artistService: ArtistsService,
        private authService: AuthService,
        private alertifyService: AlertifyService) { }

    resolve(route: ActivatedRouteSnapshot): Observable<ArtistDetail> {
        return this.artistService.getArtist(route.params['id']).catch(error => {
            this.alertifyService.error(error);
            return Observable.of(null);
        })
    }
}