import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EventComponent } from './Components/event/event.component';
import { ShowTimesComponent } from './Components/event/ShowTimes/ShowTimes.component';
import { SeatingsComponent } from './Components/event/Seatings/Seatings/Seatings.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule  } from '@angular/forms';
import { EventService } from 'src/app/Services/Event.service';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { DropdownModule } from 'primeng/dropdown';
import { TabMenuModule } from 'primeng/tabmenu';
import { TooltipModule } from 'primeng/tooltip';
import {CdkDrag} from '@angular/cdk/drag-drop'
import { ButtonModule } from 'primeng/button';
import { ProgressSpinnerModule } from 'primeng/progressspinner';

const routes:Routes =[
  {
    path:'', component: EventComponent,
  }
  ,
]

@NgModule({
  declarations: [
    EventComponent,
    ShowTimesComponent,
    SeatingsComponent,
  ],
  providers:[
    EventService
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MatButtonModule,
    MatIconModule,
    DropdownModule,
    TabMenuModule,
    FormsModule,
    TooltipModule,
    CdkDrag,
    ButtonModule,
    ProgressSpinnerModule,
  ]
})
export class EventBookingModule {

}
