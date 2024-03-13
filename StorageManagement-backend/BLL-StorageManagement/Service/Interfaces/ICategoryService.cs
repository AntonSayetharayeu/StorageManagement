using DAL.Model;

namespace BLL_StorageManagement.Service.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAllAsync();

        public Task<Category> GetCategoryByIdAsync(int id);

        public Task<Category> GetCategoryByNameAsync(string name);

        public Task AddNewCategoryAsync(Category category);

        public Task UpdateCategoryAsync(Category category);

        public Task DeleteCategoryByIdAsync(int id);
    }
}
