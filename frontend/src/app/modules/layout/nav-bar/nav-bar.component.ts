import { Component, OnInit } from '@angular/core';
import { MatNavList } from "@angular/material/list";
import { MatSidenav, MatSidenavContainer } from "@angular/material/sidenav";

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
  standalone: false,
})
export class NavBarComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
