using Core.Concretes.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IBlogPostService
    {
        Task<BlogPost?> GetByIdAsync(int id);
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task AddAsync(BlogPost blogPost);
        Task UpdateAsync(BlogPost blogPost);
        Task DeleteAsync(int id);
    }
} 