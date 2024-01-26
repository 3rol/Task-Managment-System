import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }


  public register(user: User): Observable<any>{
    return this.http.post<any>('https://localhost:7082/api/Auth/Register', user);
  }

  public login(user: User): Observable<string> {
    return this.http.post('https://localhost:7082/api/Auth/Login', user, {
      responseType: 'text',
    });
  }

  public getUsername(): Observable<string> {
    return this.http.get('https://localhost:7082/api/Auth', {
      responseType: 'text',
    });
  }
}
