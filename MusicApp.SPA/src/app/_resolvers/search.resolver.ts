import { SearchResult } from './../_models/SearchResult';
import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Observable } from 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { PlaylistsService } from '../_services/playlists.service';
import { SearchService } from '../_services/search.service';
import { SearchOptions } from '../_models/SearchOptions';

@Injectable()
export class SearchResolver implements Resolve<SearchResult> {

    constructor(private searchService: SearchService,
        private alertifyService: AlertifyService) { }

    resolve(route: ActivatedRouteSnapshot): Observable<SearchResult> {
        let searchTerm = route.params['term'];
        let searchOptions = new SearchOptions(); 
        searchOptions.searchArtists = route.queryParams['searchArtists'];
        searchOptions.searchAlbums = route.queryParams['searchAlbums'];
        searchOptions.searchSongs = route.queryParams['searchSongs'];
        searchOptions.searchPlaylists = route.queryParams['searchPlaylists'];
        return this.searchService.search(searchTerm, searchOptions).catch(error => {
            this.alertifyService.error(error);
            return Observable.of(null);
        })
    }
}