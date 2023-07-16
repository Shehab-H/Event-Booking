import { Component, OnInit } from '@angular/core';
import { IEvent } from 'src/app/View Models/Response Models/IEvent';

@Component({
  selector: 'app-trending-events',
  templateUrl: './trending-events.component.html',
  styleUrls: ['./trending-events.component.css']
})
export class TrendingEventsComponent implements OnInit {
  events!: IEvent[];
  cardWidth!:string[];
  constructor() { }

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
      {
        id: 5,
        type: 'movie',
        name: 'Indiana Jones And The Dial Of Disteny',
        thumbnailUrl: '',
        description: '',
        descriptionTitle: '',
        backGroundUrl:
          'https://img-assets.drafthouse.com/images/shows/indiana-jones-and-the-dial-of-destiny/INDIANA-JONES-AND-THE-DIAL-OF-DESTINY_hero.jpg?ixlib=js-2.3.2&auto=compress&crop=focalpoint&fit=crop&fp-x=0.5239&fp-y=0.286&q=80&ar=16%3A9&w=798',
      },
      {
        id: 6,
        type: 'movie',
        name: 'In The Mood For Love',
        thumbnailUrl: '',
        description: '',
        descriptionTitle: '',
        backGroundUrl:
          'https://static01.nyt.com/images/2020/11/27/arts/26gateway-mood1/26gateway-mood1-jumbo-v2.jpg?quality=75&auto=webp',
      },
      {
        id: 7,
        type: 'movie',
        name: 'The Thin Red Line',
        thumbnailUrl: '',
        description: '',
        descriptionTitle: '',
        backGroundUrl:
          'https://cdn.theasc.com/The-Thin-Red-Line-Featured.jpeg',
      },
      {
        id: 8,
        type: 'movie',
        name: 'Blade Runner',
        thumbnailUrl: '',
        description: '',
        descriptionTitle: '',
        backGroundUrl:
          'https://images.amcnetworks.com/ifccenter.com/wp-content/uploads/2022/07/bladerunner_1280x720.png',
      },
      {
        id: 9,
        type: 'movie',
        name: 'Red',
        thumbnailUrl: '',
        description: '',
        descriptionTitle: '',
        backGroundUrl:
          'https://pics.filmaffinity.com/Three_Colours_Red-989669709-large.jpg',
      },
      {
        id: 10,
        type: 'movie',
        name: 'Grave Of The Fireflies',
        thumbnailUrl: '',
        description: '',
        descriptionTitle: '',
        backGroundUrl:
          'https://images.amcnetworks.com/ifccenter.com/wp-content/uploads/2019/12/grave-of-the-fireflies_hi-res.jpg',
      },
    ];

    this.cardWidth=[
      '25%','25%','30%','40.5%' ,'40.5%','30%','25%','25%','40.5%','40.5%'
    ]
  }

}
