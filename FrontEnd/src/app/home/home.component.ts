import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  loggedUser: any = this.authService.getLoggedUser(); 

  constructor(private authService: AuthService) {
   }

  ngOnInit() {
  }

}
