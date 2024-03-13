using DAL.Model;

namespace BLL_StorageManagement.Service.Interfaces
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAllAsync();

        public Task<Order> GetOrderByIdAsync(int id);

        public Task<List<Order>> GetOrdersByUserIdAsync(int userID);

        public Task<List<Order>> GetOrdersByDateAsync(DateTime date);

        public Task AddNewOrderAsync(Order order);

        public Task UpdateOrderAsync(Order order);

        public Task DeleteOrderByIdAsync(int id);
    }
}
