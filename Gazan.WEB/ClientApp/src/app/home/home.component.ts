import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  startLat = 49.994507;
  startLng = 36.145742;
  markers: Marker[] = [{ lat: 49.994507, lng: 36.145742 }, { lat: 49.9546, lng: 36.135710 }, { lat: 49.974550, lng: 36.185710 }, { lat: 49.914550, lng: 36.185710 }];
}
export interface Marker {
  lat: number;  
  lng: number;
}
