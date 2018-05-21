import { Router } from '@angular/router';
import { SearchOptions } from './../_models/SearchOptions';
import { SearchService } from './../_services/search.service';
import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  searchTerm: string;
  searchOptions: SearchOptions = new SearchOptions();

  constructor(private router: Router) { }

  ngOnInit() {
  }

  search() {
      this.router.navigate(['/search', this.searchTerm], {
        queryParams: {
          searchArtists: this.searchOptions.searchArtists,
          searchAlbums: this.searchOptions.searchAlbums,
          searchSongs: this.searchOptions.searchSongs,
          searchPlaylists: this.searchOptions.searchPlaylists
        }
      });
  }

}
