import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdmindashboardComponent } from './admindashboard/admindashboard.component';
import { RouterModule, Routes } from '@angular/router';
import { TabViewModule } from 'primeng/tabview';

const routes:Routes =[
  {
    path:'', component: AdmindashboardComponent ,
  }
  ,
]

@NgModule({
  imports: [
    TabViewModule,
    CommonModule,
    RouterModule.forChild(routes)
  ],
  declarations: [AdmindashboardComponent]
})
export class AdminModule { }
