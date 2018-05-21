import { Playlist } from './../_models/Playlist';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-playlist-card',
  templateUrl: './playlist-card.component.html',
  styleUrls: ['./playlist-card.component.css']
})
export class PlaylistCardComponent implements OnInit {

  @Input() playlist:Playlist;
  constructor() { }

  ngOnInit() {
  }

}
