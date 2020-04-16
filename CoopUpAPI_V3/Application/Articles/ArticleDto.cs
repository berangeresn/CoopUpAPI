using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Application.Comments;

namespace Application.Articles
{
    public class ArticleDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }

        [JsonPropertyName("attendees")]
        public ICollection<AttendeeDto> UserArticles { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
    }
}