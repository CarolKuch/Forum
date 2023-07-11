import { ITopic } from "../interfaces/ITopic";

export class Topic implements ITopic {
  public topicId: number;
  public title: string;
  public date: string;
  public time: string;
  constructor(categoryId: number = -1, title: string = '', date: string = '', time: string = '') {
    this.topicId = categoryId;
    this.title = title;
    this.date = date;
    this.time = time;
  }
}
