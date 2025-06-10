using Core.Abstracts.IRepository;
using Core.Abstracts.IServices;
using Data.Contexts;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        private IGameRepository? _gameRepository;
        public IGameRepository GameRepository => _gameRepository ??= new GameRepository(_context);

        private ICategoryRepository? _categoryRepository;
        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_context);

        private IBlogPostRepository? _blogPostRepository;
        public IBlogPostRepository BlogPostRepository => _blogPostRepository ??= new BlogPostRepository(_context);

        private IGameScreenshotRepository? _gameScreenshotRepository;
        public IGameScreenshotRepository GameScreenshotRepository => _gameScreenshotRepository ??= new GameScreenshotRepository(_context);

        private IGameTagRepository? _gameTagRepository;
        public IGameTagRepository GameTagRepository => _gameTagRepository ??= new GameTagRepository(_context);

        private IReviewRepository? _reviewRepository;
        public IReviewRepository ReviewRepository => _reviewRepository ??= new ReviewRepository(_context);

        private ICommentRepository? _commentRepository;
        public ICommentRepository CommentRepository => _commentRepository ??= new CommentRepository(_context);

        private IDevoloperRepository? _devoloperRepository;
        public IDevoloperRepository DevoloperRepository => _devoloperRepository ??= new DevoloperRepository(_context);

        private ITagRepository? _tagRepository;
        public ITagRepository TagRepository => _tagRepository ??= new TagRepository(_context);

        private ISystemSettingsRepository? _systemSettingsRepository;
        public ISystemSettingsRepository SystemSettingsRepository => _systemSettingsRepository ??= new SystemSettingsRepository(_context);

        // Forum repository property implementasyonları
        private IForumTopicRepository? _forumTopicRepository;
        public IForumTopicRepository ForumTopicRepository => _forumTopicRepository ??= new ForumTopicRepository(_context);

        private IForumReplyRepository? _forumReplyRepository;
        public IForumReplyRepository ForumReplyRepository => _forumReplyRepository ??= new ForumReplyRepository(_context);

        private IForumCategoryRepository? _forumCategoryRepository;
        public IForumCategoryRepository ForumCategoryRepository => _forumCategoryRepository ??= new ForumCategoryRepository(_context);

        private IForumTagRepository? _forumTagRepository;
        public IForumTagRepository ForumTagRepository => _forumTagRepository ??= new ForumTagRepository(_context);

        private IForumTopicTagRepository? _forumTopicTagRepository;
        public IForumTopicTagRepository ForumTopicTagRepository => _forumTopicTagRepository ??= new ForumTopicTagRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
