import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewMessageFormComponent } from './new-message-form.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ReactiveFormsModule } from '@angular/forms';

import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

describe('NewMessageFormComponent', () => {
  let component: NewMessageFormComponent;
  let fixture: ComponentFixture<NewMessageFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewMessageFormComponent],
      imports: [BrowserModule, HttpClientTestingModule, NgbModule, ReactiveFormsModule],
    })
      .compileComponents();

    fixture = TestBed.createComponent(NewMessageFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
