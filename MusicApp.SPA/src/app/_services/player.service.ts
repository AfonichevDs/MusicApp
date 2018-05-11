import { Observable, Observer, Subject } from 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { Song } from '../_models/Song';

@Injectable()
export class PlayerService {

    private currentSong = new Subject<Song>();
    private stop = new Subject<{play: boolean, song: Song}>();

    constructor() {
    }

    setCurrentSong(song: Song) {
        this.currentSong.next(song);
    }

    getCurrentSong():Observable<Song> {
        return this.currentSong.asObservable();
    }

    setOnPause(play:boolean, song: Song) {
        this.stop.next({play: play, song:song});
    }

    isOnPause():Observable<{play: boolean, song: Song}> {
        return this.stop.asObservable();
    }
}
