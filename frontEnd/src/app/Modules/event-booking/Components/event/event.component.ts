import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { EventService } from 'src/app/Services/Event.service';
import { IEvent } from 'src/app/View Models/Response Models/IEvent';
import {GlobalConfigurationService} from 'src/app/Services/Global-Configuration.service'
import { SmoothScrollService } from 'src/app/Services/SmoothScroll/SmoothScroll.service';


@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css'],

})
export class EventComponent implements OnInit,OnDestroy {
  eventSubscription!: Subscription;
  event : IEvent = {
    id: 0,
    name: '',
    type: '',
    backGroundUrl: '',
    thumbnailUrl: '',
    description: '',
    descriptionTitle:''
  };
  articleExpanded:boolean =false;

  constructor(
    private scroller:SmoothScrollService,
      private eventService: EventService
    , private config:GlobalConfigurationService){
  }

  ngOnInit(): void {
    this.eventSubscription = this.eventService.GetEventById(1).subscribe((e)=>{
      this.event = e
      this.event.backGroundUrl=`${this.config.ApiUrl}/${this.event.backGroundUrl}`
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
