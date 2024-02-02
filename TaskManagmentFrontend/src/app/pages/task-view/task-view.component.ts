import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { TaskService } from 'src/services/task.service';
import { User } from 'src/models/user.model';
import { TaskItem } from 'src/models/taskitem.model';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-task-view',
  templateUrl: './task-view.component.html',
  styleUrls: ['./task-view.component.css']
})
export class TaskViewComponent implements OnInit {
  @Input() task?: TaskItem;
  @Output() tasksUpdated = new EventEmitter<TaskItem[]>();
  tasks: TaskItem[] = [];
  username: string | null = null;
  loggedInUserId: number | null = null;

  constructor(
    private taskService: TaskService,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.authService.getUsername().subscribe(username => {
      this.username = username; 
    });
  
    this.authService.getUserId().subscribe(id => {
      const userId = parseInt(id); 
      this.loggedInUserId = userId;
      this.taskService.getTaskItemsByUserId(userId).subscribe(tasks => {
        this.tasks = tasks;
      });
    });
  }
  

  deleteTask(task: TaskItem) {
    this.taskService.deleteTask(task).subscribe(() => {
      this.refreshTasks();
    });
  }

  toggleTaskCompletion(task: TaskItem) {
    task.isCompleted = !task.isCompleted; 
    this.taskService.updateTask(task).subscribe(() => {
      console.log(task)
      this.refreshTasks();
    });
  }

  refreshTasks() {
    this.authService.getUserId().subscribe(id => {
      const userId = parseInt(id);
      this.taskService.getTaskItemsByUserId(userId).subscribe(tasks => {
        this.tasks = tasks;
      });
    });
  }

  onLogout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
