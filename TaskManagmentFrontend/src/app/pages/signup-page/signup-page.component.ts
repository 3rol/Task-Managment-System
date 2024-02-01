import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/services/auth.service';
import { HttpResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from 'src/models/user.model';

@Component({
  selector: 'app-signup-page',
  templateUrl: './signup-page.component.html',
  styleUrls: ['./signup-page.component.css']
})
export class SignupPageComponent implements OnInit {
  user = new User();
  constructor(private authService: AuthService, private router: Router){

  }
  ngOnInit(): void {
      
  }

  onSignupButtonClicked(user: User){
    this.authService.register(user).subscribe((response) => {
      console.log(response)
      this.router.navigate(['/login'])
    }
      
    );
  }

}
