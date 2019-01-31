import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {
  mode: string = '';

  name: string = '';
  email: string = '';
  password: string = '';
  confirmPassword: string = '';

  constructor(private route: ActivatedRoute, private router: Router, private authService: AuthService) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.mode = params['mode'];
      this.checkMode();
    });
  }

  register() {
    let user = {
      name: this.name,
      email: this.email,
      password: this.password
    };

    this.authService.register(user);
  }

  login() {
    let user = {
      email: this.email,
      password: this.password
    };

    this.authService.login(user);
  }

  private checkMode() {
    if(!(this.mode === 'register' || this.mode === 'login')) {
      this.router.navigateByUrl(`/home`);
    }
  }
}
