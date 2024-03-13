using DAL.Model;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _appDbContext.Orders
                .Include(o => o.User)
                    .ThenInclude(u => u.Role)
                .Include(o => o.Details)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.Category)
                .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _appDbContext.Orders
                .Where(order => order.ID == id)
                .Include(o => o.User)
                    .ThenInclude(u => u.Role)
                .Include(o => o.Details)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Order>> GetOrdersByDateAsync(DateTime date)
        {
            return await _appDbContext.Orders
                .Where(order => order.Date.Equals(date))
                .Include(o => o.User)
                    .ThenInclude(u => u.Role)
                .Include(o => o.Details)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.Category)
                .ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(int userID)
        {
            return await _appDbContext.Orders
                .Where(order => order.UserID == userID)
                .Include(o => o.User)
                    .ThenInclude(u => u.Role)
                .Include(o => o.Details)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => p.Category)
                .ToListAsync();
        }

        public async Task AddNewOrderAsync(Order order)
        {
            await _appDbContext.Orders.AddAsync(order);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteOrderByIdAsync(int id)
        {
            await _appDbContext.Orders.Include(o => o.User).Where(order => order.ID == id).ExecuteDeleteAsync();
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await _appDbContext.Orders.Include(o => o.User).Where(_order => _order.ID == order.ID)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(_order => _order.Date, order.Date)
                .SetProperty(_order => _order.UserID, order.UserID)
                );
            await _appDbContext.SaveChangesAsync();
        }
    }
}
