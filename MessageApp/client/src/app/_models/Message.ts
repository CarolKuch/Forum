import { IMessage } from "../interfaces/IMessage";

export class Message implements IMessage {
  public messageId: number;
  public content: string;
  public date: string;
  public time: string;
  public userLogin: string;
  public userId: number;
  public isUserAdmin: boolean;
  public topicId: number;
  constructor(messageId: number = -1, content: string = '',
    date: string = '', time: string = '', userLogin: string = '',
    userId: number = -1, isUserAdmin: boolean = false, topicId = -1) {
    this.messageId = messageId;
    this.content = content;
    this.date = date;
    this.time = time;
    this.userLogin = userLogin;
    this.userId = userId;
    this.isUserAdmin = isUserAdmin;
    this.topicId = topicId;
  }

}
