import { GuestBookingService } from './../../../_services/guest-booking.service';
import { guestHouseDetail } from './../../../_models/guest_house';
import { GuestService } from './../../../_services/guest.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { hotel_detail, Room } from '@app/app/_models/hotel_detail';
import { HotelBookingService } from '@app/app/_services/hotel-booking.service';
import { HotelsService } from '@app/app/_services/hotels.service';

@Component({
  selector: 'app-guestbooking',
  templateUrl: './guestbooking.component.html',
  styleUrls: ['./guestbooking.component.scss']
})
export class GuestbookingComponent implements OnInit {

  guestHouseDetail:guestHouseDetail;
  room:Room;
  booking_confirm=false;
  first_name = '';
  last_name = '';
  email = '';
  phone_number = '';
  country = '';
  city = '';
  payment_amount = '';




    addBook = new FormGroup({
      first_name: new FormControl(''),
      last_name: new FormControl(''),
      email: new FormControl(''),
      phone_number: new FormControl(''),
      country: new FormControl(''),
      city: new FormControl(''),
      special_requirements: new FormControl(''),
      payment_amount: new FormControl(0),



    })

    constructor(private route:ActivatedRoute, private book:GuestBookingService, private guestHouseSevice:GuestService ) { }

    ngOnInit(): void {
      this.getGuestHouseByid();
    }

    collectBook(){

      console.log(this.addBook.value);
      this.book.saveBook(this.addBook.value).subscribe( (res)=>{

        this.booking_confirm=true;
      })
     // this.addBook.reset();
    }


    getGuestHouseByid(){
      const guest_id = this.route.snapshot.paramMap.get('id');
      this.guestHouseSevice.getGuestHouseById(guest_id).subscribe( (res)=>{
        this.guestHouseDetail = res;
      })

    }

}
