using Core.DTO;
using DrinkBot.Models;

namespace DrinkBot.Extensions
{
    public static class OrderItemViewModelExtension
    {
        public static OrderItemViewModel GetOrderItemViewModel(this OrderItemDto modelDto)
        {
            var orderItem = new OrderItemViewModel
            {
                Id = modelDto.Id,
                BrandName = modelDto.BrandName,
                Count = modelDto.Count,
                ImagePath = modelDto.ImagePath,
                OrderId = modelDto.OrderId,
                Price = modelDto.Price,
                ProductId = modelDto.ProductId,
                ProductName = modelDto.ProductName,
            };

            return orderItem;
        }
    }
}
