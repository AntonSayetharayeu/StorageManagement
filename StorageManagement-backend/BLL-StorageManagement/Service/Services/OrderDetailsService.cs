using BLL_StorageManagement.Service.Interfaces;
using DAL.Model;
using DAL.Repository.Interfaces;

namespace BLL_StorageManagement.Service.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }

        public async Task<List<OrderDetails>> GetAllAsync()
        {
            return await _orderDetailsRepository.GetAllAsync();
        }

        public async Task<OrderDetails> GetOrderDetailsByIdAsync(int id)
        {
            return await _orderDetailsRepository.GetOrderDetailsByIdAsync(id);
        }

        public async Task<List<OrderDetails>> GetOrderDetailsByOrderIdAsync(int orderID)
        {
            return await _orderDetailsRepository.GetOrderDetailsByOrderIdAsync(orderID);
        }

        public async Task<List<OrderDetails>> GetOrderDetailsByProductIdAsync(int productID)
        {
            return await _orderDetailsRepository.GetOrderDetailsByProductIdAsync(productID);
        }

        public async Task AddNewOrderAsync(OrderDetails orderDetails)
        {
            await _orderDetailsRepository.AddNewOrderAsync(orderDetails);
        }

        public async Task DeleteOrderByIdAsync(int id)
        {
            await _orderDetailsRepository.DeleteOrderByIdAsync(id);
        }

        public async Task UpdateOrderAsync(OrderDetails orderDetails)
        {
            await _orderDetailsRepository.UpdateOrderAsync(orderDetails);
        }
    }
}
