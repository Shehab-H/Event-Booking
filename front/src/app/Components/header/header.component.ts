import { Component, OnInit,ElementRef,ViewChild , ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { EventService } from 'src/app/Services/Event.service';
import { ISearchEvent } from 'src/app/View Models/Response Models/ISearchEvent';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit  {

  constructor(private changeDetector: ChangeDetectorRef
    , private eventService:EventService,
     private router : Router
    ){
  }

  searchSubscribtion!:Subscription;

  @ViewChild("search") searchInput! : ElementRef;
  @ViewChild("searchResult") searchResult! : ElementRef;

  searchValue:string="";
  showOverlay:boolean=false;
  searchActive:boolean=false;
  typing:boolean=false;
  loadingEvents:boolean=false;
  events!:ISearchEvent[];

  ngOnInit(): void {
  }

  SearchFocused(){
    window.addEventListener('click', this.onDocumentClick);
    this.searchActive=true;
    this.changeDetector.detectChanges();
    this.searchInput.nativeElement.focus();
    this.showOverlay=true;
  }


  searchInputChange(){
    if(this.searchValue==""){
      this.events.splice(0);
    }
    else{
        this.typing=true;
        this.loadingEvents=true;
        this.searchSubscribtion=
        this.eventService.search(this.searchValue).subscribe(
          (data:ISearchEvent[])=>{
            this.events=data;
            this.loadingEvents=false;
          },
          (error:any)=>{
            this.loadingEvents=false;
            this.router.navigate(['error']);
          }
        )
    }
  }

  hideSearch(){
    this.searchActive=false;
    this.typing=false;
    this.searchValue="";
    if(this.searchSubscribtion){
      this.searchSubscribtion.unsubscribe();
    }
    this.showOverlay=false;
    window.removeEventListener('click', this.onDocumentClick);
  }

  onDocumentClick = (event:MouseEvent) =>{
    this.changeDetector.detectChanges();
    const clickedInsideInput = this.searchInput.nativeElement.contains(event.target);
    if(this.searchResult){
     const clickedInsideSearchResult = this.searchResult.nativeElement.contains(event.target);
     if(!clickedInsideInput&&!clickedInsideSearchResult){
      this.hideSearch();
    }
    }
    else{
      if(!clickedInsideInput){
        this.hideSearch();
      }
    }
  }
}
