import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class UserSectionGuard implements CanActivate {

  constructor(
    private router: Router, 
    private authService: AuthService) {}

  canActivate() {
    if (!this.authService.isTokenExpired() && this.authService.isLogged()) {
      return true;
    }

    this.router.navigateByUrl('/auth/login');
    return false;
  }
}
