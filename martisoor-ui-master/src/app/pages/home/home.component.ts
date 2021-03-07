import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: []

})
export class HomeComponent implements OnInit {
  model: any={};
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  searchHotels(){
    this.router.navigate(['/search'], { queryParams: { city: this.model.city ,rooms: this.model.rooms,checkinOut: this.model.checkinout,searchType:""} });
  }

}
