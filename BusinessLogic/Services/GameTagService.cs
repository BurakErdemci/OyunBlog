using Core.Abstracts.IServices;
using Core.Concretes.Entities;
using Data;

namespace BusinessLogic.Services
{
    public class GameTagService : IGameTagService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GameTagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GameTag?> GetByIdAsync(int id)
        {
            return await _unitOfWork.GameTagRepository.ReadByIdAsync(id);
        }

        public async Task<IEnumerable<GameTag>> GetAllAsync()
        {
            return await _unitOfWork.GameTagRepository.ReadManyAsync();
        }

        public async Task AddAsync(GameTag gameTag)
        {
            await _unitOfWork.GameTagRepository.CreateAsync(gameTag);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(GameTag gameTag)
        {
            await _unitOfWork.GameTagRepository.UpdateAsync(gameTag);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.GameTagRepository.ReadByIdAsync(id);
            if (entity != null)
            {
                await _unitOfWork.GameTagRepository.DeleteAsync(entity);
                await _unitOfWork.CommitAsync();
            }
        }
    }
} 