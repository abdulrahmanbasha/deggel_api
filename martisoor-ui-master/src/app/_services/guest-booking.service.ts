import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GuestBookingService {
  url=environment.apiUrl;
  constructor( private http:HttpClient){ }

  saveBook(data)
  {
    return this.http.post(this.url +"Booking/add-guesthousebooking",data);
  }
}
