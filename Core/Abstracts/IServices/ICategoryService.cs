using Core.Concretes.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface ICategoryService
    {
        Task<Category?> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
} 