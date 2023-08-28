import { Component, OnInit,ElementRef,ViewChild , ChangeDetectorRef   } from '@angular/core';
import { ISearchEvent } from 'src/app/View Models/Response Models/ISearchEvent';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit  {

  constructor(private changeDetector: ChangeDetectorRef){
  }

  @ViewChild("search") searchInput! : ElementRef;

  searchValue:string="";
  searchActive:boolean=false;
  typing:boolean=false;
  events!:ISearchEvent[];
  testSearchEvents!:ISearchEvent[];

  ngOnInit(): void {
    this.events = [
      {
        id: 1,
        name: 'asteroid city',
        image:
          'https://img-assets.drafthouse.com/images/shows/asteroid-city/ASTEROID-CITY_hero.jpg?ixlib=js-2.3.2&auto=compress&crop=focalpoint&fit=crop&fp-x=0.5&fp-y=0.5&q=80&ar=16%3A9&w=1946',
      },
      {
        id: 2,
        name: 'mission impossible dead reckoning',
        image:
          'https://img-assets.drafthouse.com/images/shows/mission-impossible-dead-reckoning-pt-1/MISSION-IMPOSSIBLE-DEAD-RECKONING-PT-1_hero.jpg?ixlib=js-2.3.2&auto=compress&crop=focalpoint&fit=crop&fp-x=0.3354&fp-y=0.2919&q=80&ar=16%3A9&w=1946',
      },
      {
        id: 3,
        name: 'oppenheimer',
        image:
          'https://img-assets.drafthouse.com/images/shows/oppenheimer/OPPENHEIMER_hero.jpg?ixlib=js-2.3.2&auto=compress&crop=focalpoint&fit=crop&fp-x=0.4459&fp-y=0.2459&q=80&ar=16%3A9&w=1946',
      },
      {
        id: 4,
        name: 'drive my car',
        image:
          'https://ca-times.brightspotcdn.com/dims4/default/38d0ad0/2147483647/strip/true/crop/1620x1080+150+0/resize/2000x1333!/format/webp/quality/80/?url=https%3A%2F%2Fcalifornia-times-brightspot.s3.amazonaws.com%2F06%2F40%2F4e0f6f0b474aae7da87637748dfa%2Fla-ca-drive-my-car-movie-0052.JPG',
      },
      {
        id: 5,
        name: 'Indiana Jones And The Dial Of Disteny',
        image:
          'https://img-assets.drafthouse.com/images/shows/indiana-jones-and-the-dial-of-destiny/INDIANA-JONES-AND-THE-DIAL-OF-DESTINY_hero.jpg?ixlib=js-2.3.2&auto=compress&crop=focalpoint&fit=crop&fp-x=0.5239&fp-y=0.286&q=80&ar=16%3A9&w=798',
      },
      {
        id: 6,
        name: 'In The Mood For Love',
        image:
          'https://static01.nyt.com/images/2020/11/27/arts/26gateway-mood1/26gateway-mood1-jumbo-v2.jpg?quality=75&auto=webp',
      },
    ];
  }

  SearchFocused(){
    this.searchActive=true;
    this.changeDetector.detectChanges();
    this.searchInput.nativeElement.focus();
  }

  SearchUnfocused(){
    this.searchActive=false;
    this.typing=false;
    this.searchValue="";
  }

  searchInputChange(){
    this.typing=true;
    this.testSearchEvents= this.events.filter(event=>event.name.startsWith(this.searchValue));
  }
}
