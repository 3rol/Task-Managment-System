import { Component } from '@angular/core';
import { TaskItem } from 'src/models/taskitem.model';
import { TaskService } from 'src/services/task.service';
import { User } from 'src/models/user.model';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'TaskItem.UI';
  tasks: TaskItem[] = [];
  taskToEdit?: TaskItem;
  user = new User();

  constructor(private taskService: TaskService, private authService: AuthService) {}

  ngOnInit(): void {
    this.taskService
      .getTaskItems()
      .subscribe((result: TaskItem[]) => (this.tasks = result));
  }

  updateTask(tasks: TaskItem[]) {
    this.tasks = tasks;
  }

  initNewTask() {
    this.taskToEdit = new TaskItem();
  }

  editTask(task: TaskItem) {
    this.taskToEdit = task;
  }

  register(user: User) {
    this.authService.register(user).subscribe(() => {
      console.log('Registration successful');
      this.login(user);
    });
  }

  login(user: User) {
    this.authService.login(user).subscribe((token: string) => {
      localStorage.setItem('authToken', token);
      console.log('Login successful');
    });
  }

  getUsername() {
    this.authService.getUsername().subscribe((name: string) => {
      console.log('Logged in as: ' + name);
    });
  }
}
