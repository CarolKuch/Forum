import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category } from '../_models/Category';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss']
})
export class CategoriesComponent implements OnInit {

  categories: Category[] | any;

  constructor(private http: HttpClient) { };

  ngOnInit(): void {
    this.http.get('https://localhost:7287/Category').subscribe({
      next: response => this.categories = response,
      error: error => console.log(error),
      complete: () => {
        for (let i = 0; i < this.categories.length; i++) {
          this.categories[i].time = this.categories[i].date.slice(11, 16);
          this.categories[i].date = this.categories[i].date.slice(0, 10);
        }
      }
    });
  }

}
