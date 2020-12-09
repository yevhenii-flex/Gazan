import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../models/user';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
  providers: [UserService]
})
export class UsersComponent implements OnInit {

  user: User = new User();   // изменяемый товар
  users: User[];                // массив товаров
  tableMode: boolean = true; 

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.loadUsers();    // загрузка данных при старте компонента  
  }
  // получаем данные через сервис
  loadUsers() {
    this.userService.getgetUsers()
      .subscribe((data: User[]) => this.users = data);
  }

  save() {
    if (this.user.id == null) {
      console.log(this.user);
      this.userService.addUser(this.user)
        .subscribe((data: User) => this.users.push(data));
    } else {
      this.userService.updateUser(this.user)
        .subscribe(data => this.loadUsers());
    }
    this.cancel();
  }
  editUser(u: User) {
    this.user = u;
  }
  cancel() {
    this.user = new User();
    this.tableMode = true;
  }
  deleteUser(u: User) {
    this.userService.deleteUser(u.id)
      .subscribe(data => this.loadUsers());
  }
  addUser() {
    this.cancel();
    this.tableMode = false;
  }

}
