import { IVenue } from "./IVenue";

export interface IShowTime {
  eventInstanceId: number;
  span:{
    start: Date;
    end: Date;
  }
}
