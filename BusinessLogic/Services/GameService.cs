using Core.Abstracts.IServices;
using Core.Concretes.Entities;
using Data;

namespace BusinessLogic.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Game?> GetByIdAsync(int id)
        {
            return await _unitOfWork.GameRepository.ReadByIdAsync(id);
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _unitOfWork.GameRepository.ReadManyAsync();
        }

        public async Task AddAsync(Game game)
        {
            await _unitOfWork.GameRepository.CreateAsync(game);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Game game)
        {
            await _unitOfWork.GameRepository.UpdateAsync(game);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.GameRepository.ReadByIdAsync(id);
            if (entity != null)
            {
                await _unitOfWork.GameRepository.DeleteAsync(entity);
                await _unitOfWork.CommitAsync();
            }
        }
    }
} 