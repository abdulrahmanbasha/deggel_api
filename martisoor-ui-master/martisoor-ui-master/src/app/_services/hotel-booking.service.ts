import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HotelBookingService {
  url="http://www.deggel.com/api/Booking/post"
  constructor( private http:HttpClient){ }

  saveBook(data)
  {
    return this.http.post(this.url,data);
  }
}
