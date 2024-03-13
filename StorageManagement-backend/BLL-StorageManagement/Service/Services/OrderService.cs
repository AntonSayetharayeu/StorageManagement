using BLL_StorageManagement.Service.Interfaces;
using DAL.Model;
using DAL.Repository.Interfaces;

namespace BLL_StorageManagement.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetOrderByIdAsync(id);
        }

        public async Task<List<Order>> GetOrdersByDateAsync(DateTime date)
        {
            return await _orderRepository.GetOrdersByDateAsync(date);
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(int userID)
        {
            return await _orderRepository.GetOrdersByUserIdAsync(userID);
        }

        public async Task AddNewOrderAsync(Order order)
        {
            await _orderRepository.AddNewOrderAsync(order);
        }

        public async Task DeleteOrderByIdAsync(int id)
        {
            await _orderRepository.DeleteOrderByIdAsync(id);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await _orderRepository.UpdateOrderAsync(order);
        }
    }
}
