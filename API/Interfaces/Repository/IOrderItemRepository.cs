using Core.DTO;

namespace API.Repository
{
    public interface IOrderItemRepository
    {
        Task CreateOrderItemAsync(OrderItemDto orderItemDto);
        Task DeleteOrderItemAsync(int id);
        List<OrderItemDto> GetAllOrderItems();
        OrderItemDto GetOrderItemById(int id);
        void UpdateOrderItemAsync(OrderItemDto orderItemDto);
    }
}