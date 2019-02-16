import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
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
  chart = [];

  @ViewChild('chart') chartContainer: ElementRef;

  constructor(private dataService: DataService,
    private itemsPaths: ItemsPaths,
    private authService: AuthService) { }

  ngOnInit() {
    this.dataService.getItems(this.itemsPaths.dashboard).subscribe(res => {
      this.data = res;
      let context = this.setupCanvas(this.chartContainer.nativeElement);
      console.log(context);
      this.chart = new Chart('canvas', {
        type: 'doughnut',
        data:
        //  {
        //   datasets: [{
        //       data: [10, 20, 30]
        //   }],

        //   // These labels appear in the legend and in the tooltips when hovering different arcs
        //   labels: [
        //       'Red',
        //       'Yellow',
        //       'Blue'
        //   ]
        // } 
        {
          labels: this.data.categories.map(c => c.name),
          datasets: [{
            data: this.data.categories.map(c => c.postsCount),
            backgroundColor: [
              'rgb(255, 99, 132)',
              'rgb(54, 162, 235)',
              'rgb(255, 206, 86)',
              'rgb(75, 192, 192)',
              'rgb(255, 32, 243)',
              'rgb(232, 255, 33)',
              'rgb(170, 30, 30)',
              'rgb(165, 3, 108)'
            ]
          }]
        },
        options: {
          responsive: true,
          maintainAspectRatio: false
        }
      });

    });
  }

  setupCanvas(canvas: ElementRef): ElementRef {
    // Get the device pixel ratio, falling back to 1.
    var dpr = window.devicePixelRatio || 1;
    // Get the size of the canvas in CSS pixels.
    var rect = canvas.getBoundingClientRect();
    // Give the canvas pixel dimensions of their CSS
    // size * the device pixel ratio.
    canvas.width = rect.width * dpr;
    canvas.height = rect.height * dpr;
    var ctx = canvas.getContext('2d');
    // Scale all drawing operations by the dpr, so you
    // don't have to worry about the difference.
    ctx.scale(dpr, dpr);

    return canvas;
  }
}
