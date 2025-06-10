using Core.Abstracts.IServices;
using Core.Concretes.Entities;
using Data;

namespace BusinessLogic.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReviewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _unitOfWork.ReviewRepository.ReadByIdAsync(id);
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _unitOfWork.ReviewRepository.ReadManyAsync();
        }

        public async Task AddAsync(Review review)
        {
            await _unitOfWork.ReviewRepository.CreateAsync(review);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Review review)
        {
            await _unitOfWork.ReviewRepository.UpdateAsync(review);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.ReviewRepository.ReadByIdAsync(id);
            if (entity != null)
            {
                await _unitOfWork.ReviewRepository.DeleteAsync(entity);
                await _unitOfWork.CommitAsync();
            }
        }
    }
} 