using AutoMapper;
using Blog.App.Filters;
using Blog.App.ViewModels;
using Blog.Data;
using Blog.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Blog.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, User")]
    public class PostsController : ControllerBase
    {
        private readonly BlogDbContext db = new BlogDbContext();
        private readonly IMapper mapper;
        private readonly ILogger<PostsController> logger;

        public PostsController(BlogDbContext db, IMapper mapper, ILogger<PostsController> logger)
        {
            this.db = db;
            this.mapper = mapper;
            this.logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Get(int pageIndex, int itemsPerPage, string userId = null)
        {
            var postsCount = db.Posts.Count();
            var countPages = Math.Ceiling((double)postsCount / (double)itemsPerPage);

            if (pageIndex <= 0 || itemsPerPage <= 0 || pageIndex > countPages)
                return BadRequest();

            var itemsToSkip = (pageIndex - 1) * itemsPerPage;
            var itemsToTake = itemsPerPage;

            if (itemsPerPage * pageIndex > postsCount)
            {
                itemsToTake = postsCount - itemsToSkip;
            }

            var posts = db.Posts
                          .OrderByDescending(p => p.DateCreated)
                          .Skip(itemsToSkip)
                          .Take(itemsToTake)
                          .ToArray();

            return new JsonResult(new { posts, postsCount });
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<Post> GetById(int id)
        {
            var post = db.Posts
                         .Include(p => p.Author)
                         .Include(p => p.Comments)
                            .ThenInclude(c => c.Author)
                         .Include(p => p.Category)
                         .Select(p => mapper.Map<Post, PostViewModel>(p))
                         .SingleOrDefault(p => p.PostId == id);

            //var author = db.Users.Find(post.Author.Id);


            if (post == null)
            {
                logger.LogError($"Post with id = {id} was not found!");
                return NotFound();
            }

            post.Comments = post.Comments.OrderByDescending(c => c.DateCreated).ToArray();

            logger.LogInformation($"The post with id = {id} was found! Its title is: {post.Title}");
            return Ok(post);
        }

        [HttpPost("Create")]
        [TypeFilter(typeof(PostCreatedActionFilter))]
        public ActionResult Create(PostCreateViewModel postData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var post = mapper.Map<PostCreateViewModel, Post>(postData);
            post.AuthorId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            db.Posts.Add(post);
            db.SaveChanges();

            return Ok(post);
        }

        [HttpGet("Edit/{id}")]
        public ActionResult<Post> Edit(int id)
        {
            var post = db.Posts.Include(p => p.Category).SingleOrDefault(p => p.PostId == id);
            var userId = User.FindFirst("id").Value;

            if (post == null)
                return NotFound();

            if (post.AuthorId != userId && !User.IsInRole("Admin"))
                return BadRequest();

            return Ok(post);
        }

        [HttpPost("Edit/{id}")]
        public ActionResult Edit(int id, PostEditViewModel postData)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var post = db.Posts.Find(id);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (post == null)
                return NotFound();

            if (post.AuthorId != userId && !User.IsInRole("Admin"))
                return BadRequest();

            post.Title = postData.Title;
            post.Content = postData.Content;

            db.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var post = db.Posts.Find(id);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (post == null)
                return NotFound();

            if (post.AuthorId != userId && !User.IsInRole("Admin"))
                return BadRequest();

            db.Remove(post);
            db.SaveChanges();

            return Ok();
        }
    }
}
