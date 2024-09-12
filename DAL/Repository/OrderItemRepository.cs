using API.Repository;
using Core.DTO;
using DAL.Data;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<OrderItemDto> GetAllOrderItems()
        {
            var orderItemEntity = _context.OrderItems.ToList();
            if (orderItemEntity == null) return null;

            return orderItemEntity.Select(b => new OrderItemDto
            {
                Id = b.Id,
                OrderId = b.OrderId,
                ProductId = b.ProductId,
                BrandName = b.BrandName,
                Count = b.Count,
                ImagePath = b.ImagePath,
                Price = b.Price,
                ProductName = b.ProductName,
            }).ToList();
        }

        public OrderItemDto GetOrderItemById(int id)
        {
            var orderItemEntity = _context.OrderItems.Find(id);
            if (orderItemEntity == null) return null;

            return new OrderItemDto
            {
                Id = orderItemEntity.Id,
                OrderId = orderItemEntity.OrderId,
                ProductId = orderItemEntity.ProductId,
                BrandName = orderItemEntity.BrandName,
                Count = orderItemEntity.Count,
                ImagePath = orderItemEntity.ImagePath,
                Price = orderItemEntity.Price,
                ProductName = orderItemEntity.ProductName,
            };
        }

        public void UpdateOrderItemAsync(OrderItemDto orderItemDto)
        {
            var orderItemEntity = _context.OrderItems.FirstOrDefault(b => b.Id == orderItemDto.Id);
            if (orderItemEntity == null) return;

            orderItemEntity.OrderId = orderItemDto.OrderId;
            orderItemEntity.ProductId = orderItemDto.ProductId;
            orderItemEntity.BrandName = orderItemDto.BrandName;
            orderItemEntity.Count = orderItemDto.Count;
            orderItemEntity.ImagePath = orderItemDto.ImagePath;
            orderItemEntity.Price = orderItemDto.Price;
            orderItemEntity.ProductName = orderItemDto.ProductName;

            _context.SaveChanges();
        }

        public async Task CreateOrderItemAsync(OrderItemDto orderItemDto)
        {
            var orderItemEntity = new OrderItem
            {
                OrderId = orderItemDto.Id,
                ProductId = orderItemDto.ProductId,
                BrandName = orderItemDto.BrandName,
                Count = orderItemDto.Count,
                ImagePath = orderItemDto.ImagePath,
                Price = orderItemDto.Price,
                ProductName = orderItemDto.ProductName,
            };

            await _context.OrderItems.AddAsync(orderItemEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderItemAsync(int id)
        {
            var orderItemEntity = await _context.OrderItems.FindAsync(id);
            if (orderItemEntity != null)
            {
                _context.OrderItems.Remove(orderItemEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
