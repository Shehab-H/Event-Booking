import { Component, Input, OnInit } from '@angular/core';
import { Observable, interval } from 'rxjs';
import { IEvent } from 'src/app/View Models/Response Models/IEvent';
import {
  trigger,
  state,
  style,
  animate,
  transition,
  // ...
} from '@angular/animations';
@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.css'],
  animations:[
    trigger('slide',[
      state('left',style({
        transform: 'translateX(-100%)'
      })),
      state('right',style({
        transform: 'translateX(100%)'
      })),
      state('middle',style({
        transform: 'translateX(0%)'
      })),
      transition('middle => right',animate('2000ms ease-in-out')),
      transition('left => middle',animate('2000ms ease-in-out')),
      transition('left => right',animate('0ms'))
    ])
  ]
})
export class SliderComponent implements OnInit {
  events!: {state:string,event:IEvent}[];

  currentEvent!:{state:string,event:IEvent};
  nextEvent!:{state:string,event:IEvent};
  constructor() {}

  ngOnInit() {
    this.events = [
      {
        state:'middle'
        ,
        event:
        {
          id: 1,
          name : 'asteroid city',
          type :'movie',
          thumbnailUrl: '',
          description : '',
          descriptionTitle:'',
          backGroundUrl: 'https://img-assets.drafthouse.com/images/shows/asteroid-city/ASTEROID-CITY_hero.jpg?ixlib=js-2.3.2&auto=compress&crop=focalpoint&fit=crop&fp-x=0.5&fp-y=0.5&q=80&ar=16%3A9&w=1946',
        }
      }
      ,
      {
        state:'left'
        ,
        event:
        {
          id:2,
          name : 'mission impossible dead reckoning',
          type :'movie',
          thumbnailUrl: '',
          description : '',
          descriptionTitle:'',
          backGroundUrl: 'https://img-assets.drafthouse.com/images/shows/mission-impossible-dead-reckoning-pt-1/MISSION-IMPOSSIBLE-DEAD-RECKONING-PT-1_hero.jpg?ixlib=js-2.3.2&auto=compress&crop=focalpoint&fit=crop&fp-x=0.3354&fp-y=0.2919&q=80&ar=16%3A9&w=1946'
        }
      },
      {
        state:'left'
        ,
        event:
        {
          id:3,
          type :'movie',
          name : 'oppenheimer',
          thumbnailUrl: '',
          description : '',
          descriptionTitle:'',
          backGroundUrl:'https://img-assets.drafthouse.com/images/shows/oppenheimer/OPPENHEIMER_hero.jpg?ixlib=js-2.3.2&auto=compress&crop=focalpoint&fit=crop&fp-x=0.4459&fp-y=0.2459&q=80&ar=16%3A9&w=1946'
        }
      },
      {
        state:'left'
        ,
        event:
        {
          id:4,
          type :'movie',
          name : 'drive my car',
          thumbnailUrl: '',
          description : '',
          descriptionTitle:'',
          backGroundUrl:'https://ca-times.brightspotcdn.com/dims4/default/38d0ad0/2147483647/strip/true/crop/1620x1080+150+0/resize/2000x1333!/format/webp/quality/80/?url=https%3A%2F%2Fcalifornia-times-brightspot.s3.amazonaws.com%2F06%2F40%2F4e0f6f0b474aae7da87637748dfa%2Fla-ca-drive-my-car-movie-0052.JPG'
        }
      }

    ];
    this.currentEvent= this.events[0];
    this.nextEvent = this.events[1];

    this.startSlide(2000,2000);

  }

  startSlide(slideDuration:number,waitDuration:number){
    setTimeout(()=>{
 //iterate over the events array
 for(let i=0; i<this.events.length; i++){
  //wait 0 => 4000 => 8000 => 12000 => ... untill the events array is finished and then start
  //sliding the event pictures
  setTimeout(()=>{
    //if events[i] is not the last event , then slide this events picture to the right and
    //the one after it in it's place (middle)
    if(this.events[i+1]){
      this.events[i].state='right';
      this.events[i+1].state='middle'
    }
    // else this is  the last event , so slide it to the right and slide the first event to it's place
    //giving this a loop a effect , because we start with the first event in the middle and end with it in the middle
    else{

      this.events[i].state='right';
      this.events[0].state='middle';
      //after 2 seconds when the last event finishes sliding to right
      //reposition it left , wait another 2 seconds then start recurresion
      setTimeout(()=>{
        this.events[i].state='left';
        setTimeout(()=>{
          this.startSlide(slideDuration,waitDuration);
        },waitDuration)
      },slideDuration)
    }
    //if we have events that finished sliding to the right reposition it to left
    // so it can be ready for sliding again
    if(this.events[i-1]){
      this.events[i-1].state='left'
    }
  },i*slideDuration*(waitDuration/1000))
}
    },waitDuration);

  }
  changeCurrent(){
    this.currentEvent=this.nextEvent;
  }

  changeNext(){
    if(this.nextEvent.event.id===this.events[this.events.length-1].event.id){
      console.log('last index : ',this.nextEvent.event.id)
      this.nextEvent = this.events[0];
    }
    else{
      this.nextEvent=this.events[this.events.indexOf(this.nextEvent)+1];
    }
  }

}
