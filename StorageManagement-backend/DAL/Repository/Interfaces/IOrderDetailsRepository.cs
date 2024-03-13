using DAL.Model;

namespace DAL.Repository.Interfaces
{
    public interface IOrderDetailsRepository
    {
        public Task<List<OrderDetails>> GetAllAsync();

        public Task<OrderDetails> GetOrderDetailsByIdAsync(int id);

        public Task<List<OrderDetails>> GetOrderDetailsByOrderIdAsync(int orderID);
        
        public Task<List<OrderDetails>> GetOrderDetailsByProductIdAsync(int productID);

        public Task AddNewOrderAsync(OrderDetails orderDetails);

        public Task UpdateOrderAsync(OrderDetails orderDetails);

        public Task DeleteOrderByIdAsync(int id);
    }
}
