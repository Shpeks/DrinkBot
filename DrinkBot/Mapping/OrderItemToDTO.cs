using Core.DTO;
using DrinkBot.Models;

namespace DrinkBot.Mapping
{
    public static class OrderItemToDTO
    {
        public static OrderItemDto GetOrderItemDTO(this OrderItemViewModel viewModel)
        {
            var orderItem = new OrderItemDto
            {
                Id = viewModel.Id,
                BrandName = viewModel.BrandName,
                Count = viewModel.Count,
                ImagePath = viewModel.ImagePath,
                OrderId = viewModel.OrderId,
                Price = viewModel.Price,
                ProductId = viewModel.ProductId,
                ProductName = viewModel.ProductName,
            };

            return orderItem;
        }
    }
}
