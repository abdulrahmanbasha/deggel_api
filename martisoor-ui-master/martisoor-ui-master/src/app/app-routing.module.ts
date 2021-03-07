import { NgModule } from '@angular/core';  
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { HotelsComponent } from './pages/Hotels/hotels/hotels.component';
import { HoteldetailsComponent } from './pages/Hotels/hoteldetails/hoteldetails.component';
import { HotelbookingComponent } from './pages/Hotels/hotelbooking/hotelbooking.component';
import { GuestlistComponent } from './pages/Guesthouse/guestlist/guestlist.component'; 
import { HouselistComponent } from './pages/house/houselist/houselist.component';
import { HousedetailsComponent } from './pages/house/housedetails/housedetails.component';
import { AboutComponent } from './pages/About/about/about.component';
import { ContactComponent } from './pages/contact/contact/contact.component';
import { EListComponent } from './pages/eventhall/e-list/e-list.component';
import { EDetailsComponent } from './pages/eventhall/e-details/e-details.component';
import { GuestdetailsComponent } from './pages/Guesthouse/guestdetails/guestdetails.component';
import { FQAComponent } from './pages/fqa/fqa.component';
import { TermsAndConditionComponent } from './pages/terms-and-condition/terms-and-condition.component';
import { BlogComponent } from './pages/blog/blog.component';


const routes: Routes = [
  {path:'', component: HomeComponent}, 
  {path:'home', component: HomeComponent},
  {path:'about', component: AboutComponent},
  {path:'hotel', component: HotelsComponent},
  {path:'guest', component: GuestlistComponent},
  {path:'hoteldetails/:id', component: HoteldetailsComponent},
  {path:'hotel-booking/:id', component: HotelbookingComponent},
  {path:'house', component: HouselistComponent},
  {path:'houseinfo', component: HousedetailsComponent},
  {path:'contact', component: ContactComponent},
  {path:'event', component: EListComponent},
  {path:'eventinfo', component: EDetailsComponent},
  {path:'guestinfo', component: GuestdetailsComponent},
  {path:'FQA', component: FQAComponent},
  {path:'Terms', component: TermsAndConditionComponent},
  {path:'Blog', component: BlogComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
