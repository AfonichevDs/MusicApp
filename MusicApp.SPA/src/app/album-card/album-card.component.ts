import { Component, OnInit, Input } from '@angular/core';
import { Album } from '../_models/Album';

@Component({
  selector: 'app-album-card',
  templateUrl: './album-card.component.html',
  styleUrls: ['./album-card.component.css']
})
export class AlbumCardComponent implements OnInit {
  @Input() album: Album;
  constructor() { }

  ngOnInit() {
  }

}
