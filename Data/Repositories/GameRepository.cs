using Core.Abstracts.IRepository;
using Core.Concretes.Entities;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Generics;

namespace Data.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(AppDbContext db) : base(db) { }
    }

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext db) : base(db) { }
    }

    public class BlogPostRepository : Repository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(AppDbContext db) : base(db) { }
    }

    public class GameScreenshotRepository : Repository<GameScreenshot>, IGameScreenshotRepository
    {
        public GameScreenshotRepository(AppDbContext db) : base(db) { }
    }

    public class GameTagRepository : Repository<GameTag>, IGameTagRepository
    {
        public GameTagRepository(AppDbContext db) : base(db) { }
    }

    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(AppDbContext db) : base(db) { }
    }

    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext db) : base(db) { }
    }

    public class DevoloperRepository : Repository<Devoloper>, IDevoloperRepository
    {
        public DevoloperRepository(AppDbContext db) : base(db) { }
    }

    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext db) : base(db) { }
    }

    public class SystemSettingsRepository : Repository<SystemSettings>, ISystemSettingsRepository
    {
        public SystemSettingsRepository(AppDbContext db) : base(db) { }
    }

    public class ForumTopicRepository : Repository<ForumTopic>, IForumTopicRepository
    {
        public ForumTopicRepository(AppDbContext db) : base(db) { }
    }

    public class ForumReplyRepository : Repository<ForumReply>, IForumReplyRepository
    {
        public ForumReplyRepository(AppDbContext db) : base(db) { }
    }

    public class ForumCategoryRepository : Repository<ForumCategory>, IForumCategoryRepository
    {
        public ForumCategoryRepository(AppDbContext db) : base(db) { }
    }

    public class ForumTagRepository : Repository<ForumTag>, IForumTagRepository
    {
        public ForumTagRepository(AppDbContext db) : base(db) { }
    }

    public class ForumTopicTagRepository : Repository<ForumTopicTag>, IForumTopicTagRepository
    {
        public ForumTopicTagRepository(AppDbContext db) : base(db) { }
    }
}
