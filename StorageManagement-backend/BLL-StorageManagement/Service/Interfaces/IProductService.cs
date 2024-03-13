using DAL.Model;

namespace BLL_StorageManagement.Service.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllAsync();

        public Task<Product> GetProductByIdAsync(int id);

        public Task<List<Product>> GetProductsByCategoryIdAsync(int categoryID);

        public Task AddNewProductAsync(Product product);

        public Task UpdateProductAsync(Product product);

        public Task DeleteProductByIdAsync(int id);
    }
}
