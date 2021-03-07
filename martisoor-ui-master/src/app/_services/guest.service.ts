import { guestHouseDetail } from './../_models/guest_house';
import { guestHouseList } from './../_models/guest_list';
import { Injectable } from '@angular/core';
import { environment } from '../../../src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import {map, catchError} from 'rxjs/operators';

import { PaginatedResult } from '../../../src/app/_models/pagination';
import { ErrorHandler } from "@angular/core";


@Injectable({
  providedIn: 'root'
})
export class GuestService {




  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }



  /*getHotellist(): Observable<HotelList[]> {
    return this.http.get<HotelList[]>(this.baseUrl + 'Hotel/GetHotelSummary/');
  }*/

  getHotellist(page?, itemsPerPage?, filterParams?, sortParams?): Observable<PaginatedResult<guestHouseList>> {
    const paginatedResult = new PaginatedResult<guestHouseList>();
    let params = new HttpParams();
    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }
    if (filterParams != null) {
      if (typeof filterParams.FromDate === 'undefined') {
        filterParams.FromDate = '';
        // incomeParams.FromDate = null;
      }
      if (typeof filterParams.ToDate === 'undefined') {
        filterParams.ToDate = '';
      }
      // params = params.append('Pagination_name', filterParams.Pagination_name);
      // params = params.append('reference', filterParams.reference);
      // params = params.append('FromDate', filterParams.FromDate);
      // params = params.append('ToDate', filterParams.ToDate);
      // params = params.append('orderBy', filterParams.orderBy);
      console.log(params);
    }
    return this.http.get<guestHouseList[]>(this.baseUrl + 'GuestHouse/GetGuestHouseSummary/', {observe: 'response', params})
    .pipe (
      map(response => {
        paginatedResult.result = response.body;
        if (response.headers.get('Pagination') != null) {
          paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }
        return paginatedResult;
      })
    );
  }

  // getClientProfile(id): Observable<Client_profile> {
  //   return this.http.get<Client_profile>(this.baseUrl + 'clients/ClientProfile/' + id);
  // }

  getHotelById(id):Observable<any>{
    const url = `${this.baseUrl}Hotel/GetHotel/${id}`;
    return this.http.get(url)
    }




    getGuestHouseById(id):Observable<guestHouseDetail>{
      return this.http.get<guestHouseDetail>(`${this.baseUrl}GuestHouse/GetGuestHouse/${id}`)
    }
}
