using Core.Abstracts.IServices;
using Core.Concretes.Entities;
using Data;

namespace BusinessLogic.Services
{
    public class SystemSettingsService : ISystemSettingsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SystemSettingsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SystemSettings?> GetByIdAsync(int id)
        {
            return await _unitOfWork.SystemSettingsRepository.ReadByIdAsync(id);
        }

        public async Task<IEnumerable<SystemSettings>> GetAllAsync()
        {
            return await _unitOfWork.SystemSettingsRepository.ReadManyAsync();
        }

        public async Task AddAsync(SystemSettings settings)
        {
            await _unitOfWork.SystemSettingsRepository.CreateAsync(settings);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(SystemSettings settings)
        {
            await _unitOfWork.SystemSettingsRepository.UpdateAsync(settings);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.SystemSettingsRepository.ReadByIdAsync(id);
            if (entity != null)
            {
                await _unitOfWork.SystemSettingsRepository.DeleteAsync(entity);
                await _unitOfWork.CommitAsync();
            }
        }
    }
} 