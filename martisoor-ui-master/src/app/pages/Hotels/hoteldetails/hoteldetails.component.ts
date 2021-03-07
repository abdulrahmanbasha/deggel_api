import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';

import { hotel_detail, Room } from 'src/app/_models/hotel_detail';
import { DataService } from '@app/app/_services';

@Component({
  selector: 'app-hoteldetails',
  templateUrl: './hoteldetails.component.html',
  styleUrls: ['./hoteldetails.component.scss']
})
export class HoteldetailsComponent implements OnInit {
  hotel: hotel_detail;
  room: Room;

  isLoading: boolean;

  review_name;
  review_comment;

  constructor(private route: ActivatedRoute, private dataService: DataService) { }

  ngOnInit() {
    this.loaddetails();
  }

  loaddetails() {
    this.isLoading = true;
    const detailId = this.route.snapshot.paramMap.get('id');
    this.dataService.getSingle<hotel_detail>(`Hotel/GetHotel/${detailId}`).subscribe(
      data => this.hotel = data
    );
  }

  onSubmit(myform: NgForm) {
    this.review_name = (myform.controls['name'].value);
    this.review_comment = (myform.controls['comment'].value);
  }
}
