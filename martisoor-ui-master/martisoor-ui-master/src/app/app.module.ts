import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { HotelsComponent } from './pages/Hotels/hotels/hotels.component';
import { AboutComponent } from './pages/About/about/about.component';
import { TopNavComponent } from './pages/layout/top-nav/top-nav.component';
import { FooterComponent } from './pages/layout/footer/footer.component';
import { HotelsService } from './_services/hotels.service';
import { AlertifyService, DataService } from './_services/index';
import { HttpClientModule } from '@angular/common/http';
import { HotelsListPartialComponent } from './pages/Hotels/hotels-list-partial/hotels-list-partial.component';
import { LoadingSpinnerComponent } from './pages/loading-spinner/loading-spinner.component';
import {NgxPaginationModule} from 'ngx-pagination';
import { HoteldetailsComponent } from './pages/Hotels/hoteldetails/hoteldetails.component';
import { HotelbookingComponent } from './pages/Hotels/hotelbooking/hotelbooking.component';
import { HotelRoomComponent } from './pages/Hotels/hotel-room/hotel-room.component';
import { HotelsListPartial2Component } from './pages/Hotels/hotels-list-partial2/hotels-list-partial2.component';
import { FormsModule } from '@angular/forms';
import { GuestlistComponent } from './pages/Guesthouse/guestlist/guestlist.component';
import { GuestdetailsComponent } from './pages/Guesthouse/guestdetails/guestdetails.component';
import { HouselistComponent } from './pages/house/houselist/houselist.component';
import { HousedetailsComponent } from './pages/house/housedetails/housedetails.component';
import { ContactComponent } from './pages/contact/contact/contact.component';
import { EListComponent } from './pages/eventhall/e-list/e-list.component';
import { EDetailsComponent } from './pages/eventhall/e-details/e-details.component';
import { FQAComponent } from './pages/fqa/fqa.component';
import { TermsAndConditionComponent } from './pages/terms-and-condition/terms-and-condition.component';
import { BlogComponent } from './pages/blog/blog.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HotelsComponent,
    AboutComponent,
    TopNavComponent,
    FooterComponent,
    HotelsListPartialComponent,
    LoadingSpinnerComponent,
    HoteldetailsComponent,
    HotelbookingComponent,
    HotelRoomComponent,
    HotelsListPartial2Component,
    GuestlistComponent,
    GuestdetailsComponent,
    HouselistComponent,
    HousedetailsComponent,
    ContactComponent,
    EListComponent,
    EDetailsComponent,
    FQAComponent,
    TermsAndConditionComponent,
    BlogComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgxPaginationModule,
    FormsModule,
    ReactiveFormsModule
    
  ],
  providers: [
    HotelsService,
    DataService,
    AlertifyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
