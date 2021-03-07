import { Component, Input, OnInit } from '@angular/core';
import { HotelsService } from 'src/app/_services/hotels.service';
import { HotelList } from 'src/app/_models/hotel_list';
import { Filter, Pagination } from 'src/app/_models/pagination';
import { PaginatedResult } from 'src/app/_models/pagination';
import { HoteldetailsComponent } from 'src/app/pages/Hotels/hoteldetails/hoteldetails.component';

import { DataService, AlertifyService } from '@services/index';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-hotels-list-partial',
  templateUrl: './hotels-list-partial.component.html',
  styleUrls: ['./hotels-list-partial.component.scss']
})
export class HotelsListPartialComponent implements OnInit {
  @Input() model: any;
  hotels: HotelList[];
  filterParams: Filter[] = [];
  sortParams: any = {};
  showSpinner = true;
  pagination: Pagination;
  paginatedResult: PaginatedResult<Pagination>;

  constructor(private dataService: DataService, private route: ActivatedRoute,
    private alertify: AlertifyService) { }
  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.filterParams = [];

      if (params['name']) {
        this.filterParams.push({ name: 'hotel_name', value: params['name'] });
      }

      this.loadHotels();
    });
  }

  loadHotels() {
    // this.filterParams.FromDate = this.datePipe.transform(this.filterParams.FromDate, 'M/d/yyyy');
    // this.filterParams.ToDate = this.datePipe.transform(this.filterParams.ToDate, 'M/d/yyyy');
    this.pagination = JSON.parse(
      '{ "currentPage": 1, "itemsPerPage": 50, "totalItems": 3, "totalPages": 3 }'
    );
    this.dataService
      .get<HotelList>('Hotel/GetHotelSummary/', { page: this.pagination.currentPage, size: this.pagination.itemsPerPage, filters: this.filterParams })
      .subscribe(
        res => {
          this.showSpinner = false;
          this.hotels = res.result;
          this.pagination = res.pagination;
        },
        error => {
          this.alertify.error(error.error);
        }
      );
  }
}
