import { IUser } from '../interfaces/IUser';

export class User implements IUser {
  login: string;
  password: string;

  constructor(login: string = '', password: string = '') {
    this.login = login;
    this.password = password
  }
}
