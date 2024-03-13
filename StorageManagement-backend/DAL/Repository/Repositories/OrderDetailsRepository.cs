using DAL.Model;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderDetailsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<OrderDetails>> GetAllAsync()
        {
            return await _appDbContext.OrderDetails
                //.Include(od => od.Order)
                .Include(od => od.Product)
                    .ThenInclude(p => p.Category)
                .ToListAsync();
        }

        public async Task<OrderDetails> GetOrderDetailsByIdAsync(int id)
        {
            return await _appDbContext.OrderDetails
                //.Include(od => od.Order)
                .Where(od => od.ID == id)
                .Include(od => od.Product)
                    .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync();
        }

        public async Task<List<OrderDetails>> GetOrderDetailsByOrderIdAsync(int orderID)
        {
            return await _appDbContext.OrderDetails
                //.Include(od => od.Order)
                .Where(od => od.OrderId == orderID)
                .Include(od => od.Product)
                    .ThenInclude(p => p.Category)
                .ToListAsync();
        }

        public async Task<List<OrderDetails>> GetOrderDetailsByProductIdAsync(int productID)
        {
            return await _appDbContext.OrderDetails
                //.Include(od => od.Order)
                .Where(od => od.ProductId == productID)
                .Include(od => od.Product)
                    .ThenInclude(p => p.Category)
                .ToListAsync();
        }

        public async Task AddNewOrderAsync(OrderDetails orderDetails)
        {
            await _appDbContext.OrderDetails.AddAsync(orderDetails);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteOrderByIdAsync(int id)
        {
            await _appDbContext.OrderDetails.Where(od => od.ID == id).ExecuteDeleteAsync();
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(OrderDetails orderDetails)
        {
            await _appDbContext.OrderDetails.Where(_od => _od.ID == orderDetails.ID)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(od => od.OrderId, orderDetails.OrderId)
                .SetProperty(od => od.ProductId, orderDetails.ProductId)
                .SetProperty(od => od.Amount, orderDetails.Amount)
                );
            await _appDbContext.SaveChangesAsync();
        }
    }
}
