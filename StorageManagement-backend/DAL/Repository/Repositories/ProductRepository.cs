using DAL.Model;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _appDbContext.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _appDbContext.Products.Include(p => p.Category).FirstOrDefaultAsync(product => product.ID == id);
        }

        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryID)
        {
            return await _appDbContext.Products.Include(p => p.Category).Where(product => product.CategoryID == categoryID).ToListAsync();
        }

        public async Task DeleteProductByIdAsync(int id)
        {
            await _appDbContext.Products.Include(p => p.Category).Where(product => product.ID == id).ExecuteDeleteAsync();
            await _appDbContext.SaveChangesAsync();
        }

        public async Task AddNewProductAsync(Product product)
        {
            await _appDbContext.Products.AddAsync(product);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _appDbContext.Products.Include(p => p.Category).Where(_product => _product.ID == product.ID).
                ExecuteUpdateAsync(setter => setter
                .SetProperty(_product => _product.Name, product.Name)
                .SetProperty(_product => _product.Description, product.Description)
                .SetProperty(_product => _product.UnitPrice, product.UnitPrice)
                .SetProperty(_product => _product.Photo, product.Photo)
                .SetProperty(_product => _product.CategoryID, product.CategoryID)
                );
            await _appDbContext.SaveChangesAsync();
        }
    }
}
