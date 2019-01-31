import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-profile-edit',
  templateUrl: './user-profile-edit.component.html',
  styleUrls: ['./user-profile-edit.component.css']
})
export class UserProfileEditComponent implements OnInit {
  name: string = '';
  email: string = '';
  
  constructor() { }

  ngOnInit() {
  }

}
