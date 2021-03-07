import { guestHouseDetail, RoomGuest } from './../../../_models/guest_house';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataService } from '@app/app/_services';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-guestdetails',
  templateUrl: './guestdetails.component.html',
  styleUrls: ['./guestdetails.component.scss']
})
export class GuestdetailsComponent implements OnInit {
  guestHouse: guestHouseDetail;
  room: RoomGuest;

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
    this.dataService.getSingle<guestHouseDetail>(`GuestHouse/GetGuestHouse/${detailId}`).subscribe(
      data => this.guestHouse = data
    );
  }

  onSubmit(myform: NgForm) {
    this.review_name = (myform.controls['name'].value);
    this.review_comment = (myform.controls['comment'].value);
  }

}
