import { Injectable } from '@angular/core';
import * as jwt_decode from 'jwt-decode';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

export const TOKEN: string = 'jwt_token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private url: string = 'https://localhost:44318/api/auth';

  private headers = new Headers({ 'Content-Type': 'application/json' });
  private httpOptions = {
    responseType: 'text',
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient, private router: Router) { }

  getToken(): string {
    return localStorage.getItem(TOKEN);
  }

  getLoggedUser(): any {
    let token = this.getToken();

    if(!token) 
      return undefined;

    const decoded: any = jwt_decode(this.getToken());

    return decoded;
  }
  
  isTokenExpired(token?: string): boolean {
    if (!token) token = this.getToken();
    if (!token) return true;

    const date = this.getTokenExpirationDate(token);
    if (date === undefined) return false;
    return !(date.valueOf() > new Date().valueOf());
  }
  

  isLogged() {
    return localStorage.getItem(TOKEN) != null;
  }

  isAdmin() {
    if(this.isLogged())
      return this.getLoggedUser().role === 'admin';
    
    return false;
  }

  login(user: { email: string, password: string }) {
    this.authenticate('login', user);
  }

  logout(): void {
    localStorage.removeItem(TOKEN);
    this.router.navigateByUrl('');
  }

  register(user: { name: string, email: string, password: string }) {
    this.authenticate('register', user);
  }

  private authenticate(action: string, user: any) {
    this.http.post(`${this.url}/${action}`, user, {
      responseType: 'text',
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }).subscribe(token => {
      this.setToken(token);
      this.router.navigateByUrl('/home');
    });
  }

  private setToken(token: string): void {
    localStorage.setItem(TOKEN, token);
  }

  private getTokenExpirationDate(token: string): Date {
    const decoded: any = jwt_decode(token);

    if (decoded.exp === undefined) return null;

    const date = new Date(0);
    date.setUTCSeconds(decoded.exp);
    return date;
  }
}