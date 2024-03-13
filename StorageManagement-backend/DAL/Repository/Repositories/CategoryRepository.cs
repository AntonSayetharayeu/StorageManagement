using DAL.Model;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _appDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _appDbContext.Categories.FirstOrDefaultAsync(category => category.ID == id);
        }

        public async Task<Category> GetCategoryByNameAsync(string name)
        {
            return await _appDbContext.Categories.FirstOrDefaultAsync(category => category.Name == name);
        }

        public async Task AddNewCategoryAsync(Category category)
        {
            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryByIdAsync(int id)
        {
            await _appDbContext.Categories.Where(category => category.ID == id).ExecuteDeleteAsync();
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _appDbContext.Categories.Where(_category => _category.ID == category.ID)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(_category => _category.Name, category.Name)
                );
            await _appDbContext.SaveChangesAsync();
        }
    }
}
