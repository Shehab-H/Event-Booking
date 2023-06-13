import { Injectable } from '@angular/core';
import { IEvent } from '../View Models/Response Models/IEvent';
import { IEventIteration } from '../View Models/Response Models/IEventIteration';
import { IVenue } from '../View Models/Response Models/IVenue';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  Events: IEvent[];
  constructor() {
    this.Events = [
      {
        id: 0,
        name: 'Jhon Wick: Chapter 4',
        description:
          'With the price on his head ever increasing, John Wick uncovers a path to defeating The High Table. But before he can earn his freedom, Wick must face off against a new enemy with powerful alliances across the globe and forces that turn old friends into foes.',
        backgroundImageUrl:
          'https://blog.richersounds.com/wp-content/uploads/2023/04/review-john-wick-chapter-4-elevates-the-badass-action-franchise-to-a-new-level.jpg',
        posterImageUrl:
          'https://assets-prd.ignimgs.com/2023/02/08/jw4-2025x3000-online-character-1sht-keanu-v187-1675886090936.jpg',
        venues: [
          {
            id: 1,
            name: 'Americana Blaza',
          },
          {
            id: 2,
            name: 'Point 90',
          },
        ],
      },
    ];
  }
  GetEventById(id: number): IEvent {
    return this.Events[id];
  }

  GetEventIterations(eventId: number, venueId: number): IEventIteration[] {
    return [
      {
        id: 1,
        startDateTime: new Date(),
        endDateTime: new Date(),
      },
      {
        id: 2,
        startDateTime: new Date(),
        endDateTime: new Date(),
      },
      {
        id: 2,
        startDateTime: new Date(),
        endDateTime: new Date(),
      },
    ];
  }
}
