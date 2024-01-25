import { Component, Inject, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { TaskItem } from 'src/models/taskitem.model';
import { TaskService } from 'src/services/task.service';


@Component({
  selector: 'app-task-edit',
  templateUrl: './task-edit.component.html',
  styleUrls: ['./task-edit.component.css'],
})
export class TaskEditComponent implements OnInit {
  @Input() task?: TaskItem;
  @Output() tasksUpdated = new EventEmitter<TaskItem[]>();

  constructor(private TaskService: TaskService,) {
  }

  ngOnInit(): void {
    console.log('TaskEditComponent initialized.');
  }

  updateTask(task: TaskItem) {
    this.TaskService.updateTask(task).subscribe((tasks: TaskItem[]) => {
      this.tasksUpdated.emit(tasks);
    });
  }

  deleteTask(task: TaskItem) {
    this.TaskService.deleteTask(task).subscribe((tasks: TaskItem[]) => {
      this.tasksUpdated.emit(tasks);
    });
  }

  createTask(task: TaskItem) {
    this.TaskService.createTask(task).subscribe((tasks: TaskItem[]) => {
      this.tasksUpdated.emit(tasks);
    });
  }
}
