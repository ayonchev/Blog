import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';

import { IPost } from '../../models/post';
import { DataService } from '../../data.service';
import { ICategory } from '../../models/category';
import { ItemsPaths } from '../../itemsPaths';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
  post: IPost = <IPost>{};
  categories: ICategory[] = [];

  mode: string = 'create';
  id: any;

  constructor(private dataService: DataService,
              private route: ActivatedRoute,
              private router: Router,
              private itemsPaths: ItemsPaths) { 
      this.post.category = <ICategory>{};
    }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.checkMode(params);
    });
  }

  editPost(): void {
    this.dataService.postItemEdit<IPost>(this.itemsPaths.posts, this.id, this.post).subscribe(res => this.redirectToPostView());
  }

  createPost(): void {
    var data = {
      categoryId: this.post.category.categoryId,
      title: this.post.title,
      content: this.post.content
    };

    this.dataService.createItem<IPost>(this.itemsPaths.posts, data).subscribe(post => {
      this.id = post.postId
      this.redirectToPostView();
    });
  }

  private redirectToPostView(): void {
    this.router.navigateByUrl(`/posts/view/${this.id}`);
  }

  private checkMode(params: Params) {
    this.id = params['id'];

    if (this.id !== 'create') {
      this.mode = 'edit';
      this.id = +this.id;

      this.dataService.getItemEdit<IPost>(this.itemsPaths.posts, this.id).subscribe(post => this.post = post);
    } else {
      this.mode = 'create';

      this.dataService.getItems<ICategory>(this.itemsPaths.categories).subscribe(categories => this.categories = categories);
    }
  }
}
