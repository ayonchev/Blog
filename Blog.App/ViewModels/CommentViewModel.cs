using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.App.ViewModels
{
    public class CommentViewModel
    {
        public UserViewModel Author { get; set; }
        public string AuthorUsername { get; set; }
        public string AnonymousAuthorEmail { get; set; }
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
