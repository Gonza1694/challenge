import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../../services/weather.service';
import { HistoricService } from '../../services/historic.service';
import { forkJoin, Observable, of } from 'rxjs';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css'],
})
export class WeatherComponent implements OnInit {
  selectedCity: string = '';
  weatherData: any;
  showHistoric: boolean = false;
  cities: string[] = ['San Miguel de Tucumán', 'Yerba Buena'];
  weatherHistoric: any[] = [];
  loading: boolean = false;

  constructor(private weatherService: WeatherService, private historicService: HistoricService) { }

  ngOnInit() {
    this.loading = false;
  }

  getWeather() {
    if (this.selectedCity) {
      this.loading = true;

      const weatherSubscription = this.weatherService.getWeather(this.selectedCity);
      const historicSubscription: Observable<any[]> = this.showHistoric
        ? this.historicService.getHistoricWeather(this.selectedCity)
        : of([]);

      forkJoin([weatherSubscription, historicSubscription]).subscribe(
        ([weatherData, weatherHistoric]) => {
          this.weatherData = weatherData;
          this.weatherHistoric = weatherHistoric;
          this.loading = false;
        },
        (error) => {
          console.error('Error:', error);
          this.loading = false;
        }
      );
    } else {
      alert('Por favor, seleccione una ciudad antes de consultar.');
    }
  }
}
