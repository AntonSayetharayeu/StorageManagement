import { Login } from './../models/login.model';
import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { FormsModule } from '@angular/forms';
import { CardModule } from 'primeng/card';
import { Router } from '@angular/router';
import { User } from '../models/user.model';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [
    FormsModule,
    ButtonModule,
    CardModule,
    
  ],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent {

  constructor(private router: Router) {}

  title = 'storage-management';

  loginForm='';
  passwordForm='';

  login:Login = {
    login:'',
    password:''
  };

  user:User={
    name:'Misha',
    age:19,
    login:this.login
  }

  onClick(){
    this.login.login=this.loginForm;
    this.login.password=this.passwordForm;

    if(this.login.login==="lol" && this.login.password) {


      localStorage.setItem('currentUser', JSON.stringify(this.user));
      this.router.navigateByUrl("/main");
    }
  }
}
