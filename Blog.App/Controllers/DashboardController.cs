using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Blog.App.ViewModels;
using Blog.Data;
using Blog.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DashboardController : ControllerBase
    {
        private readonly BlogDbContext db;
        private readonly IMapper mapper;

        public DashboardController(BlogDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public  async Task<ActionResult> Get()
        {
            var userId = User.FindFirstValue("id");

            var usersData = db.Users
                              .Where(u => u.Id != userId)
                              .Include(u => u.Posts)
                              .Include(u => u.Comments)
                              .ToArray();

            var anonymousUsers = db.Comments
                                   .Where(c => c.AnonAuthorEmail != null)
                                   .Select(c => c.AnonAuthorEmail)
                                   .Distinct()
                                   .Select(email => new
                                   {
                                       email,
                                       CommentsCount = db.Comments.Where(c => c.AnonAuthorEmail == email).Count()
                                   })
                                   .ToArray();

            var users = mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserDashboardViewModel>>(usersData);

            var categories = db.Categories
                               .Select(c => new
                               {
                                   Name = c.Name,
                                   PostsCount = c.Posts.Count()
                               })
                               .ToArray();

            return Ok(new { users, anonymousUsers, categories });
        }
    }
}