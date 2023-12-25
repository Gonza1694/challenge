import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../../services/weather.service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css'],
})
export class WeatherComponent implements OnInit {
  selectedCity: string = "";
  weatherData: any;

  cities: string[] = ["San Miguel de Tucumán", "Buenos Aires"];

  constructor(private weatherService: WeatherService) { }

  ngOnInit() {
  }

  getWeather() {
    if (this.selectedCity) {
      this.weatherService.getWeather(this.selectedCity).subscribe((data) => {
        this.weatherData = data;
        console.log(this.weatherData);
      });
    } else {
      alert("Por favor, seleccione una ciudad antes de consultar.");
    }
  }
}
