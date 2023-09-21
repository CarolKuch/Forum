import { Component, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { AbstractControl, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup = this.createForm();
  constructor(private accountService: AccountService) {

  }

  ngOnInit(): void { }

  createForm(): FormGroup {
    var form = new FormGroup({
      login: new FormControl('', Validators.required),
      password: new FormControl('', [Validators.required, Validators.minLength(6)]),
      confirmPassword: new FormControl('', [Validators.required, this.comparePasswords('password')]),
      name: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required)
    })
    form.controls['password'].valueChanges.subscribe({
      next: () => form.controls['confirmPassword'].updateValueAndValidity()
    })
    return form;
  }

  comparePasswords(compareTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control.value === control.parent?.get(compareTo)?.value ? null : { notMatching: true }
    }
  }

  model: any = {};
  register() {
    console.log(this.registerForm?.value);
    // this.accountService.register(this.model).subscribe({
    //   next: response => {
    //     console.log(response);
    //   },
    //   error: error => console.log(error)
    // });
  }

  cancel() {
    console.log("Canceled");
  }
}
