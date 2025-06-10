using Core.Abstracts.IServices;
using Core.Concretes.Entities;
using Data;

namespace BusinessLogic.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _unitOfWork.CommentRepository.ReadByIdAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _unitOfWork.CommentRepository.ReadManyAsync();
        }

        public async Task AddAsync(Comment comment)
        {
            await _unitOfWork.CommentRepository.CreateAsync(comment);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Comment comment)
        {
            await _unitOfWork.CommentRepository.UpdateAsync(comment);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.CommentRepository.ReadByIdAsync(id);
            if (entity != null)
            {
                await _unitOfWork.CommentRepository.DeleteAsync(entity);
                await _unitOfWork.CommitAsync();
            }
        }
    }
} 