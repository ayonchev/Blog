import { Component, OnInit } from '@angular/core';
import { DataService } from '../../data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { IPost } from '../../models/post';
import { Pipe } from '@angular/core';
import { IComment } from '../../models/comment';
import { ItemsPaths } from '../../itemsPaths';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-post-view',
  templateUrl: './post-view.component.html',
  styleUrls: ['./post-view.component.css']
})
export class PostViewComponent implements OnInit {
  post: IPost;
  format: string = 'dd.MM.yyyy';

  loggedUser: any = this.authService.getLoggedUser();

  constructor(private dataService: DataService, 
              private route: ActivatedRoute, 
              private router: Router, 
              private itemsPaths: ItemsPaths,
              private authService: AuthService) { }

  ngOnInit() {
    var id = <number>this.route.snapshot.params['id'];
    this.dataService.getItemById<IPost>(this.itemsPaths.posts, id).subscribe(post => {
      this.post = post;
    });
  }

  onCommentAdded(comment: IComment): void {
    this.post.comments.unshift(comment);
  }

  deletePost() {
    this.dataService.deleteItem(this.itemsPaths.posts, this.post.postId).subscribe(res => this.router.navigateByUrl(`/posts`));
  }
}
