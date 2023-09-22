import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Output, Input, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Message } from 'src/app/_models/Message';

@Component({
  selector: 'app-new-message-form',
  templateUrl: './new-message-form.component.html',
  styleUrls: ['./new-message-form.component.scss'],
})
export class NewMessageFormComponent {
  @Output() newlyAddedMessageEvent = new EventEmitter<Message>();
  @Input() topicId!: string;
  form: FormGroup;
  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.form = this.createForm();
  }

  createForm() {
    return this.fb.group({
      content: ['', Validators.compose(
        [Validators.minLength(6), Validators.required])]
    });
  }

  onSubmit() {
    if (this.form.valid) {
      const headers = new HttpHeaders();
      this.http.post(
        'https://localhost:7287/Message',
        { "content": this.form.value["content"], "userId": 2, "topicId": this.topicId },
        { headers, responseType: 'text' }
      ).subscribe(res => {
        var message = new Message();
        message = JSON.parse(res);
        message.time = message.date.slice(11, 16);
        message.date = message.date.slice(0, 10);
        this.newlyAddedMessageEvent.emit(message);
      });
      return "Message was added successfully";
    } else {
      return "Message invalid";
    }
  }
}
