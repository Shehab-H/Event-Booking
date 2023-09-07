import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignupComponent } from './Components/signup/signup.component';
import { LoginComponent } from './Components/login/login.component';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { authenticationGuard } from 'src/app/Guards/authentication.guard';

const routes:Routes =[
  {
    path:'login', component: LoginComponent , canActivate:[authenticationGuard]
  },
  {
    path:'signup',component:SignupComponent
  }
]
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    InputTextModule,
    ButtonModule,
    RouterModule.forChild(routes),

  ],
  declarations: [
    SignupComponent,
    LoginComponent
  ]
})
export class UsersModule { }
