import { Component, OnInit, OnDestroy, Output, EventEmitter, Input, AfterViewInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import * as L from 'leaflet';
import { EstabelecimentoService } from 'src/app/core/services/estabelecimento.service';
import { CadastrarHospitalComponent } from '../hospital/cadastrar-hospital/cadastrar-hospital.component';
L.Icon.Default.imagePath = 'assets/leaflet/'

@Component({
    selector: 'app-map',
    templateUrl: './map.component.html',
    styleUrls: ['./map.component.css'],
    standalone: false
})
export class MapComponent implements OnInit, AfterViewInit  {

  @ViewChild(CadastrarHospitalComponent) 
  hospitalComponent!: CadastrarHospitalComponent;

  private map!: L.Map
    markers: L.Marker[] = [
    ];

  constructor(private estabelecimentoService: EstabelecimentoService, private router: Router, private changeDetector: ChangeDetectorRef) {  }

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
    (window as any).Hello = this.Hello.bind(this);

    const locais: any[] = [];

    this.estabelecimentoService.getAll().subscribe(locais => {
      locais.forEach(local => {
        L.marker([Number(local.latitude), Number(local.longitude)])
          .addTo(this.map)
          .bindPopup(`
            <div class="popup-content">
              <h3>${local.nome}</h3>
              <button id="detalhar" onclick="Hello(${local.id})">Detalhes</button>
            </div>`)
          .openPopup();
      });
    })

  }

  private Hello(id: any) {
    localStorage.setItem('hospitalCodigo', JSON.stringify(id));
    localStorage.setItem('tipo', "Detalhar");
    this.router.navigate(['/hospital/detalhar']);
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
