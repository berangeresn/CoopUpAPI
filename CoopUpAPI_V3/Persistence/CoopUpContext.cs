using System;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class CoopUpContext : IdentityDbContext<AppUser>
    {
        public CoopUpContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Value> Values { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<UserArticle> UserArticles { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Value>()
                .HasData(
                    new Value {Id = 1, Name = "Value 101"},
                    new Value {Id = 2, Name = "Value 102"},
                    new Value {Id = 3, Name = "Value 103"}
                );

            builder.Entity<UserArticle>(x => x.HasKey(ua =>
                new {ua.AppUserId, ua.ArticleId}));

            builder.Entity<UserArticle>()
                .HasOne(u => u.AppUser)
                .WithMany(a => a.UserArticles)
                .HasForeignKey(u => u.AppUserId);

            builder.Entity<UserArticle>()
                .HasOne(a => a.Article)
                .WithMany(u => u.UserArticles)
                .HasForeignKey(a => a.ArticleId);
                
        }
    }
}
