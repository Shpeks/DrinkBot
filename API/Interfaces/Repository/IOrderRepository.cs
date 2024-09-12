using Core.DTO;

namespace API.Repository
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(OrderDto orderDto);
        Task DeleteOrderAsync(int id);
        List<OrderDto> GetAllOrders();
        OrderDto GetOrderById(int id);
        void UpdateOrderAsync(OrderDto orderDto);
    }
}