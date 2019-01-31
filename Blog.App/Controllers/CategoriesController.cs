using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.App.ViewModels;
using Blog.Data;
using Blog.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly BlogDbContext db;
        private readonly IMapper mapper;

        public CategoriesController(BlogDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryViewModel>> GetCategories()
        {
            var categories = db.Categories.ToArray();

            return Ok(mapper.Map<Category[], CategoryViewModel[]>(categories));
        }

        [HttpGet("{categoryName}")]
        public ActionResult<Category> GetByCategory(string categoryName)
        {
            var category = db.Categories
                             .Include(c => c.Posts)
                             .SingleOrDefault(c => c.Name == categoryName);

            return Ok(category);
        }
    }
}