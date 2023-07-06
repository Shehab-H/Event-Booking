import { Injectable } from '@angular/core';
import { IEvent } from '../View Models/Response Models/IEvent';
import { IShowTime } from '../View Models/Response Models/IShowTime';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GlobalConfigurationService } from 'src/app/Services/Global-Configuration.service';
import { IVenue } from '../View Models/Response Models/IVenue';
import { map } from 'rxjs/operators';
import { Iseat } from '../View Models/Response Models/ISeat';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  constructor(
    private httpClient: HttpClient,
    private config: GlobalConfigurationService
  ) {}

  getEventById(id: number): Observable<IEvent> {
    return this.httpClient.get<IEvent>(`${this.config.ApiUrl}/Event/Get/${id}`);
  }

  getVenues(eventId: number): Observable<IVenue[]> {
    return this.httpClient.get<IVenue[]>(
      `${this.config.ApiUrl}/Event/GetVenues/${eventId}`
    );
  }

  getEventShowTimes(eventId: number, venueId: number): Observable<IShowTime[]> {
    return this.httpClient
      .get<IShowTime[]>(
        `${this.config.ApiUrl}/Event/GetRunTimes/${eventId}/${venueId}`
      )
      .pipe(
        map((response) =>
          response.map((eventIteration) => ({
            eventInstanceId: eventIteration.eventInstanceId,
            span: {
              start: new Date(eventIteration.span.start),
              end: new Date(eventIteration.span.end),
            },
          }))
        )
      );
  }
  getSeats(eventiterationId: number): Observable<Iseat[]> {
    return this.httpClient.get<{
      availableSeats: [{ id: number; row: string; number: number }];
      reservedSeats: [{ id: number; row: string; number: number }];
    }>(`${this.config.ApiUrl}/Event/GetSeats/${eventiterationId}`).pipe(
      map((response)=>
      response.availableSeats.map(
        (i)=>({
          id:i.id,
          row:i.row,
          number:i.number,
          available:true
        } as Iseat)
        ).concat(
          response.reservedSeats.map(
            (seat)=>({
              id:seat.id,
              row:seat.row,
              number:seat.number,
              available:false
            } as Iseat)
          )
        )
    ))
  }

  makeReservation(eventInstanceId:number,seatIds:number[]):Observable<any>{
    return this.httpClient.patch<any>(`${this.config.ApiUrl}/Event/Book/${eventInstanceId}`,seatIds);
  }
}
