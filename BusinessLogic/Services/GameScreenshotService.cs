using Core.Abstracts.IServices;
using Core.Concretes.Entities;
using Data;

namespace BusinessLogic.Services
{
    public class GameScreenshotService : IGameScreenshotService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GameScreenshotService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GameScreenshot?> GetByIdAsync(int id)
        {
            return await _unitOfWork.GameScreenshotRepository.ReadByIdAsync(id);
        }

        public async Task<IEnumerable<GameScreenshot>> GetAllAsync()
        {
            return await _unitOfWork.GameScreenshotRepository.ReadManyAsync();
        }

        public async Task AddAsync(GameScreenshot screenshot)
        {
            await _unitOfWork.GameScreenshotRepository.CreateAsync(screenshot);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(GameScreenshot screenshot)
        {
            await _unitOfWork.GameScreenshotRepository.UpdateAsync(screenshot);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.GameScreenshotRepository.ReadByIdAsync(id);
            if (entity != null)
            {
                await _unitOfWork.GameScreenshotRepository.DeleteAsync(entity);
                await _unitOfWork.CommitAsync();
            }
        }
    }
} 