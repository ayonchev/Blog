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
            var users = db.Users
                          .Include(u => u.Posts)
                          .Include(u => u.Comments);

            var result = mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserDashboardViewModel>>(users);

            return Ok(result);
        }
    }
}