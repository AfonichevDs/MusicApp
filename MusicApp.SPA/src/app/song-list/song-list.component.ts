import { PlaylistsService } from './../_services/playlists.service';
import { Component, OnInit, Input } from '@angular/core';
import { Song } from '../_models/Song';
import { ActivatedRoute } from '@angular/router';
import { PlaylistDetail } from '../_models/PlaylistDetail';

@Component({
  selector: 'app-song-list',
  templateUrl: './song-list.component.html',
  styleUrls: ['./song-list.component.css']
})
export class SongListComponent implements OnInit {
  mainPlaylist: PlaylistDetail;
  songs: Song[] = new Array<Song>();

  
  constructor(private playlistService: PlaylistsService,
              private route: ActivatedRoute) { }

  ngOnInit() {
     this.route.data.subscribe(data => {
       this.mainPlaylist = data['mainPlaylist'];
     });
     this.songs = this.mainPlaylist.songs;
  }

}
