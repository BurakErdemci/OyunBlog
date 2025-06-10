using Core.Concretes.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<BlogPost> BlogPosts { get; set; }
        public virtual DbSet<GameScreenshot> GameScreenshots { get; set; }
        public virtual DbSet<GameTag> GameTags { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Devoloper> Devolopers { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<SystemSettings> SystemSettings { get; set; }

       
        public virtual DbSet<ForumTopic> ForumTopics { get; set; }
        public virtual DbSet<ForumReply> ForumReplies { get; set; }
        public virtual DbSet<ForumCategory> ForumCategories { get; set; }
        public virtual DbSet<ForumTag> ForumTags { get; set; }
        public virtual DbSet<ForumTopicTag> ForumTopicTags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
            builder.Entity<ForumTopicTag>()
                .HasKey(ftt => new { ftt.ForumTopicId, ftt.ForumTagId });
            builder.Entity<ForumTopicTag>()
                .HasOne(ftt => ftt.ForumTopic)
                .WithMany(ft => ft.ForumTopicTags)
                .HasForeignKey(ftt => ftt.ForumTopicId);
            builder.Entity<ForumTopicTag>()
                .HasOne(ftt => ftt.ForumTag)
                .WithMany(t => t.ForumTopicTags)
                .HasForeignKey(ftt => ftt.ForumTagId);
        }
    }
}