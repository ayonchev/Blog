using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.App.ViewModels
{
    public class CommentCreateViewModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(400)]
        public string Content { get; set; }

        [Required]
        public int PostId { get; set; }

        
        public string AuthorId { get; set; }
        public string AuthorUsername { get; set; }
    }
}
