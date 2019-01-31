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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, User")]
    public class CommentsController : ControllerBase
    {
        private readonly BlogDbContext db;
        private readonly IMapper mapper;

        public CommentsController(BlogDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        public ActionResult Create(CommentCreateViewModel commentData)
        {
            if (!ModelState.IsValid || (commentData.AnonymousAuthorEmail == null && commentData.AuthorId == null))
                return BadRequest();

            var post = db.Posts.Find(commentData.PostId);

            if (post == null)
                return NotFound();

            var comment = mapper.Map<CommentCreateViewModel, Comment>(commentData);

            if(commentData.AnonymousAuthorEmail != null)
                comment.AnonAuthorEmail = comment.AnonAuthorEmail.ToLower();

            db.Comments.Add(comment);
            db.SaveChanges();

            comment = db.Comments
                        .Include(c => c.Author)
                        .SingleOrDefault(c => c.CommentId == comment.CommentId);

            var commentVM = mapper.Map<Comment, CommentViewModel>(comment);

            return Ok(commentVM);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var comment = db.Comments.Find(id);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (comment == null)
                return NotFound();

            if (comment.AuthorId != userId && !User.IsInRole("Admin"))
                return BadRequest();

            db.Remove(comment);
            db.SaveChanges();

            return Ok();
        }
    }
}