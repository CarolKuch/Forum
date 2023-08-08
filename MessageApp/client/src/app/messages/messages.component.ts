import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Message } from '../_models/Message';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent {
  messages: Message[] = [];
  topicId: string = '';

  constructor(private route: ActivatedRoute, private http: HttpClient) { };

  ngOnInit(): void {
    var id = this.route.snapshot.paramMap.get('topisId');
    this.topicId = id ? id : '';

    this.http.get<Message[]>('https://localhost:7287/Topic/' + this.topicId + '/messages').subscribe({
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

  addMessage(newMessage: Message) {
    this.messages.push(newMessage);
  }
}
