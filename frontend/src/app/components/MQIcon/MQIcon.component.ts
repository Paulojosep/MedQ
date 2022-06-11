import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-MQIcon',
  templateUrl: './MQIcon.component.html',
  styleUrls: ['./MQIcon.component.css']
})
export class MQIconComponent implements OnInit {

  @Input() icon = "";
  
  constructor() { }

  ngOnInit() {
  }

}
