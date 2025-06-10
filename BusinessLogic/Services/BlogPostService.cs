using Core.Abstracts.IServices;
using Core.Concretes.Entities;
using Data;

namespace BusinessLogic.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlogPostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BlogPost?> GetByIdAsync(int id)
        {
            return await _unitOfWork.BlogPostRepository.ReadByIdAsync(id);
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _unitOfWork.BlogPostRepository.ReadManyAsync();
        }

        public async Task AddAsync(BlogPost blogPost)
        {
            await _unitOfWork.BlogPostRepository.CreateAsync(blogPost);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(BlogPost blogPost)
        {
            await _unitOfWork.BlogPostRepository.UpdateAsync(blogPost);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.BlogPostRepository.ReadByIdAsync(id);
            if (entity != null)
            {
                await _unitOfWork.BlogPostRepository.DeleteAsync(entity);
                await _unitOfWork.CommitAsync();
            }
        }
    }
} 