import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/models/user.model';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {
  user = new User();
  constructor(private authService: AuthService, private router: Router){

  }
  ngOnInit(): void {
      
  }

  onLoginButtonClicked(user: User){
    this.authService.login(user).subscribe((token: string) => {
      localStorage.setItem('authToken', token);
      this.router.navigate(['/tasks'])
    }
      
    );
  }
}
