import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Message } from 'src/app/_models/Message';

@Component({
  selector: 'app-new-message-form',
  templateUrl: './new-message-form.component.html',
  styleUrls: ['./new-message-form.component.scss']
})
export class NewMessageFormComponent {
  form: FormGroup;
  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.form = this.createForm();
  }

  createForm() {
    return this.fb.group({
      content: ['', Validators.compose(
        [Validators.minLength(5), Validators.required])]
    });
  }

  onSubmit() {
    if (this.form.valid) {
      var message = new Message();
      message.content = this.form.value["content"];
      message.userId = 3;
      message.topicId = 31;
      const headers = new HttpHeaders();
      return this.http.post(
        'https://localhost:7287/Message',
        { "content": message.content, "userId": 2, "topicId": 31 },
        { headers, responseType: 'text' }
      ).subscribe();
    } else {
      return "Message invalid";
    }
  }
}
