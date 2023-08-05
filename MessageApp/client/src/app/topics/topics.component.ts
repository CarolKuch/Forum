import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Topic } from '../_models/Topic';
import { ActivatedRoute } from '@angular/router';
import { Category } from '../_models/Category';

@Component({
  selector: 'app-topics',
  templateUrl: './topics.component.html',
  styleUrls: ['./topics.component.scss']
})
export class TopicsComponent implements OnInit {
  public categoryId: string | null = "";
  public categoryTitle: string | null = "";
  topics: Topic[] | any;
  category: Category[] | any;

  constructor(private route: ActivatedRoute, private http: HttpClient) { }

  ngOnInit(): void {
    this.categoryId = this.route.snapshot.paramMap.get('categoryId');

    this.http.get('https://localhost:7287/Topic/categoryId/' + this.categoryId).subscribe({
      next: response => this.topics = response,
      error: error => console.log(error),
      complete: () => {
        for (let i = 0; i < this.topics.length; i++) {
          this.topics[i].time = this.topics[i].date.slice(11, 16);
          this.topics[i].date = this.topics[i].date.slice(0, 10);
        }
      }
    });
  }
}
