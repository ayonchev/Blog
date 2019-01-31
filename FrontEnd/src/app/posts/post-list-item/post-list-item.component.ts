import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Pipe } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';

import { IPost } from '../../models/post';
import { DataService } from '../../data.service';
import { AuthService } from '../../auth.service';
import { ItemsPaths } from '../../itemsPaths';

@Component({
  selector: 'app-post-list-item',
  templateUrl: './post-list-item.component.html',
  styleUrls: ['./post-list-item.component.css']
})
export class PostListItemComponent implements OnInit {
  @Input() post: IPost;
  @Output() postDeleted: EventEmitter<number> = new EventEmitter<number>();

  loggedUser: any = this.authService.getLoggedUser();

  format: string = 'dd.MM.yyyy';

  constructor(private dataService: DataService, 
              private authService: AuthService, 
              private router: Router,
              private itemsPaths: ItemsPaths) { }

  ngOnInit() {
  }

  deletePost(event, postId: number) {
    event.stopPropagation();
    this.dataService.deleteItem(this.itemsPaths.posts, postId).subscribe(res => this.postDeleted.emit(postId));
  }
}
