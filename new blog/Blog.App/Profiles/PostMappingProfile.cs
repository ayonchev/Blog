using AutoMapper;
using Blog.App.ViewModels;
using Blog.Data.Entities;

namespace Blog.App.Profiles
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>();
            CreateMap<ApplicationUser, UserDashboardViewModel>()
                .ForMember(ud => ud.PostsCount, au => au.MapFrom(o => o.Posts.Count))
                .ForMember(ud => ud.CommentsCount, au => au.MapFrom(o => o.Comments.Count));
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CommentCreateViewModel, Comment>();
            CreateMap<Comment, CommentViewModel>();
            CreateMap<Post, PostViewModel>();
            CreateMap<PostCreateViewModel, Post>();
        }
    }
}
