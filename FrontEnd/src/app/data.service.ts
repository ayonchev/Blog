import { Injectable } from '@angular/core';

import { IPost } from './models/post';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpResponse, HttpParams } from '@angular/common/http';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private url: string = 'https://localhost:44318/api';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient, private authService: AuthService) { }

  getItems<T>(path: string): Observable<T[]> {
    return this.http.get<T[]>(this.url + path, this.httpOptions);
  }

  getItemsForPage<T>(path: string, params: HttpParams): Observable<any> {
    return this.http.get(this.url + path, {params});
  }

  getItemById<T>(path: string, id: number): Observable<T> {
    return this.http.get<T>(this.url + path + `/${id}`);
  }

  getItemEdit<T>(path: string, id: number): Observable<T> {
    return this.http.get<T>(this.url + path + `/Edit/${id}`, this.httpOptions);
  }

  postItemEdit<T>(path: string, id: number, item: T): Observable<any> {
    return this.http.post(this.url + path + `/Edit/${id}`, item, this.httpOptions);
  }

  createItem<T>(path: string, item: any): Observable<T> {
    return this.http.post<T>(this.url + path + `/Create`, item, this.httpOptions);
  }

  deleteItem(path: string, id: number): Observable<any> {
    return this.http.delete(this.url + path + `/${id}`, this.httpOptions);
  }

  // addComment<T>(id: number, comment: string): Observable<T> {
  //   return this.http.post<T>(this.url + `/AddComment/` + id, JSON.stringify(comment), this.httpOptions);
  // }

  
}