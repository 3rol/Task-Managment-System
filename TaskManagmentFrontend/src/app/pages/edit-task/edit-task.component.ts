import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TaskService } from 'src/services/task.service';
import { TaskItem } from 'src/models/taskitem.model';
import { Params, ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.css']
})
export class EditTaskComponent implements OnInit {
  @Input() task?: TaskItem;
  @Output() tasksUpdated = new EventEmitter<TaskItem>();

  // tasks: TaskItem[] = [];
  // taskToEdit?: TaskItem;

  constructor(private route: ActivatedRoute, private taskService: TaskService, private router: Router) { }

  
  

  
  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      const taskId = params['taskId'];
      this.taskService.getTaskById(taskId).subscribe((task: TaskItem) => {
        this.task = task;
      });
    });
    
  }

  updateTask(task: TaskItem) {
    if (task) { 
      this.taskService.updateTask(task).subscribe((updatedTask: TaskItem) => {
        this.tasksUpdated.emit(updatedTask);
        this.router.navigate(['/tasks'])
      });
    }
  }
  
  

}