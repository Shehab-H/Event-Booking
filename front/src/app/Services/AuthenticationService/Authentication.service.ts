import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Login } from 'src/app/View Models/Request Models/Login';
import { SignUp } from 'src/app/View Models/Request Models/SignUp';
import { ILoginResult } from 'src/app/View Models/Response Models/ILoginResult';
import { Observable } from 'rxjs';
import { IJwtAuth } from 'src/app/View Models/Response Models/IJwtAuth';
import { JwtHelperService ,JWT_OPTIONS  } from '@auth0/angular-jwt';
import { IFalseLogin } from 'src/app/View Models/Response Models/IFalseLogin';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
registerUrl:string = "Authentication/Register";
loginUrl:string = "Authentication/Login";

constructor(private httpClient : HttpClient,private jwtHelper: JwtHelperService) { }

public regiser(user:SignUp): Observable<any>{
  return this.httpClient.post(`${environment.ApiUrl}/${this.registerUrl}`,user);
}

public login(user:Login): Observable<ILoginResult>{
  return this.httpClient.post<ILoginResult>(`${environment.ApiUrl}/${this.loginUrl}`,user);
}

public saveToken(token: string): void {
  localStorage.setItem('jwtToken', token);
}

public isTokenValid(): boolean {
  const token = localStorage.getItem('jwtToken');
  if(!token){
    //return false if token doesn't exist
    return false;
  }
  // return true if token didn't expire and false if token expired
   return !this.jwtHelper.isTokenExpired(token);
}

public getUserRole():string{
  const token = localStorage.getItem('jwtToken');
  if(!token){
    throw new Error('jwt token not found');
  }
  return  this.jwtHelper.decodeToken(token).role;
}
}
