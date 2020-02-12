using System;
using System.Collections.Generic;

namespace AngularBlog.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public int ArticleId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUserName { get; set; }

        public Article Article { get; set; }
    }
}
