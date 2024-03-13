using BLL_StorageManagement.Service.Interfaces;
using DAL.Model;
using DAL.Repository.Interfaces;

namespace BLL_StorageManagement.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task<Category> GetCategoryByNameAsync(string name)
        {
            return await _categoryRepository.GetCategoryByNameAsync(name);
        }

        public async Task AddNewCategoryAsync(Category category)
        {
            await _categoryRepository.AddNewCategoryAsync(category);
        }

        public async Task DeleteCategoryByIdAsync(int id)
        {
            await _categoryRepository.DeleteCategoryByIdAsync(id);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateCategoryAsync(category);
        }
    }
}
