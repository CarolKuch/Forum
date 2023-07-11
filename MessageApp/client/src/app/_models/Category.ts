import { ICategory } from "../interfaces/ICategory";

export class Category implements ICategory {
  public categoryId: number;
  public title: string;
  public date: string;
  public time: string;
  constructor(categoryId: number = -1, title: string = '', date: string = '', time: string = '') {
    this.categoryId = categoryId;
    this.title = title;
    this.date = date;
    this.time = time;
  }

}
