import { Component, OnInit } from '@angular/core';
import {  NavigationEnd, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { AuthenticationService } from './Services/AuthenticationService/Authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit   {
  title = 'FrontEnd';
  showheader=true;
  showfooter=true;
  constructor(
    private authService : AuthenticationService,
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
  ngOnInit(): void {
  }

}
