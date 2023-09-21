import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { error } from 'console';
import { Message } from './_models/Message';
import { map } from 'rxjs';
import { AccountService } from './_services/account.service';
import { User } from './_models/User';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'client';
  messages: any;
  categories: any;

  constructor(private http: HttpClient, private accountService: AccountService) { }

  ngOnInit(): void {
    this.getCategories();
    this.setCurrentUser();
  }

  getCategories() {
    this.http.get('https://localhost:7287/Category').subscribe({
      next: response => this.categories = response,
      error: error => console.log(error),
      complete: () => {
        for (let i = 0; i < this.categories.length; i++) {
          this.categories[i].time = this.categories[i].date.slice(11, 16);
          this.categories[i].date = this.categories[i].date.slice(0, 10);
        }
      }
    });
  }

  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user: User = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }
}
