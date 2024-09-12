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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<OrderDto> GetAllOrders()
        {
            var orderEntity = _context.Orders.ToList();
            if (orderEntity == null) return null;

            return orderEntity.Select(b => new OrderDto
            {
                Id = b.Id,
                OrderDate = b.OrderDate,
                TotalPrice = b.TotalPrice,
            }).ToList();
        }

        public OrderDto GetOrderById(int id)
        {
            var orderEntity = _context.Orders.Find(id);
            if (orderEntity == null) return null;

            return new OrderDto
            {
                Id = orderEntity.Id,
                OrderDate = orderEntity.OrderDate,
                TotalPrice = orderEntity.TotalPrice,
            };
        }

        public void UpdateOrderAsync(OrderDto orderDto)
        {
            var orderEntity = _context.Orders.FirstOrDefault(b => b.Id == orderDto.Id);
            if (orderEntity == null) return;

            orderEntity.OrderDate = orderDto.OrderDate;
            orderEntity.TotalPrice = orderDto.TotalPrice;

            _context.SaveChanges();
        }

        public async Task CreateOrderAsync(OrderDto orderDto)
        {
            var orderEntity = new Order
            {
                TotalPrice = orderDto.TotalPrice,
                OrderDate = orderDto.OrderDate,
            };

            await _context.Orders.AddAsync(orderEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var orderEntity = await _context.Orders.FindAsync(id);
            if (orderEntity != null)
            {
                _context.Orders.Remove(orderEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
