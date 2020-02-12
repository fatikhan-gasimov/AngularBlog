using System;
using System.Collections.Generic;

namespace AngularBlog.Models
{
    public partial class Article
    {
        public Article()
        {
            Comment = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }
        public int? ViewCount { get; set; }

        public Category Category { get; set; }
        public ICollection<Comment> Comment { get; set; }
    }
}
