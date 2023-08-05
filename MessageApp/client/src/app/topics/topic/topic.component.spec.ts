import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopicComponent } from './topic.component';
import { RouterTestingModule } from '@angular/router/testing';

describe('TopicComponent', () => {
  let component: TopicComponent;
  let fixture: ComponentFixture<TopicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TopicComponent],
      imports: [RouterTestingModule]
    })
      .compileComponents();

    fixture = TestBed.createComponent(TopicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
