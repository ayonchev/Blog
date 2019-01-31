using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.App.ViewModels;
using Blog.Data;
using Blog.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public ActionResult Get()
        {
            var usersData = db.Users
                          .Include(u => u.Posts)
                          .Include(u => u.Comments);

            var anonymousUsers = db.Comments
                                   .Where(c => c.AnonAuthorEmail != null)
                                   .Select(c => c.AnonAuthorEmail)
                                   .Distinct()
                                   .Select(email => new
                                   {
                                       email,
                                       CommentsCount = db.Comments.Where(c => c.AnonAuthorEmail == email).Count()
                                   });

            var users = mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserDashboardViewModel>>(usersData);

            return Ok(new { users, anonymousUsers });
        }
    }
}