import { SongAlbumDTO } from './../_models/SongAlbumDTO';
import { AlbumDetail } from './../_models/AlbumDetail';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Song } from '../_models/Song';

@Component({
  selector: 'app-album-detail',
  templateUrl: './album-detail.component.html',
  styleUrls: ['./album-detail.component.css']
})
export class AlbumDetailComponent implements OnInit {

  album: AlbumDetail;
  songs: Song[];
  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.album = data['album'];
    });
    this.songs = this.album.songs;
  }

}
