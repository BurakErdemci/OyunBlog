using Core.Concretes.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface ICommentService
    {
        Task<Comment?> GetByIdAsync(int id);
        Task<IEnumerable<Comment>> GetAllAsync();
        Task AddAsync(Comment comment);
        Task UpdateAsync(Comment comment);
        Task DeleteAsync(int id);
    }
} 