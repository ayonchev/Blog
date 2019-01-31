using Blog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.App.ViewModels
{
    public class PostViewModel
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public CategoryViewModel Category { get; set; }

        public UserViewModel Author { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
