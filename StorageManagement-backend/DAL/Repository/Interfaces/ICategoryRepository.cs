using DAL.Model;

namespace DAL.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllAsync();

        public Task<Category> GetCategoryByIdAsync(int id);

        public Task<Category> GetCategoryByNameAsync(string name);

        public Task AddNewCategoryAsync(Category category);

        public Task UpdateCategoryAsync(Category category);

        public Task DeleteCategoryByIdAsync(int id);
    }
}
