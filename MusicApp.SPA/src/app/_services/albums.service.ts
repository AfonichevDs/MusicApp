import { Injectable } from '@angular/core';
import { AuthHttp } from 'angular2-jwt';
import { AlbumDetail } from '../_models/AlbumDetail';
import { Observable } from 'rxjs';
import { handleError } from './globals';

@Injectable()
export class AlbumsService {
    albumsUrl = 'http://localhost:5000/api/albums/';

    constructor(private authHttp: AuthHttp) { }

    
    getAlbum(idAlbum: number):Observable<AlbumDetail> {
        let data = {idAlbum: idAlbum};
        return this.authHttp
          .get(this.albumsUrl+ `getAlbumDetail`, {params: data })
          .map(response => <AlbumDetail>response.json())
          .catch(handleError);
    }
}
