import { AlertifyService } from './../../_services/alertify.service';
import { PlaylistsService } from './../../_services/playlists.service';
import { PlayerService } from './../../_services/player.service';
import { Component, OnInit, Input, ViewChild, OnDestroy } from '@angular/core';
import { Song } from '../../_models/Song';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-song',
  templateUrl: './song.component.html',
  styleUrls: ['./song.component.css']
})
export class SongComponent implements OnInit, OnDestroy {
  @Input() public song: Song;
  @Input() public isFromAlbum: false;
  public artistId;
  public isCurrent = false;
  public isPlaying = false;
  subscription: Subscription;
  subscriptionStop: Subscription;

  constructor(private playerService: PlayerService,
              public playlistService: PlaylistsService,
              private alertifyService: AlertifyService) {
    this.subscription = this.playerService.getCurrentSong().subscribe(song => {
      if (song.id != this.song.id) {
        this.isCurrent = false;
        this.isPlaying = false;
      }
      else {
        this.isCurrent = true;
        this.isPlaying = !this.isPlaying;
      }
    });

    this.subscriptionStop = this.playerService.isOnPause().subscribe(value => {
      if (this.song.id === value.song.id)
        this.isPlaying = !value.play;
    })

    if(this.playlistService.mainSongs.length === 0) 
       this.playlistService.getMainPlaylist().subscribe(data => {});
  }

  public Play(): void {
    this.playerService.setCurrentSong(this.song);
  }

  ngOnInit() {
    if (!this.isFromAlbum)
      this.artistId = this.song.album.artist.id;
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
    this.subscriptionStop.unsubscribe();
  }

  addToMainPlaylist(idSong: number) {
    this.playlistService.addToMainPlaylist(idSong).subscribe(data => {
      this.alertifyService.message(`${this.song.name} added to your library`);
    }, error => {
      this.alertifyService.message('Sorry, something went wrong :(');
    });
  }

  removeFromMainPlaylist(idSong: number) {
    this.playlistService.removeFromMainPlaylist(idSong).subscribe(data => {
      this.alertifyService.message(`${this.song.name} removed from your library`);
    }, error => {
      this.alertifyService.message('Sorry, something went wrong :(');
    });
  }

}
