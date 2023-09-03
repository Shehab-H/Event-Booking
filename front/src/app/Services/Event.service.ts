import { Injectable } from '@angular/core';
import { IEvent } from '../View Models/Response Models/IEvent';
import { IShowTime } from '../View Models/Response Models/IShowTime';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IVenue } from '../View Models/Response Models/IVenue';
import { map } from 'rxjs/operators';
import { Iseat } from '../View Models/Response Models/ISeat';
import { ISearchEvent } from '../View Models/Response Models/ISearchEvent';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  constructor(
    private httpClient: HttpClient,
  ) {

  }

  getEventById(id: number): Observable<IEvent> {
    return this.httpClient.get<IEvent>(`${environment.ApiUrl}/Event/Get/${id}`);
  }

  getVenues(eventId: number): Observable<IVenue[]> {
    return this.httpClient.get<IVenue[]>(
      `${environment.ApiUrl}/Event/GetVenues/${eventId}`
    );
  }

  getEventShowTimes(eventId: number, venueId: number): Observable<IShowTime[]> {
    return this.httpClient
      .get<IShowTime[]>(
        `${environment.ApiUrl}/Event/GetRunTimes/${eventId}/${venueId}`
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
    }>(`${environment.ApiUrl}/Event/GetSeats/${eventiterationId}`).pipe(
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
    return this.httpClient.patch<any>(`${environment.ApiUrl}/Event/Book/${eventInstanceId}`,seatIds);
  }

  search(searchString:string):Observable<ISearchEvent[]>{
    return this.httpClient.get<ISearchEvent[]>(`${environment.ApiUrl}/Event/Search/${searchString}`)
    .pipe(
      map(response => response.map((event:ISearchEvent) =>
      {
        const searchEvent:ISearchEvent = {
          id:event.id,
          name:event.name,
          imageUrl:`${environment.ApiUrl}/${event.imageUrl}`
        }
        return searchEvent;
    }))
    );
  }

}
