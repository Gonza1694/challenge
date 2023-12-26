import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HistoricService {
  private apiUrl = 'http://localhost:5227/Historic';

  constructor(private http: HttpClient) { }

  getHistoricWeather(city: string): Observable<any> {
    const url = `${this.apiUrl}?city=${city}`;
    return this.http.get(url);
  }
}
