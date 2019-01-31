import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { IPost } from './models/post';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'FrontEnd';

  constructor(private dataService: DataService) {}

  ngOnInit() {
    
  }
}
