import { Component, OnInit } from '@angular/core';
import { HotelsService } from 'src/app/_services/hotels.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { HotelList } from 'src/app/_models/hotel_list';
import { Router } from '@angular/router';


@Component({
  selector: 'app-hotels',
  templateUrl: './hotels.component.html',
  styleUrls: ['./hotels.component.scss']
})
export class HotelsComponent implements OnInit {

  hotels: HotelList[];

  constructor(private hotelsService: HotelsService, private router: Router,
    private alertify: AlertifyService) { }

  ngOnInit(): void {
  }

  search() {
    const queryParams = {};
    const destination = (document.querySelector('input#destination') as HTMLInputElement).value;
    if (destination && destination.length > 0) {
      Object.assign(queryParams, { name: destination });
    }

    this.router.navigate([], { queryParams, queryParamsHandling: 'merge' });
  }
}
