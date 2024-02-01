import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from 'src/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private router: Router) { }


  public register(user: User): Observable<any>{
    return this.http.post<any>('https://localhost:7082/api/Auth/Register', user);
  }

  public login(user: User): Observable<string> {
    return this.http.post('https://localhost:7082/api/Auth/Login', user, {
      responseType: 'text',
    });
  }

  public logout(){
    localStorage.removeItem('authToken');
    this.router.navigate(['/login']);
    }


  public getUsername(): Observable<string> {
    return this.http.get('https://localhost:7082/api/Auth/GetUsername', {
      responseType: 'text'
    });
  }

  public getUserId(): Observable<string> {
    return this.http.get('https://localhost:7082/api/Auth', {
      responseType: 'text',
      headers: new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem('authToken')}`)
    });
  }
  
}
