import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { PostsComponent } from './posts/posts.component';
import { PostListItemComponent } from './posts/post-list-item/post-list-item.component';
import { PostViewComponent } from './posts/post-view/post-view.component';
import { NavbarComponent } from './navbar/navbar.component';
import { PostComponent } from './posts/post/post.component';
import { PaginationComponent } from './posts/pagination/pagination.component';
import { CommentListComponent } from './posts/post-view/comment/comment-list/comment-list.component';
import { AddCommentComponent } from './posts/post-view/comment/add-comment/add-comment.component';
import { AuthComponent } from './auth/auth.component';
import { UserSectionGuard } from './user-section-guard';
import { CompareValidatorDirective } from './compare-validator.directive';
import { AuthInterceptor } from './auth-interceptor';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthSectionGuard } from './auth-section-guard';
import { AdminSectionGuard } from './admin-section-guard';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { ProfilePictureComponent } from './user-profile/profile-picture/profile-picture.component';
import { UserProfileMenuComponent } from './user-profile/user-profile-menu/user-profile-menu.component';
import { UserProfileEditComponent } from './user-profile/user-profile-edit/user-profile-edit.component';
import { ChangePasswordComponent } from './user-profile/change-password/change-password.component';

const routes: Routes = [
  { path: 'posts', component: PostsComponent, runGuardsAndResolvers: 'always' },
  { path: 'posts/:id', component: PostComponent, canActivate: [UserSectionGuard] },
  { path: 'posts/view/:id', component: PostViewComponent },
  // { path: 'posts/create', component: PostCreateComponent },
  // { path: 'posts/edit/:id', component: PostEditComponent },
  { path: 'home', component: HomeComponent },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AdminSectionGuard] },
  { path: 'user-profile', component: UserProfileComponent, canActivate: [UserSectionGuard] },
  { path: 'auth/:mode', component: AuthComponent, canActivate: [AuthSectionGuard] },
  { path: '', redirectTo: 'home', pathMatch: 'full' }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PostsComponent,
    PostListItemComponent,
    NavbarComponent,
    PostViewComponent,
    PostComponent,
    PaginationComponent,
    CommentListComponent,
    AddCommentComponent,
    AuthComponent,
    CompareValidatorDirective,
    DashboardComponent,
    UserProfileComponent,
    ProfilePictureComponent,
    UserProfileMenuComponent,
    UserProfileEditComponent,
    ChangePasswordComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes, { onSameUrlNavigation: 'reload' }),
    NgbModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
