import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PingService {

  private url: string;

  constructor(private http: HttpClient) {
    this.url = environment.settings.backend;
   }
   getAll() {
    return this.http.get<any>(this.url);
  }
}
