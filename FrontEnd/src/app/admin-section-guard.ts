import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminSectionGuard implements CanActivate {

  constructor(
    private router: Router, 
    private authService: AuthService) {}

  canActivate() {
    if (this.authService.isAdmin()) {
      return true;
    }

    this.router.navigateByUrl("/home");
    return false;
  }
}
