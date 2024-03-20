import { User } from './../models/user.model';
import { Component } from '@angular/core';

@Component({
  selector: 'app-main-page',
  standalone: true,
  imports: [],
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.css'
})
export class MainPageComponent {
  user: User | null;

  constructor() {
    const storedUser = localStorage.getItem('currentUser');
    this.user = storedUser ? JSON.parse(storedUser) : null;
  }
}
