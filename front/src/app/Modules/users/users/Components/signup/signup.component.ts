import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/Services/AuthenticationService/Authentication.service';
import { SignUp } from 'src/app/View Models/Request Models/SignUp';
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  emailPattern: RegExp = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
  passwordpattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z]).+$/;

  username:string="";
  usernameHelp:string="";
  email:string="";
  password:string="";
  emailHelp:string="";
  passwordHelp:string="";
  invalid:boolean = true;
  loading:boolean=false;


  devfix:boolean=false;

  constructor(private authService:AuthenticationService,private router:Router) { }

  ngOnInit() {
  }

  signup():void{
    let validCredentials = this.validCredentials();

    if(validCredentials){
      let user = new SignUp()
      user.email=this.email;
      user.name=this.username;
      user.password=this.password;
      this.loading=true;
      this.authService.regiser(user).subscribe({
        next:()=>{
          this.loading=false;
          this.router.navigate(['/user/login']);
        }
        ,
        error:(error:HttpErrorResponse)=>{
          this.loading=false
          this.devfix=true;
          // handle invalid credentials like email , password or username here
        }
      }
      )
    }
  }

  validCredentials():boolean{
    let validEmail = this.emailPattern.test(this.email);
    let validPassword = this.passwordpattern.test(this.password);
    let validCredentials:boolean=true;
    if(!validEmail){
     this.emailHelp='*Invalid Email';
     validCredentials=false;
    }
    else{
      this.emailHelp='';
    }

    if(this.username==""){
      this.usernameHelp="*username is required";
      validCredentials=false;
    }
    else{
      this.usernameHelp='';
    }

    if(this.password==""){
      this.passwordHelp="*password is required";
      validCredentials=false;
    }
    else{
      this.passwordHelp='';
    }


    if(!validPassword&&this.password!=""){
      this.passwordHelp="*password must have at least one lowercase letter, one uppercase letter, and one non-alphabetic character"
      validCredentials=false;
    }
    if(validCredentials){
      this.emailHelp="";
      this.passwordHelp=""
      this.usernameHelp=""
      return true;
    }
    return false;
  }
}
