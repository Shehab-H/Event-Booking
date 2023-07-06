import { Component, Input, OnInit,OnChanges, SimpleChanges, Output } from '@angular/core';
import { Iseat } from 'src/app/View Models/Response Models/ISeat';
import { CdkDragStart, CdkDragRelease } from '@angular/cdk/drag-drop';
import { EventService } from 'src/app/Services/Event.service';
import { EventEmitter } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'Seatings',
  templateUrl: './Seatings.component.html',
  styleUrls: ['./Seatings.component.css'],
})
export class SeatingsComponent implements OnInit,OnChanges {

  @Input() eventiterationId:number | undefined;
  @Output() next = new EventEmitter<number[]>();

  loading: boolean = false;
  selectedSeats: Iseat[]=[];
  scale!:number;
  seats: Iseat[]=[
  ];

   alphabet: string[] =
   ['A', 'B', 'C', 'D', 'E', 'F', 'G',
   'H', 'I', 'J', 'K', 'L', 'M', 'N',
    'O', 'P', 'Q', 'R', 'S', 'T', 'U'
    , 'V', 'W', 'X', 'Y', 'Z'];


  largestSeatCount!:number;
  rows!: string[];
  seatsByRow: { [key: string]: Iseat[] } = {};

  constructor(private eventService:EventService,
    private router: Router,

    ) { }

  ngOnChanges(changes: SimpleChanges): void {
    this.selectedSeats.splice(0,this.selectedSeats.length);
    this.loading=true;
      if(this.eventiterationId!=undefined){
        console.log(this.eventiterationId);
        this.eventService.getSeats(this.eventiterationId)
        .subscribe(seats=>{
          this.seats=seats;
          this.seatsChanged();
          this.loading=false;
        })
      }
  }

  ngOnInit() {
    this.scale=1;
    this.seatsChanged();
  }

  seatsChanged(){
    this.rows= Array.from(new Set(this.seats.map(seat => seat.row)));;
  // group the seats by row
  this.seats.forEach(seat => {
    if (!this.seatsByRow[seat.row]) {
      this.seatsByRow[seat.row] = [];
    }
    this.seatsByRow[seat.row][seat.number - 1] = seat;
  });

  //get the number of seats in the biggest row
  this.largestSeatCount=0;
  for(const row in this.seatsByRow){
    if(this.seatsByRow[row].length>this.largestSeatCount){
      this.largestSeatCount=this.seatsByRow[row].length;
    }
  }
  //fill empty seats
  for (const row in this.seatsByRow){
    for (let i = 0; i < this.seatsByRow[row].length; i++){
      if (this.seatsByRow[row][i] === undefined) {
        this.seatsByRow[row][i] = {id:0,row:row,number:-1,available:false};
      }
    }
  }
  }
  seatSelected(seat:Iseat):void{
    if(this.isSelected(seat)){
      this.selectedSeats = this.selectedSeats.filter(s=>s.id !=seat.id);
    }
    else{
      this.selectedSeats.push(seat);
    }
  }

  scaleUp(){
    this.scale=this.scale*1.5;
  }
  scaleDown(){
    this.scale=this.scale/2;
  }
  reset(){
    this.scale=1;
  }


  isSelected(seat:Iseat):boolean{
    var s =  this.selectedSeats.find(s=>s.id==seat.id);
    if(s==undefined){
      return false;
    }
    else{
      return true;
    }
  }

  onDragStarted(event: CdkDragStart) {
    const element = event.source.element.nativeElement;
    element.style.transform=`scale(${this.scale})`;
  }

  onDragReleased(event: CdkDragRelease) {
    const element = event.source.element.nativeElement;
    element.style.transform = element.style.transform.replace("scale(1)", `scale(${this.scale})`);
  }
//hint : drag drop and zoom need further testing and maintenance (it's glitchy)

 makeReservation(){
  const selectedSeatIds=this.selectedSeats.map(s=>s.id);
  this.router.navigate(['/payment/',this.eventiterationId,JSON.stringify(selectedSeatIds)])
 }
}
