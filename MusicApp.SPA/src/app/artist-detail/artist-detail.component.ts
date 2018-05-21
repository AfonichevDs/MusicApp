import { Album } from './../_models/Album';
import { ArtistDetail } from './../_models/ArtistDetail';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-artist-detail',
  templateUrl: './artist-detail.component.html',
  styleUrls: ['./artist-detail.component.css']
})
export class ArtistDetailComponent implements OnInit {

  artist: ArtistDetail;
  albums: Array<Array<Album>>;
  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.artist = data['artist'];
    });
    this.albums = this.splitArrayIntoGroups(this.artist.albums,3);
  }

  splitArrayIntoGroups(arr:Array<Album>, length: number): Album[][] {
    let result = new Array<Array<Album>>();
    for(let y = 0; y < arr.length / length + 1; y++) {
      let row:Album[]  = new Array<Album>();
      row = arr.slice(y, (arr.length / (y + 1)) < length ? arr.length / (y + 1) : length);
      result.push(row);
    }
    return result;
  }

}
