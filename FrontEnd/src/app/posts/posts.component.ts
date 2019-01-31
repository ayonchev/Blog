import { Component, OnInit, Input } from '@angular/core';
import { DataService } from '../data.service';
import { IPost } from '../models/post';
import { HttpParams } from '@angular/common/http';
import { ActivatedRoute, Params } from '@angular/router';
import { ItemsPaths } from '../itemsPaths';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {
  posts: IPost[] = [];

  pageIndex: number = 1;
  itemsPerPage: number = 10;
  postsCount: number = 0;

  constructor(private dataService: DataService, private route: ActivatedRoute, private itemsPaths: ItemsPaths) { }

  ngOnInit() {
    this.getPosts();

    this.route.queryParams.subscribe((params: Params) => {
      if (!isNaN(params['pageIndex'])) {
        this.pageIndex = params['pageIndex'];
      }
      if (!isNaN(params['itemsPerPage'])) {
        this.itemsPerPage = params['itemsPerPage'];
      }

      this.getPosts();
    });
  }

  getPosts(): void {
    let params = new HttpParams()
      .set('pageIndex', this.pageIndex.toString())
      .set('itemsPerPage', this.itemsPerPage.toString());

    this.dataService.getItemsForPage<IPost>(this.itemsPaths.posts, params).subscribe(res => {
      this.posts = res.posts;
      this.postsCount = res.postsCount;
    });
  }

  onPostDeleted(postId: number): void {
    let index = this.posts.findIndex(p => p.postId === postId);
    this.posts.splice(index, 1);
  }
}
