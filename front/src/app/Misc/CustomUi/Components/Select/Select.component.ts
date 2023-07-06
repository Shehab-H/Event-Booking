import { Component, OnInit ,Input ,Output, EventEmitter } from '@angular/core';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'event-select',
  templateUrl: './Select.component.html',
  styleUrls: ['./Select.component.css']
})
export class SelectComponent implements OnInit {

  @Input() placeholder:string='';

  @Input()options:string[]=[];

  @Output() selectionChanged = new EventEmitter<string>();

  selectedOption!:string;

  identifiers:string[]=[];

  placeholderUniqueID:string;

  radioGroupName:string;

  constructor() {
    this.placeholderUniqueID=this.GetUniqueString();
    this.radioGroupName=this.GetUniqueString();
  }


  ngOnInit() {
    for (let i=0;i<this.options.length;i++ ){
      this.identifiers.push(this.GetUniqueString());
    }
    this.selectedOption=this.placeholder;
  }

  GetUniqueString():string{
    let id = Guid.create().toString();
    return id;
  }
  onSelectionChange(value:string) {
    if(!(value==this.selectedOption)){
      this.selectedOption=value;
      this.selectionChanged.emit(value);
    }
  }
}
