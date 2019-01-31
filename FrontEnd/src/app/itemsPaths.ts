import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class ItemsPaths {
    posts: string = '/Posts';
    categories: string = '/Categories';
    comments: string =  '/Comments';
    dashboard: string = '/Dashboard';
}