import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { HotelBookingService } from '../../../_services/hotel-booking.service';
import { hotel_detail, Room } from 'src/app/_models/hotel_detail';
import { HotelsService } from 'src/app/_services/hotels.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-hotelbooking',
  templateUrl: './hotelbooking.component.html',
  styleUrls: ['./hotelbooking.component.scss']
})
export class HotelbookingComponent implements OnInit {
hotel:hotel_detail;
room:Room;

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
    payment_amount: new FormControl(0)
  })

  constructor(private route:ActivatedRoute, private book:HotelBookingService, private hotelSevice: HotelsService) { }
  
  ngOnInit(): void {
    this.getRoomByid();
  }

  collectBook(){
    console.log(this.addBook.value);
    this.book.saveBook(this.addBook.value).subscribe( (res)=>{
      console.log("result is here", res)
    })
   // this.addBook.reset();
  }


  getRoomByid(){
    const room_id = this.route.snapshot.paramMap.get('id');
    this.hotelSevice.getRoomByid(room_id).subscribe( (res)=>{
      this.room = res;
    })
     
  }


}

