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

        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Общая сумма всех позиций в заказе(<see cref="OrderItem.TotalPrice"/>)
        /// </summary>
        public decimal TotalAmount { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } 
    }
}
