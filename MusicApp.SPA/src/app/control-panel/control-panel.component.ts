import { AuthService } from './../_services/auth.service';
import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-control-panel',
  templateUrl: './control-panel.component.html',
  styleUrls: ['./control-panel.component.css']
})
export class ControlPanelComponent implements OnInit {
  @Output() toggled = new EventEmitter<boolean>();

  isHidden: boolean = false;
  isCollapsed: boolean = false;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  toggleSideBar() {
    this.isHidden = !this.isHidden;
    this.toggled.emit(this.isHidden);
  }

  logOut() {
    this.authService.logOut();
    this.router.navigate(['/login']);
  }
}
