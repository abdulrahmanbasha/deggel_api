import { Injectable, ErrorHandler } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { environment } from '@environment/environment';
import { Pagination, PaginatedResult, PagingOptions } from '@models/pagination';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  get<T>(endpoint: string, pagingOptions?: PagingOptions) {
    let query = '';
    if (pagingOptions) {
      query += pagingOptions.page ? `?page=${pagingOptions.page}` : '';
      query += pagingOptions.size > 0 ? `&size=${pagingOptions.size}` : '';

      if (pagingOptions.filters && pagingOptions.filters.length > 0) {
        pagingOptions.filters.forEach(filter => {
          query += `&q=${filter.name}=${filter.value}`;
        });
      }
    }

    return this.http.get<T[]>(this.baseUrl + endpoint + query, { observe: 'response' })
      .pipe(map(response => {
        let paginatedResult = new PaginatedResult<T>();
        paginatedResult.result = response.body;
        paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));

        return paginatedResult;
      }));
  }

  getSingle<T>(endpoint: string) {
    return this.http.get<T>(this.baseUrl + endpoint);
  }

  post<T = {}>(endpoint: string, data?: T) {
    return this.http.post<T>(this.baseUrl + endpoint, data);
  }

  update<T = {}>(endpoint: string, data: T) {
    return this.http.put(this.baseUrl + endpoint, data);
  }

  delete(endpoint: string, id?: string | number) {
    return this.http.delete(this.baseUrl + endpoint);
  }
}
