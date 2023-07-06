import { Component, OnInit } from '@angular/core';
import { NavigationEnd, NavigationStart, Router } from '@angular/router';

@Component({
  selector: 'app-Loading',
  templateUrl: './Loading.component.html',
  styleUrls: ['./Loading.component.css']
})
export class LoadingComponent implements OnInit {
  loading = false;
  constructor(private router: Router) {
    router.events.subscribe(event=>{
      if (event instanceof NavigationStart) {
        this.loading = true;
      } else if (event instanceof NavigationEnd) {

        this.loading = false;
      }
    })
  }

  ngOnInit() {

  }
}
