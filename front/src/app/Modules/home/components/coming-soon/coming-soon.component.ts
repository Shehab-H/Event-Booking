import { Component, OnInit } from '@angular/core';
import { IEvent } from 'src/app/View Models/Response Models/IEvent';

@Component({
  selector: 'app-coming-soon',
  templateUrl: './coming-soon.component.html',
  styleUrls: ['./coming-soon.component.css'],
})
export class ComingSoonComponent implements OnInit {
  events!: IEvent[];
  currentEvent!: IEvent;
  constructor() {}

  ngOnInit() {
    this.events = [
      {
        id: 1,
        name: 'asteroid city',
        type: 'movie',
        thumbnailUrl: '',
        description: '',
        descriptionTitle: '',
        backGroundUrl:
          'https://img-assets.drafthouse.com/images/shows/asteroid-city/ASTEROID-CITY_hero.jpg?ixlib=js-2.3.2&auto=compress&crop=focalpoint&fit=crop&fp-x=0.5&fp-y=0.5&q=80&ar=16%3A9&w=1946',
      },
      {
        id: 2,
        name: 'mission impossible dead reckoning',
        type: 'movie',
        thumbnailUrl: '',
        description: '',
        descriptionTitle: '',
        backGroundUrl:
          'https://img-assets.drafthouse.com/images/shows/mission-impossible-dead-reckoning-pt-1/MISSION-IMPOSSIBLE-DEAD-RECKONING-PT-1_hero.jpg?ixlib=js-2.3.2&auto=compress&crop=focalpoint&fit=crop&fp-x=0.3354&fp-y=0.2919&q=80&ar=16%3A9&w=1946',
      },
      {
        id: 3,
        type: 'movie',
        name: 'oppenheimer',
        thumbnailUrl: '',
        description: '',
        descriptionTitle: '',
        backGroundUrl:
          'https://img-assets.drafthouse.com/images/shows/oppenheimer/OPPENHEIMER_hero.jpg?ixlib=js-2.3.2&auto=compress&crop=focalpoint&fit=crop&fp-x=0.4459&fp-y=0.2459&q=80&ar=16%3A9&w=1946',
      },
      {
        id: 4,
        type: 'movie',
        name: 'drive my car',
        thumbnailUrl: '',
        description: '',
        descriptionTitle: '',
        backGroundUrl:
          'https://ca-times.brightspotcdn.com/dims4/default/38d0ad0/2147483647/strip/true/crop/1620x1080+150+0/resize/2000x1333!/format/webp/quality/80/?url=https%3A%2F%2Fcalifornia-times-brightspot.s3.amazonaws.com%2F06%2F40%2F4e0f6f0b474aae7da87637748dfa%2Fla-ca-drive-my-car-movie-0052.JPG',
      },
    ];
    this.currentEvent= this.events[0]
    let i=1;
    setInterval(()=>{
      this.currentEvent=this.events[i];
      i++;
      if(this.events.length==i){
        i=0;
      }
    },5000)
  }
}
