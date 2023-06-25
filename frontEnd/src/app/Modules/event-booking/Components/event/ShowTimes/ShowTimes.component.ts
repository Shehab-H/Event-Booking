import { Component,ViewEncapsulation, OnInit } from '@angular/core';

@Component({
  selector: 'ShowTimes',
  templateUrl: './ShowTimes.component.html',
  styleUrls: ['./ShowTimes.component.css'],
  encapsulation: ViewEncapsulation.None,

})
export class ShowTimesComponent implements OnInit {

  selectedValue: string = '' ;

  foods = [
    {value: 'steak-0', viewValue: 'Steak'},
    {value: 'pizza-1', viewValue: 'Pizza'},
    {value: 'tacos-2', viewValue: 'Tacos'},
    {value: 'tacos-2', viewValue: 'Tacos'},
    {value: 'tacos-2', viewValue: 'Tacos'},
    {value: 'tacos-2', viewValue: 'Tacos'},
    {value: 'tacos-2', viewValue: 'Tacos'},
    {value: 'tacos-2', viewValue: 'Tacos'},
    {value: 'tacos-2', viewValue: 'Tacos'},
    {value: 'tacos-2', viewValue: 'Tacos'},
    {value: 'tacos-2', viewValue: 'Tacos'},
  ];

  cars = [
    {value: 'volvo', viewValue: 'Volvo'},
    {value: 'saab', viewValue: 'Saab'},
    {value: 'mercedes', viewValue: 'Mercedes'},
  ];
  constructor() {}

  ngOnInit() {
  }
}
