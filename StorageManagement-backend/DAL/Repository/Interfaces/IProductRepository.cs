using DAL.Model;

namespace DAL.Repository.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllAsync();

        public Task<Product> GetProductByIdAsync(int id);

        public Task<List<Product>> GetProductsByCategoryIdAsync(int categoryID);

        public Task AddNewProductAsync(Product product);

        public Task UpdateProductAsync(Product product);

        public Task DeleteProductByIdAsync(int id);
    }
}
