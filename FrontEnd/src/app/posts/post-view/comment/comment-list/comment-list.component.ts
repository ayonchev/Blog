import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { IComment } from '../../../../models/comment';
import { DataService } from '../../../../data.service';
import { ItemsPaths } from '../../../../itemsPaths';
import { AuthService } from '../../../../auth.service';

@Component({
  selector: 'app-comment-list',
  templateUrl: './comment-list.component.html',
  styleUrls: ['./comment-list.component.css']
})
export class CommentListComponent implements OnInit {
  @Input() comments: Comment[] = [];

  loggedUser: any = this.authService.getLoggedUser();

  constructor(private dataService: DataService, private itemsPaths: ItemsPaths, private authService: AuthService) { }

  ngOnInit() {
    
  }
  
  deleteComment(comment: IComment, index: number) {
    this.dataService.deleteItem(this.itemsPaths.comments, comment.commentId).subscribe(res => {
      this.comments.splice(index, 1);
    });
  }
}
