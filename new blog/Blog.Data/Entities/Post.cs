using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Blog.Data.Entities
{
    public class Post
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
