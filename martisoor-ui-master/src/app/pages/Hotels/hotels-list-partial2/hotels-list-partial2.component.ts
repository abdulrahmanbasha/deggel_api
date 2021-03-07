import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { HotelsService } from 'src/app/_services/hotels.service';
import { HotelList } from 'src/app/_models/hotel_list';
import { Pagination } from 'src/app/_models/pagination';
import { PaginatedResult } from 'src/app/_models/pagination';

import { DataService, AlertifyService } from '@services/index';

@Component({
  selector: 'app-hotels-list-partial2',
  templateUrl: './hotels-list-partial2.component.html',
  styleUrls: ['./hotels-list-partial2.component.scss']
})
export class HotelsListPartial2Component implements OnInit {
  hotels: HotelList[];
  @Input() model: any;
    filterParams: any = {};
  sortParams: any = {};
  showSpinner = true;
  pagination: Pagination;
  paginatedResult: PaginatedResult<Pagination[]>;

  constructor(private dataService: DataService, private alertify: AlertifyService) {
  }
  ngOnInit(): void {
    // this.projects = null;

    this.loadHotels();
  }

  loadHotels() {
    // this.filterParams.FromDate = this.datePipe.transform(this.filterParams.FromDate, 'M/d/yyyy');
    // this.filterParams.ToDate = this.datePipe.transform(this.filterParams.ToDate, 'M/d/yyyy');
    this.pagination = JSON.parse(
      '{ "currentPage": 1, "itemsPerPage": 50, "totalItems": 3, "totalPages": 3 }'
    );
    this.dataService
      .get<HotelList>('Hotel/GetHotelSummary/', { page: this.pagination.currentPage, size: this.pagination.itemsPerPage, filters: this.filterParams })
      .subscribe(res => {
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
