import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/Services/AuthenticationService/Authentication.service';
import { Login } from 'src/app/View Models/Request Models/Login';
import { ILoginResult } from 'src/app/View Models/Response Models/ILoginResult';
import { IFalseLogin } from 'src/app/View Models/Response Models/IFalseLogin';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  emailPattern: RegExp = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
  email:string="";
  password:string="";
  emailHelp:string="";
  passwordHelp:string="";
  invalid:boolean = true;

  loading:boolean=false;
  constructor(private authService:AuthenticationService,private router:Router) { }

  ngOnInit() {
  }

  login():void{
     let validEmail = this.emailPattern.test(this.email);
     if(validEmail!=true){
      this.emailHelp='Invalid Email';
     }
     else{
      this.emailHelp='';
      this.loading=true;
        let login = new Login();
        login.email=this.email;
        login.password=this.password;
        this.authService.login(login).subscribe((loginResult)=>{
          this.loading=false;
          this.authService.saveToken(loginResult.authResult.token);
          this.router.navigate(['']);

        },
        (error:HttpErrorResponse)=>{
            this.loading=false;
            console.log(error);
            this.emailHelp="invalid email or password"
        }
        )
        }
     }
}

