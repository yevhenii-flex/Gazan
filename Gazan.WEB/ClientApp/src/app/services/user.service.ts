import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';

@Injectable()
export class UserService {

  private url = "/api/users";

  constructor(private http: HttpClient) {
  }

  getUsers() {
    return this.http.get(this.url);
  }

  getUser(id: number) {
    return this.http.get(this.url + '/' + id);
  }

  addUser(user: User) {
    return this.http.post(this.url, user);
  }
  updateUser(user: User) {

    return this.http.put(this.url + "/" + user.id, user);
  }
  deleteUser(id: string) {
    return this.http.delete(this.url + '/' + id);
  }
}
