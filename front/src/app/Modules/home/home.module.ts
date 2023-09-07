import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { RouterModule, Routes } from '@angular/router';
import { TrendingEventsComponent } from './components/trending-events/trending-events.component';
import { GalleriaModule } from 'primeng/galleria';
import { FormsModule ,ReactiveFormsModule } from '@angular/forms';
import { ComingSoonComponent } from './components/coming-soon/coming-soon.component';
const routes:Routes =[
  {
    path:'', component: HomeComponent,

  }
]
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    GalleriaModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes)
  ],
  declarations: [
    TrendingEventsComponent,
    ComingSoonComponent,
    HomeComponent,
  ]
})
export class HomeModule { }
