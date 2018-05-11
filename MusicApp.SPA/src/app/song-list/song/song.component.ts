import { PlayerService } from './../../_services/player.service';
import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Song } from '../../_models/Song';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-song',
  templateUrl: './song.component.html',
  styleUrls: ['./song.component.css']
})
export class SongComponent implements OnInit {
  @Input() public song: Song;
  public artistId;
  public isCurrent = false;
  public isPlaying = false;
  subscription: Subscription;
  subscriptionStop: Subscription;

  constructor(private playerService: PlayerService) {
    this.subscription = this.playerService.getCurrentSong().subscribe(song => {
      if(song.id != this.song.id) {
        this.isCurrent = false;
        this.isPlaying = false;
      }
      else {
        this.isCurrent = true;
        this.isPlaying = !this.isPlaying;
      }
    });

    this.subscriptionStop = this.playerService.isOnPause().subscribe(value => {
      if(this.song.name === value.song.name && this.song.album.id == value.song.album.id)
      this.isPlaying = !value.play;
    })
  }

  public Play():void {
    this.playerService.setCurrentSong(this.song);
  }

  ngOnInit() {
    this.artistId = this.song.album.artist.id;
  }

}
