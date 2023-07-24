import { Component, OnInit, OnDestroy, Output, EventEmitter, Input, AfterViewInit } from '@angular/core';
import * as L from 'leaflet';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements AfterViewInit {

  private map: any;

  private initMap(): void {
    this.map = L.map('map', {
      center: [ 39.8282, -98.5795 ],
      zoom: 3
    });

    const tiles = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 18,
      minZoom: 3,
      attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    });

    tiles.addTo(this.map);
  }

  constructor() {}

  ngAfterViewInit(): void {
    this.initMap();
    var marker = L.marker([27.2, 89.95], {
      draggable: true
    }).addTo(this.map);
  }

  onMapClick(event: any) {
    L.popup()
    .setLatLng(event.latlng)
    .setContent("You clicked the map at " + event.latlng.toString())
    .openOn(this.map)
  }

}
