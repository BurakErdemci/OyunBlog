using Core.Abstracts.IServices;
using Core.Concretes.Entities;
using Data;

namespace BusinessLogic.Services
{
    public class DevoloperService : IDevoloperService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DevoloperService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Devoloper?> GetByIdAsync(int id)
        {
            return await _unitOfWork.DevoloperRepository.ReadByIdAsync(id);
        }

        public async Task<IEnumerable<Devoloper>> GetAllAsync()
        {
            return await _unitOfWork.DevoloperRepository.ReadManyAsync();
        }

        public async Task AddAsync(Devoloper devoloper)
        {
            await _unitOfWork.DevoloperRepository.CreateAsync(devoloper);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Devoloper devoloper)
        {
            await _unitOfWork.DevoloperRepository.UpdateAsync(devoloper);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.DevoloperRepository.ReadByIdAsync(id);
            if (entity != null)
            {
                await _unitOfWork.DevoloperRepository.DeleteAsync(entity);
                await _unitOfWork.CommitAsync();
            }
        }
    }
} 