import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PaymentComponent } from './Components/Payment/Payment.component';
import { ErrorComponent } from './Components/Error/Error.component';
import { DefultLayoutComponent } from './Components/DefultLayout/DefultLayout.component';

const routes: Routes = [
  {
    path:'',
    component:DefultLayoutComponent,
    children: [
      { path: '', loadChildren:()=> import('./Modules/home/home.module').then(m=>m.HomeModule)},
      {
        path:'admin', loadChildren:()=> import('./Modules/admin/admin.module').then(m=>m.AdminModule)
      }
    ]
  },
  {path:'event/:id',
  loadChildren:()=> import('./Modules/event-booking/event-booking.module').then(m=>m.EventBookingModule)},
  {
    path: 'payment/:id/:seats',component:PaymentComponent
  },
  {
    path:'error' , component:ErrorComponent
  },
  {
    path:'user', loadChildren:()=> import('./Modules/users/users/users.module').then(m=>m.UsersModule)
  },

];
@NgModule({
  imports: [RouterModule.forRoot(routes,{anchorScrolling:'enabled'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
