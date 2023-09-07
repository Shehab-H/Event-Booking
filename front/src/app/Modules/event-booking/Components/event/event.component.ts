import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { EventService } from 'src/app/Services/Event.service';
import { IEvent } from 'src/app/View Models/Response Models/IEvent';
import { SmoothScrollService } from 'src/app/Services/SmoothScroll/SmoothScroll.service';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css'],

})
export class EventComponent implements OnInit,OnDestroy {
  eventSubscription!: Subscription;
  event! : IEvent ;
  eventId! : number;

  articleExpanded:boolean =false;

  constructor(
    private route:ActivatedRoute,
    private scroller:SmoothScrollService,
      private eventService: EventService
    ){
  }

  ngOnInit(): void {
    this.eventId= Number(this.route.snapshot.paramMap.get('id'));
    this.eventSubscription = this.eventService.getEventById(this.eventId).subscribe((e)=>{
      this.event = e;
      this.event.backGroundUrl=`${environment.ApiUrl}/${this.event.backGroundUrl}`;
    }
    );

  }
  ngOnDestroy(): void {
    this.eventSubscription.unsubscribe();
  }

  Scroll(el:HTMLElement){
    this.scroller.smoothScroll(el,600);
  }


  ExpandArticle(){
    this.articleExpanded=true;
  }
}
