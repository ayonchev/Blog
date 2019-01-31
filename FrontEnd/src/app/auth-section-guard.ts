import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from './auth.service';
import { UserSectionGuard } from './user-section-guard';

@Injectable({
  providedIn: 'root'
})
export class AuthSectionGuard implements CanActivate {

  constructor(
    private router: Router, 
    private userSectionGuard: UserSectionGuard,
    private authService: AuthService) {}

  canActivate(): boolean {
    if(!this.authService.isLogged())
        return true;
    
    this.router.navigateByUrl("/home");
    return false;
  }
}
