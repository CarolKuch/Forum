import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopicsComponent } from './topics.component';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('TopicsComponent', () => {
  let component: TopicsComponent;
  let fixture: ComponentFixture<TopicsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [
        TopicsComponent],
      imports: [HttpClientTestingModule, RouterTestingModule],
    })
      .compileComponents();

    fixture = TestBed.createComponent(TopicsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
