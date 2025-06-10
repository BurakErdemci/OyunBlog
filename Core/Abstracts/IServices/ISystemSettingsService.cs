using Core.Concretes.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface ISystemSettingsService
    {
        Task<SystemSettings?> GetByIdAsync(int id);
        Task<IEnumerable<SystemSettings>> GetAllAsync();
        Task AddAsync(SystemSettings settings);
        Task UpdateAsync(SystemSettings settings);
        Task DeleteAsync(int id);
    }
} 