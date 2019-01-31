import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { ItemsPaths } from '../itemsPaths';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  data: any;

  constructor(private dataService: DataService, 
              private itemsPaths: ItemsPaths,
              private authService: AuthService) { }

  ngOnInit() {
    this.dataService.getItems(this.itemsPaths.dashboard).subscribe(res => this.data = res);
  }

}
