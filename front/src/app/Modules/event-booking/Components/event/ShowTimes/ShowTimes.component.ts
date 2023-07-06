import { Component, OnInit, OnChanges, Input, SimpleChanges } from '@angular/core';
import { EventService } from 'src/app/Services/Event.service';
import { IEvent } from 'src/app/View Models/Response Models/IEvent';
import { IShowTime } from 'src/app/View Models/Response Models/IShowTime';
import { IVenue } from 'src/app/View Models/Response Models/IVenue';
import { MenuItem } from 'primeng/api';
import { DayDatePipe } from 'src/app/Pipes/day-date/day-date.pipe';
import { Router } from '@angular/router';

@Component({
  selector: 'ShowTimes',
  templateUrl: './ShowTimes.component.html',
  styleUrls: ['./ShowTimes.component.css'],
  providers: [DayDatePipe],
})
export class ShowTimesComponent implements OnInit ,OnChanges{

  @Input() event!: IEvent;

  loading:boolean=false;
  venues: IVenue[] | undefined;

  showDaysItems: MenuItem[] | undefined;

  selectedShowDay:MenuItem | undefined;

  selectedShowTime:MenuItem | undefined;

  showTimesItems: MenuItem[] | undefined;

  selectedVenue: IVenue | undefined;

  eventIterations:IShowTime[] | undefined;

  currentEventIteration:IShowTime |undefined

  constructor(
    private eventService: EventService,
  ) {}

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges){
    console.log(this.event);
    this.loading=true;
    this.showDaysItems=Array.from({ length: 15 }, (_, i) => ({
      label: `Tab ${i + 1}`,
    }));
    this.showTimesItems = Array.from({ length: 15 }, (_, i) => ({
      label: `Tab ${i + 1}`,
    }));
    this.GetVenues();
  }

  GetVenues(){
    this.eventService.getVenues(this.event.id).subscribe((venues) => {
      this.venues = venues;
      this.selectedVenue = this.venues[0];
      this.venueChanged();
    });
  }

  venueChanged(){
    this.getIterations();
  }

  getIterations() {
    this.eventService
      .getEventShowTimes(this.event.id, this.selectedVenue!.id)
      .subscribe((iterations) => {
        this.eventIterations=iterations;
        this.showDaysItems = this.getUniqueShowDates().map<MenuItem>((showday) => {
          return {
            label:showday,
          } as MenuItem;
        });
        this.selectedShowDay=this.showDaysItems[0];
        this.dateChanged(this.selectedShowDay);
      });
  }

  //gets called whenever the date tabmenue changes
  dateChanged(item:MenuItem){
    this.selectedShowDay=item;
    //change showtimes tabmenue model
    this.showTimesItems = this.getUniqueShowTimes(item).map((s)=> {return{
      label:s
    } as MenuItem})
    this.setSelectedShowTime(this.showTimesItems[0])
  }

  setSelectedShowTime(showtime :MenuItem):void{
    this.selectedShowTime=showtime;
    this.setSelectedIteration();
  }

  //filters the current eventShowtimes array to get unique formatted event show days
  getUniqueShowDates():string[]{
    if(this.eventIterations==undefined)
      throw new Error("");
      return this.eventIterations.filter(
        (value,index,self)=> self.findIndex(t=>t.span.start.getDay() === value.span.start.getDay()&&
        t.span.start.getDate()===value.span.start.getDate()) === index
        ).map(i=>this.getFormattedStartDates(i));
  }

  // based on the selected show day filters
  // the current eventShowtimes array to get unique formatted event show times
  getUniqueShowTimes(item:MenuItem):string[]{
    if(this.eventIterations==undefined)
    throw new Error("");

    return this.eventIterations.filter(i=>this.getFormattedStartDates(i)==item.label)
    .map<string>(i=>this.getFormattedStartTimes(i));
  }

  //convert Ishowtime to formatted string start date
  getFormattedStartDates(iteration: IShowTime): string {
    return iteration.span.start.toLocaleDateString([],{month: 'numeric', day: 'numeric',weekday: 'long'})
  }

  //convert Ishowtime to formatted string start time
  getFormattedStartTimes(iteration: IShowTime): string {
    return iteration.span.start.toLocaleTimeString([], { hour: 'numeric', minute: '2-digit', hour12: true })
  }

  setSelectedIteration():void{
    this.currentEventIteration= this.eventIterations?.filter(
      e=>this.selectedShowDay?.label==this.getFormattedStartDates(e)&&
      this.selectedShowTime?.label==this.getFormattedStartTimes(e))[0];
    this.loading=false;
  }


}

