using Core.Abstracts.IRepository;
using System;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGameRepository GameRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IBlogPostRepository BlogPostRepository { get; }
        IGameScreenshotRepository GameScreenshotRepository { get; }
        IGameTagRepository GameTagRepository { get; }
        IReviewRepository ReviewRepository { get; }
        ICommentRepository CommentRepository { get; }
        IDevoloperRepository DevoloperRepository { get; }
        ITagRepository TagRepository { get; }
        ISystemSettingsRepository SystemSettingsRepository { get; }
        IForumTopicRepository ForumTopicRepository { get; }
        IForumReplyRepository ForumReplyRepository { get; }
        IForumCategoryRepository ForumCategoryRepository { get; }
        IForumTagRepository ForumTagRepository { get; }
        IForumTopicTagRepository ForumTopicTagRepository { get; }
        Task CommitAsync();
    }
}
