using System;
using System.Collections.Generic;

namespace WebTestEx.Models.Data
{
    public partial class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        }

        public int BlogId { get; set; }
        public string Url { get; set; } = null!;
        public int Rating { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
