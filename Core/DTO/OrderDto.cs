using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public int TotalPrice { get; set; } = 0;

        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}
