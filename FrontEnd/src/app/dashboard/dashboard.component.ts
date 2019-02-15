import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { ItemsPaths } from '../itemsPaths';
import { AuthService } from '../auth.service';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  data: any;
  chart: any;

  constructor(private dataService: DataService, 
              private itemsPaths: ItemsPaths,
              private authService: AuthService) { }

  ngOnInit() {
    this.dataService.getItems(this.itemsPaths.dashboard).subscribe(res => {
      this.data = res;

      this.chart = new Chart('canvas', {
        type: 'doughnut',
        data: {
          datasets: [{
              data: [10, 20, 30]
          }],
      
          // These labels appear in the legend and in the tooltips when hovering different arcs
          labels: [
              'Red',
              'Yellow',
              'Blue'
          ]
      }
        // {
        //   // labels: this.data.categories.map(c => c.name),
        //   labels: ['Other', 'Sports', 'Programming', 'Love'],
        //   datasets: [{
        //     // data: this.data.categories.map(c => c.postsCount),
        //     data: [10, 5, 4, 3],
        //     backgroundColor: [
        //       'rgba(255, 99, 132, 0.2)',
        //       'rgba(54, 162, 235, 0.2)',
        //       'rgba(255, 206, 86, 0.2)',
        //       'rgba(75, 192, 192, 0.2)'
        //     ]
        //   }]
        // }
      });

    });
  }

}
