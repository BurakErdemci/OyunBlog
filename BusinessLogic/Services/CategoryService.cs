using Core.Abstracts.IServices;
using Core.Concretes.Entities;
using Data;

namespace BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _unitOfWork.CategoryRepository.ReadByIdAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _unitOfWork.CategoryRepository.ReadManyAsync();
        }

        public async Task AddAsync(Category category)
        {
            await _unitOfWork.CategoryRepository.CreateAsync(category);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            await _unitOfWork.CategoryRepository.UpdateAsync(category);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.CategoryRepository.ReadByIdAsync(id);
            if (entity != null)
            {
                await _unitOfWork.CategoryRepository.DeleteAsync(entity);
                await _unitOfWork.CommitAsync();
            }
        }
    }
} 