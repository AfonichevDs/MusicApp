import { Playlist } from './../_models/Playlist';
import { Album } from './../_models/Album';
import { Artist } from './../_models/Artist';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SearchResult } from '../_models/SearchResult';
import { Song } from '../_models/Song';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  searchResult: SearchResult;
  artists: Array<Array<Artist>>;
  albums: Array<Array<Album>>;
  songs: Song[] = new Array<Song>();
  playlists: Array<Array<Playlist>>;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.searchResult = data['searchResult'];
    });
    this.artists = this.splitArrayIntoGroups<Artist>(this.searchResult.artists, 2);
    this.albums = this.splitArrayIntoGroups<Album>(this.searchResult.albums, 3);
    this.songs = this.searchResult.songs;
    this.playlists = this.splitArrayIntoGroups<Playlist>(this.searchResult.playlists, 3);
  }

  splitArrayIntoGroups<T>(arr:Array<T>, length: number): T[][] {
    let result = new Array<Array<T>>();
    for(let y = 0; y < arr.length / length + 1; y++) {
      let row:T[]  = new Array<T>();
      row = arr.slice(y, (arr.length / (y + 1)) < length ? arr.length / (y + 1) : length);
      result.push(row);
    }
    return result;
  }
}
