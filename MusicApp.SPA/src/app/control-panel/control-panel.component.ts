import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-control-panel',
  templateUrl: './control-panel.component.html',
  styleUrls: ['./control-panel.component.css']
})
export class ControlPanelComponent implements OnInit {

  isHidden: boolean = false;
  isCollapsed:boolean = false;
  
  constructor() { }

  ngOnInit() {
  }

  toggleSideBar() {
    this.isHidden = !this.isHidden;
  }

}
