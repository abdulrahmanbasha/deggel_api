import { guestHouseList } from './../../../_models/guest_list';

import { Component, OnInit } from '@angular/core';
import { PaginatedResult, Pagination } from '@app/app/_models/pagination';
import { AlertifyService, DataService } from '@app/app/_services';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-guestlist',
  templateUrl: './guestlist.component.html',
  styleUrls: ['./guestlist.component.scss']
})
export class GuestlistComponent implements OnInit {
  guestHouses: guestHouseList[];
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

    this.loadGuesteHouse();
  });


    //console.log(this.filterParams);
    //this.loadHotels();
  }

  searchGuestHouse(){
    this.filterParams=[];
     if(this.model){
      this.filterParams.push({name: 'hotel_name', value: this.model.destination});
      this.loadGuesteHouse();
    }
  }

  filterStars(value:string){
        this.filterParams=[];
        this.filterParams.push({name:'stars', value: value})
        this.loadGuesteHouse();
  }

  loadGuesteHouse() {

    // this.filterParams.FromDate = this.datePipe.transform(this.filterParams.FromDate, 'M/d/yyyy');
    // this.filterParams.ToDate = this.datePipe.transform(this.filterParams.ToDate, 'M/d/yyyy');
    this.pagination = JSON.parse(
      '{ "currentPage": 1, "itemsPerPage": 50, "totalItems": 3, "totalPages": 3 }'
    );
    this.dataService
      .get<guestHouseList>('GuestHouse/GetGuestHouseSummary/', { page: this.pagination.currentPage, size: this.pagination.itemsPerPage, filters: this.filterParams })
      .subscribe(res => {
        this.showSpinner = false;
        this.guestHouses = res.result;
        this.pagination = res.pagination;
      },
        error => {
          this.alertify.error(error.error);
        }
      );
  }

}
