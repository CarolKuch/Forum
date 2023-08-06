import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-new-message-form',
  templateUrl: './new-message-form.component.html',
  styleUrls: ['./new-message-form.component.scss']
})
export class NewMessageFormComponent {
  angForm: FormGroup;
  constructor(private fb: FormBuilder) {
    this.angForm = this.createForm();
  }

  createForm() {
    return this.fb.group({
      content: ['', Validators.compose(
        [Validators.minLength(5), Validators.required])]
    });
  }
}
