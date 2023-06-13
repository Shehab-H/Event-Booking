import { IEventIteration } from "./IEventIteration";
import { IVenue } from "./IVenue";

export interface IEvent {
  id:number
  name : string;
  description : string;
  backgroundImageUrl : string;
  posterImageUrl :string;
  venues:IVenue[]
}
