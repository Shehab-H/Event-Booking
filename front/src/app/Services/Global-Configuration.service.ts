import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GlobalConfigurationService {
public ApiUrl:string;
constructor() {
  this.ApiUrl="https://localhost:7038";
}
}
