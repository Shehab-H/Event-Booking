import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path:'event/:id',
  loadChildren:()=> import('./Modules/event-booking/event-booking.module').then(m=>m.EventBookingModule)}
];
@NgModule({
  imports: [RouterModule.forRoot(routes,{anchorScrolling:'enabled'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
