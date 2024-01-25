import { Component } from '@angular/core';
import { TaskItem } from 'src/models/taskitem.model';
import { TaskService } from 'src/services/task.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'TaskItem.UI';
  tasks: TaskItem[] = [];
  taskToEdit?: TaskItem;

  constructor(private taskService: TaskService) {}

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
}