using Core.Abstracts.IServices;
using Core.Concretes.Entities;
using Data;

namespace BusinessLogic.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Tag?> GetByIdAsync(int id)
        {
            return await _unitOfWork.TagRepository.ReadByIdAsync(id);
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _unitOfWork.TagRepository.ReadManyAsync();
        }

        public async Task AddAsync(Tag tag)
        {
            await _unitOfWork.TagRepository.CreateAsync(tag);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Tag tag)
        {
            await _unitOfWork.TagRepository.UpdateAsync(tag);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.TagRepository.ReadByIdAsync(id);
            if (entity != null)
            {
                await _unitOfWork.TagRepository.DeleteAsync(entity);
                await _unitOfWork.CommitAsync();
            }
        }
    }
} 