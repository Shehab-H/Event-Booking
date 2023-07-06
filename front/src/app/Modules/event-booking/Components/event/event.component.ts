import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { EventService } from 'src/app/Services/Event.service';
import { IEvent } from 'src/app/View Models/Response Models/IEvent';
import {GlobalConfigurationService} from 'src/app/Services/Global-Configuration.service'
import { SmoothScrollService } from 'src/app/Services/SmoothScroll/SmoothScroll.service';
import { ActivatedRoute } from '@angular/router';

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
    , private config:GlobalConfigurationService){
  }

  ngOnInit(): void {
    this.eventId= Number(this.route.snapshot.paramMap.get('id'));
    this.eventSubscription = this.eventService.getEventById(this.eventId).subscribe((e)=>{
      this.event = e;
      this.event.backGroundUrl=`${this.config.ApiUrl}/${this.event.backGroundUrl}`;
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
