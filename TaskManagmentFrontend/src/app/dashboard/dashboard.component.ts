import { Component, inject } from '@angular/core';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { map } from 'rxjs/operators';
import { TaskService } from 'src/services/task.service';
import { MatDialog } from '@angular/material/dialog';
import { TaskEditComponent } from '../task-edit/task-edit.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  private breakpointObserver = inject(BreakpointObserver);
  tasks: any[] = [];

  constructor(private taskService: TaskService, public dialog: MatDialog) {}

  ngOnInit() {
    this.taskService.getTaskItems().subscribe(data => {
      this.tasks = data;
      
    });
  }
  openEditDialog(task: any): void {
    const dialogRef = this.dialog.open(TaskEditComponent, {
      width: '400px',
      data: { task: task }, 
      
    });

    dialogRef.afterClosed().subscribe((result) => {
      
      console.log('The dialog was closed');
    });
  }
  cards = this.breakpointObserver.observe(Breakpoints.Handset).pipe(
    map(({ matches }) => {
      if (matches) {
        return [
          { title: 'Card 1', cols: 1, rows: 1 },
          { title: 'Card 2', cols: 1, rows: 1 },
          { title: 'Card 3', cols: 1, rows: 1 },
          { title: 'Card 4', cols: 1, rows: 1 }
        ];
      }

      return [
        { title: 'Card 1', cols: 2, rows: 1 },
        { title: 'Card 2', cols: 1, rows: 1 },
        { title: 'Card 3', cols: 1, rows: 2 },
        { title: 'Card 4', cols: 1, rows: 1 }
      ];
    })
  );
}
