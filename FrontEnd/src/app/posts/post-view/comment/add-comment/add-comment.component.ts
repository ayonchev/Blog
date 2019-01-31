import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { DataService } from '../../../../data.service';
import { ActivatedRoute } from '@angular/router';
import { IComment } from '../../../../models/comment';
import { AuthService } from '../../../../auth.service';
import { ItemsPaths } from '../../../../itemsPaths';


@Component({
  selector: 'app-add-comment',
  templateUrl: './add-comment.component.html',
  styleUrls: ['./add-comment.component.css']
})
export class AddCommentComponent implements OnInit {
  @Output() commentAdded: EventEmitter<IComment> = new EventEmitter<IComment>();
  commentContent: string = '';
  authorEmail: string = null;

  constructor(private dataService: DataService, 
              private route: ActivatedRoute, 
              private authService: AuthService,
              private itemsPaths: ItemsPaths) { }

  ngOnInit() {
  }

  addComment(): void {
    let id = +this.route.snapshot.params['id'];

    let commentData = {
      postId: id,
      content: this.commentContent,
      authorId: this.authService.isLogged() ? this.authService.getLoggedUser().id : null,
      anonymousAuthorEmail: this.authorEmail
    }
    // console.log(commentData);
    this.dataService.createItem<IComment>(this.itemsPaths.comments, commentData).subscribe(comment => {
      this.commentAdded.emit(comment);
      this.commentContent = '';
    });
  }
}
