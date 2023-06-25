import { Injectable } from '@angular/core';
import { IEvent } from '../View Models/Response Models/IEvent';
import { IEventIteration } from '../View Models/Response Models/IEventIteration';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {GlobalConfigurationService} from 'src/app/Services/Global-Configuration.service';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  constructor(private httpClient:HttpClient , private config:GlobalConfigurationService) {}


  GetEventById(id: number): Observable<IEvent> {
    return this.httpClient.get<IEvent>(`${this.config.ApiUrl}/Event/Get/${id}`);
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
