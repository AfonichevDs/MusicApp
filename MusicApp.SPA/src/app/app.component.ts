import { AuthService } from './_services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
  hasLeftMargin:boolean = true;

  constructor(public authService: AuthService) {}

  ngOnInit() {
    const token = localStorage.getItem('local');
    if(token) {
      this.authService.decodedToken = this.authService.jwtHelper.decodeToken(token);
    }
  }

  changeMargin(hasLeftMargin:boolean) {
    this.hasLeftMargin = hasLeftMargin;
    //TODO: Use this property in ngClass for div main
  }

}
