﻿using System;
using System.Collections.Generic;

namespace AngularBlog.Models
{
    public partial class Category
    {
        public Category()
        {
            Article = new HashSet<Article>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Article> Article { get; set; }
    }
}
