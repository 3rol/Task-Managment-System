import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { TaskItem } from 'src/models/taskitem.model';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  private apiUrl = 'https://localhost:7082/api/TaskItems'; 

  constructor(private http: HttpClient) {}

  public getTaskItems(): Observable<TaskItem[]> {
    return this.http.get<TaskItem[]>(`${this.apiUrl}`);
  }
  
  public getTaskItemsByUserId(userId: number): Observable<TaskItem[]> {
    return this.http.get<TaskItem[]>(`${this.apiUrl}/user`);
  }
  
  public getTaskById(taskId: number): Observable<TaskItem> {
    return this.http.get<TaskItem>(`${this.apiUrl}/${taskId}`);
  }

  public updateTask(task: TaskItem): Observable<TaskItem> {
    return this.http.put<TaskItem>(
      `${this.apiUrl}/${task.id}`,
      task
    );
  }

  public createTask(task: TaskItem): Observable<TaskItem[]> {
    return this.http.post<TaskItem[]>(
      `${this.apiUrl}/`,
      task
    );
  }

  public deleteTask(task: TaskItem): Observable<TaskItem[]> {
    return this.http.delete<TaskItem[]>(
      `${this.apiUrl}/${task.id}`
    );
  }
}
