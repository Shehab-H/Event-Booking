import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EventComponent } from './Components/event/event.component';
import { ShowTimesComponent } from './Components/event/ShowTimes/ShowTimes.component';
import { RouterModule, Routes } from '@angular/router';
import { EventService } from 'src/app/Services/Event.service';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
const routes:Routes =[
  {
    path:'', component: EventComponent
  }
]

@NgModule({
  declarations: [
    EventComponent,
    ShowTimesComponent
  ],
  providers:[
    EventService
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MatButtonModule,
    MatIconModule,
  ]
})
export class EventBookingModule { }
