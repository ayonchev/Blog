using AutoMapper;
using Blog.App.ViewModels;
using Blog.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.App.Profiles
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<RegisterViewModel, ApplicationUser>()
                .ForMember(au => au.UserName, o => o.MapFrom(rvm => rvm.Email));
            CreateMap<ApplicationUser, UserViewModel>();
            CreateMap<ApplicationUser, UserDashboardViewModel>()
                .ForMember(udvm => udvm.PostsCount, o => o.MapFrom(au => au.Posts.Count))
                .ForMember(udvm => udvm.CommentsCount, o => o.MapFrom(au => au.Comments.Count));
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CommentCreateViewModel, Comment>()
                .ForMember(c => c.AnonAuthorEmail, o => o.MapFrom(ccvm => ccvm.AnonymousAuthorEmail));
            CreateMap<Comment, CommentViewModel>()
                .ForMember(cvm => cvm.AnonymousAuthorEmail, o => o.MapFrom(c => c.AnonAuthorEmail));
            CreateMap<Post, PostViewModel>()
                .ForPath(pvm => pvm.Author.Id, o => o.MapFrom(p => p.AuthorId));
                //.ForMember(pvm => pvm.Author.Id, o => o.MapFrom(p => p.AuthorId));
            CreateMap<PostCreateViewModel, Post>();
        }

        //private bool CheckIsUserAdmin(ApplicationUser user)
        //{
        //    var roles = userManager.GetRolesAsync(user).Result;

        //    if (roles.Select(r => r.ToLower()).Contains("admin"))
        //        return true;

        //    return false;
        //}
    }
}
