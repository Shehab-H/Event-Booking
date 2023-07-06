import { Component, OnInit } from '@angular/core';
import {  NavigationEnd, Router } from '@angular/router';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  {
  title = 'FrontEnd';
  showheader=true;
  showfooter=true;
  constructor(
    private router: Router
  ){
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        const isHiddenRoute = event.url.includes('/payment')||event.url.includes('error');
        this.showheader = !isHiddenRoute;
        this.showfooter = !isHiddenRoute;
      }
    });
  }

}
