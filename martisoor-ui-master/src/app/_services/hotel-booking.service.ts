import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HotelBookingService {
  url=environment.apiUrl;
  constructor( private http:HttpClient){ }

  saveBook(data)
  {
    return this.http.post(this.url +"Booking/post",data);
  }
}
