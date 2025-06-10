using Core.Concretes.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IGameScreenshotService
    {
        Task<GameScreenshot?> GetByIdAsync(int id);
        Task<IEnumerable<GameScreenshot>> GetAllAsync();
        Task AddAsync(GameScreenshot screenshot);
        Task UpdateAsync(GameScreenshot screenshot);
        Task DeleteAsync(int id);
    }
} 