import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PaymentComponent } from './Components/Payment/Payment.component';
import { ErrorComponent } from './Components/Error/Error.component';

const routes: Routes = [
  {path:'event/:id',
  loadChildren:()=> import('./Modules/event-booking/event-booking.module').then(m=>m.EventBookingModule)},
  {
    path: 'payment/:id/:seats',component:PaymentComponent
  },
  {
    path:'error' , component:ErrorComponent
  },
  {
    path:'', loadChildren:()=> import('./Modules/home/home.module').then(m=>m.HomeModule)
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes,{anchorScrolling:'enabled'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
