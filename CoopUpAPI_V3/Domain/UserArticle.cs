using System;

namespace Domain
{
    public class UserArticle
    {
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public Guid ArticleId { get; set; }
        public virtual Article Article { get; set; }
        public DateTime DateJoined { get; set; }
        public bool IsHost { get; set; }

    }
}