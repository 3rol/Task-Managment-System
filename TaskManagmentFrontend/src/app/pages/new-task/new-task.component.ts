import { Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TaskItem } from 'src/models/taskitem.model';
import { TaskService } from 'src/services/task.service';

@Component({
  selector: 'app-new-task',
  templateUrl: './new-task.component.html',
  styleUrls: ['./new-task.component.css']
})
export class NewTaskComponent implements OnInit {
  task = new TaskItem();
  taskToEdit?: TaskItem;

  constructor(private taskService: TaskService, private router: Router){}

  ngOnInit(): void {
      
  }
  @HostListener('document:change', ['$event.target'])
  onPriorityChange(target: any) {
    if (target.id === 'prioritySelect') {
      const selectedOption = target.options[target.selectedIndex];
      const selectedClass = selectedOption.className;
      target.className = selectedClass;
    }
  }

  createTask(task: TaskItem){
    this.taskService.createTask(task).subscribe((response)=> {
      console.log(response);
      this.router.navigate(['/tasks'])
    });
  }
  
}
