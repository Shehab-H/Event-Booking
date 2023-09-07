import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';
import { AuthenticationService } from '../Services/AuthenticationService/Authentication.service';
import { Router } from '@angular/router';
export const authenticationGuard: CanActivateFn = (route, state) => {
  var hasAccess = inject(AuthenticationService).isTokenValid();
  if(hasAccess==true){
    inject(Router).navigate(['']);
  }
  return !hasAccess;
};
