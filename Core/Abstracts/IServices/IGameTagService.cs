using Core.Concretes.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IGameTagService
    {
        Task<GameTag?> GetByIdAsync(int id);
        Task<IEnumerable<GameTag>> GetAllAsync();
        Task AddAsync(GameTag gameTag);
        Task UpdateAsync(GameTag gameTag);
        Task DeleteAsync(int id);
    }
} 