import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { error } from 'console';
import { Message } from './_models/Message';
import { map } from 'rxjs';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'client';
  messages: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get('https://localhost:7287/Message/dtos').subscribe({
      next: response => this.messages = response,
      error: error => console.log(error),
      complete: () => {
        for (let i = 0; i < this.messages.length; i++) {
          this.messages[i].time = this.messages[i].date.slice(11, 16);
          this.messages[i].date = this.messages[i].date.slice(0, 10);
        }
      }
    });
  }

}
