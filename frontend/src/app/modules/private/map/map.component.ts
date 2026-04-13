import { Component, OnInit, OnDestroy, Output, EventEmitter, Input, AfterViewInit } from '@angular/core';
import * as L from 'leaflet';
import { EstabelecimentoService } from 'src/app/core/services/estabelecimento.service';
L.Icon.Default.imagePath = 'assets/leaflet/'

@Component({
    selector: 'app-map',
    templateUrl: './map.component.html',
    styleUrls: ['./map.component.css'],
    standalone: false
})
export class MapComponent implements OnInit, AfterViewInit  {

  private map!: L.Map
    markers: L.Marker[] = [
    ];

  constructor(private estabelecimentoService: EstabelecimentoService) {  }

  ngOnInit(): void {
    this.addMarkers();
  }

  ngAfterViewInit(): void {
    this.userLocation();
    //this.initializeMap();
    //this.addMarkers();
    //this.centerMap();
  } 

  onMapClick(event: any) {
    L.popup()
    .setLatLng(event.latlng)
    .setContent("You clicked the map at " + event.latlng.toString())
    .openOn(this.map)
  }

  private initializeMap() {
    const baseMapURl = 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png'
    this.map = L.map('map');
    L.tileLayer(baseMapURl).addTo(this.map);
    L.popup({autoPan: true}).openPopup();
  }

  private addMarker(latitude: number, longitude: number) {
    // Add your marker to the map
    this.markers.push(L.marker([latitude, longitude]));
  }

  private addMarkers() {
    // Add your markers to the map
    //this.markers.forEach(marker => marker.addTo(this.map));

    const locais: any[] = []; /*[
      { nome: 'Brasília', lat: -15.793889, lng: -47.882778 },
      { nome: 'São Paulo', lat: -23.55052, lng: -46.633308 },
      { nome: 'Rio de Janeiro', lat: -22.906847, lng: -43.172896 }
    ];*/

    this.estabelecimentoService.getBuscarCordenada().subscribe(locais => {
      locais.forEach(local => {
        L.marker([local.latitude, local.longitude])
          .addTo(this.map)
          .bindPopup(`
            <div class="popup-content">
              <img src="hospital_base.jpg" alt="Hospital de Base">
              <h3>${local.endereco}</h3>
              <button onclick="alert('Mais informações sobre o Hospital de Base')">Detalhes</button>
            </div>`)
          .openPopup();
      });
    })

  }

  private centerMap() {
    // Create a LatLngBounds object to encompass all the marker locations
    const bounds = L.latLngBounds(this.markers.map(marker => marker.getLatLng()));
    
    // Fit the map view to the bounds
    this.map.fitBounds(bounds);
  }

  private userLocation() {
    navigator.geolocation.getCurrentPosition((position) => {
      this.addMarker(position.coords.latitude,position.coords.longitude);
      this.initializeMap();
      this.addMarkers();
      this.centerMap();
      console.log(`Latitude:${position.coords.latitude}, Longitude:${position.coords.longitude}`)
    },
    (err) => {
      console.log(err)
    })
  }

}
