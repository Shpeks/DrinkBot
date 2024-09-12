using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    /// <summary>
    /// деталь (позиция) заказа
    /// </summary>
    public class OrderItemDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }
        
        public string ProductName { get; set; }

        public string ImagePath { get; set; }

        public string BrandName { get; set; }

        public int Count { get; set; }

        public int Price { get; set; }

    }
}
