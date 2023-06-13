import { Component, OnInit } from '@angular/core';
import { EventService } from 'src/app/Services/Event.service';
import { IEvent } from 'src/app/View Models/Response Models/IEvent';
import { IVenue } from 'src/app/View Models/Response Models/IVenue';
@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent implements OnInit {
  event : IEvent;
 _venues : IVenue[];

  showdays:Date[]=[];

  constructor(private eventService: EventService){
    this.event= eventService.GetEventById(0);
    this._venues=this.event.venues;
  }

  get Venues() : string[]{
    return this._venues.map(venue =>venue.name);
  }


  getFormattedDates(): string[] {
    return this.showdays.map(date => date.toLocaleDateString());
  }

  VenueSelected(newVenue:string){
    console.log(newVenue);
    const venue = this.event.venues.find(v=>v.name==newVenue);
    if(venue){
      this.eventService.GetEventIterations(this.event.id,venue.id)
    }
    else{
      throw new Error("venue is not available anymore");
    }
  }

  ShowDaySelected(newShowDay:string){
    console.log(newShowDay);
  }

  ShowTimeSelected(newShowTime:string){
    console.log(newShowTime);
  }
  LoungeSelected(newLounge:string){
    console.log(newLounge);
  }


  ngOnInit(): void {
  }
}
