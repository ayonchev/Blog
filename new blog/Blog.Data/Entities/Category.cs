using System.Collections;
using System.Collections.Generic;

namespace Blog.Data.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}