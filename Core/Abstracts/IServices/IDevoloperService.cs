using Core.Concretes.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IDevoloperService
    {
        Task<Devoloper?> GetByIdAsync(int id);
        Task<IEnumerable<Devoloper>> GetAllAsync();
        Task AddAsync(Devoloper devoloper);
        Task UpdateAsync(Devoloper devoloper);
        Task DeleteAsync(int id);
    }
} 