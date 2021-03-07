import { Component, OnInit, Input } from '@angular/core'; 
import { Room, RoomAmenity } from 'src/app/_models/hotel_detail';

@Component({ 
  selector: 'app-hotel-room',
  templateUrl: './hotel-room.component.html',
  styleUrls: ['./hotel-room.component.scss']
})
export class HotelRoomComponent implements OnInit {
  @Input() rooms: Room[]; 
  r_amenity:RoomAmenity; 

  constructor() { }


  ngOnInit(): void {
  }

  

}