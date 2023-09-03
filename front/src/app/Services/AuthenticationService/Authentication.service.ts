import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Login } from 'src/app/View Models/Request Models/Login';
import { SignUp } from 'src/app/View Models/Request Models/SignUp';
import { ILoginResult } from 'src/app/View Models/Response Models/ILoginResult';
import { Observable } from 'rxjs';
import { IJwtAuth } from 'src/app/View Models/Response Models/IJwtAuth';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
registerUrl:string = "uthentication/Register";
loginUrl:string = "Authentication/Login";

constructor(private httpClient : HttpClient) { }

public regiser(user:SignUp): Observable<IJwtAuth>{
  return this.httpClient.post<IJwtAuth>(`${environment.ApiUrl}/${this.registerUrl}`,user);
}

public login(user:Login): Observable<ILoginResult>{
  return this.httpClient.post<ILoginResult>(`${environment.ApiUrl}/${this.loginUrl}`,user);
}

public saveToken(token: string): void {
  localStorage.setItem('jwtToken', token);
}
}
