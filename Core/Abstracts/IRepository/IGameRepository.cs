using Core.Concretes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Generics;

namespace Core.Abstracts.IRepository
{
    public interface IGameRepository : IRepository<Game> { }
    public interface ICategoryRepository : IRepository<Category> { }
    public interface IBlogPostRepository : IRepository<BlogPost> { }
    public interface IGameScreenshotRepository : IRepository<GameScreenshot> { }
    public interface IGameTagRepository : IRepository<GameTag> { }
    public interface IReviewRepository : IRepository<Review> { }
    public interface ICommentRepository : IRepository<Comment> { }
    public interface IDevoloperRepository : IRepository<Devoloper> { }
    public interface ITagRepository : IRepository<Tag> { }
    public interface ISystemSettingsRepository : IRepository<SystemSettings> { }
    public interface IForumTopicRepository : IRepository<ForumTopic> { }
    public interface IForumReplyRepository : IRepository<ForumReply> { }
    public interface IForumCategoryRepository : IRepository<ForumCategory> { }
    public interface IForumTagRepository : IRepository<ForumTag> { }
    public interface IForumTopicTagRepository : IRepository<ForumTopicTag> { }
}
