using System;
using System.Collections.Generic;

namespace Domain
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public virtual ICollection<UserArticle> UserArticles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}