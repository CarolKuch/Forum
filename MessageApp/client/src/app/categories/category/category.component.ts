import { Component, Input } from '@angular/core';
import { Category } from '../../_models/Category';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent {
  @Input() category: Category | undefined;
}
