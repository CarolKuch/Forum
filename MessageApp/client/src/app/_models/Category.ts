import { ICategory } from "../interfaces/ICategory";

export class Category implements ICategory {
  public categoryID: number;
  public title: string;
  public date: string;
  public time: string;
  constructor(categoryID: number = -1, title: string = '', date: string = '', time: string = '') {
    this.categoryID = categoryID;
    this.title = title;
    this.date = date;
    this.time = time;
  }

}
