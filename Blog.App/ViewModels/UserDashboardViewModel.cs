using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.App.ViewModels
{
    public class UserDashboardViewModel : UserViewModel
    {
        public int PostsCount { get; set; }
        public int CommentsCount { get; set; }
        public bool IsAdmin { get; set; }
    }
}
