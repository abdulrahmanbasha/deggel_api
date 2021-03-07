import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HotelList } from '@app/app/_models/hotel_list';
import { PaginatedResult, Pagination } from '@app/app/_models/pagination';
import { AlertifyService, DataService } from '@app/app/_services';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  hotels: HotelList[];
  model: any={};
    filterParams: any = {};
  sortParams: any = {};
  showSpinner = true;
  pagination: Pagination;
  paginatedResult: PaginatedResult<Pagination[]>;

  constructor(private dataService: DataService, private alertify: AlertifyService,private route: ActivatedRoute) {
  }
  ngOnInit(): void {
    // this.projects = null;
  //  this.route.queryParams.subscribe(params=>{
  //    console.log(params['city']);
  //   this.filterParams.q ="city="+params["city"]
  //  })

   this.route.queryParams.subscribe(params => {
    this.filterParams = [];

    if (params['city']) {
      this.filterParams.push({ name: 'city', value: params['city'] });
    }
    if(params['rooms']){
      this.filterParams.push({name: 'rooms', value: params['rooms']})
    }

    this.loadHotels();
  });


    //console.log(this.filterParams);
    //this.loadHotels();
  }

  searchHotel(){
    this.filterParams=[];
     if(this.model){
      this.filterParams.push({name: 'hotel_name', value: this.model.destination});
      this.loadHotels();
    }
  }

  filterStars(value:string){
        this.filterParams=[];
        this.filterParams.push({name:'stars', value: value})
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
