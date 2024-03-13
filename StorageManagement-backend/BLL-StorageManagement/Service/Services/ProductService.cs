using BLL_StorageManagement.Service.Interfaces;
using DAL.Model;
using DAL.Repository.Interfaces;

namespace BLL_StorageManagement.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryID)
        {
            return await _productRepository.GetProductsByCategoryIdAsync(categoryID);
        }
        public async Task AddNewProductAsync(Product product)
        {
            await _productRepository.AddNewProductAsync(product);
        }

        public async Task DeleteProductByIdAsync(int id)
        {
            await _productRepository.DeleteProductByIdAsync(id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateProductAsync(product);
        }
    }
}
