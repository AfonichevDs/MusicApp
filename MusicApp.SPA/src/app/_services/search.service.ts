import { SearchResult } from './../_models/SearchResult';
import { Observable } from 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { AuthHttp } from 'angular2-jwt';
import { SearchOptions } from '../_models/SearchOptions';
import { handleError } from './globals';

@Injectable()
export class SearchService {
    baseUrl = 'http://localhost:5000/api/search/';

    constructor(private authHttp: AuthHttp) { }

    search(searchTerm:string, searchOptions?: SearchOptions): Observable<SearchResult> {
        let queryString = '?';
        let _searchOptions = searchOptions == null ? new SearchOptions() : searchOptions;

        queryString += 'searchTerm='+ searchTerm + '&searchArtists=' + _searchOptions.searchArtists + '&searchAlbums=' + _searchOptions.searchAlbums
        + '&searchSongs=' + _searchOptions.searchSongs + '&searchPlaylists=' + _searchOptions.searchPlaylists;

        return this.authHttp.get(this.baseUrl + 'searchByTerm' + queryString)
                            .map(response =><SearchResult>response.json())
                            .catch(handleError);
    }
}

