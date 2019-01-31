using Microsoft.AspNetCore.Identity;
using System;

namespace Blog.Data.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }
        public string AuthorUsername { get; set; }
    }
}