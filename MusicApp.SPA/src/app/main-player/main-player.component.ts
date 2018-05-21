import { PlayerService } from './../_services/player.service';
import { Component, OnInit, Input, ViewChild, OnDestroy } from '@angular/core';
import { Song } from '../_models/Song';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-main-player',
  templateUrl: './main-player.component.html',
  styleUrls: ['./main-player.component.css']
})
export class MainPlayerComponent implements OnInit, OnDestroy {
  public audio: any;
  public isPlaying = false;
  public song: Song;

  subscriptionSong: Subscription;
  @ViewChild('playButton') playButton;
  @ViewChild('currentTimeEl') currentTimeEl;

  constructor(public playerService: PlayerService) {
    this.subscriptionSong = this.playerService.getCurrentSong().subscribe(song => {
      if (this.song == null || (song.id != this.song.id)) {
        this.song = song;
        this.playButton.nativeElement.setAttribute("class", "fa fa-pause-circle play-btn");
        this.audio.src = this.song.path;
        this.audio.play();
        this.isPlaying = true;
      }
      else {
        if (this.isPlaying) {
          this.playButton.nativeElement.setAttribute("class", "fa fa-play-circle play-btn");
          this.audio.pause();
          this.isPlaying = false;
        }
        else {
          this.playButton.nativeElement.setAttribute("class", "fa fa-pause-circle play-btn");
          this.audio.play();
          this.isPlaying = true;
        }
      }
    });
  }

  ngOnInit() {
    this.audio = new Audio();
    this.audio.ontimeupdate = () => {
      this.currentTimeEl.nativeElement.textContent = this.formattedTime(this.audio.currentTime);
    };
  }

  ngOnDestroy() {
    this.subscriptionSong.unsubscribe();
  }

  public Play(): void {
    const audioPath = this.audio.src.substr(this.audio.src.indexOf('assets'),this.audio.src.length - this.audio.src.indexOf('assets'));
    const songPath = this.song.path.substr(this.song.path.indexOf('assets'),this.song.path.length - this.song.path.indexOf('assets'));
    if (audioPath != songPath) {
      this.audio.src = this.song.path;
    }

    if (this.isPlaying) {
      this.playButton.nativeElement.setAttribute("class", "fa fa-play-circle play-btn");
      this.playerService.setOnPause(true,this.song);
      this.audio.pause();
    }
    else {
      this.playButton.nativeElement.setAttribute("class", "fa fa-pause-circle play-btn");
      this.playerService.setOnPause(false, this.song);
      this.audio.play();
    }
    this.isPlaying = !this.isPlaying;
  }

  private formattedTime(currentTime: number): string {
    let seconds: string = Math.floor(currentTime % 60) > 9 ?
      `${Math.floor(currentTime % 60).toFixed(0)}` : `0${Math.floor(currentTime % 60).toFixed(0)}`;

    return `${Math.floor(currentTime / 60)}:${seconds}`;
  }

  get duration(): string {
    if (this.audio.duration)
      return this.formattedTime(this.audio.duration);
    return "";
  }

  get currentTime(): string {
    return this.formattedTime(this.audio.currentTime);
  }

}
