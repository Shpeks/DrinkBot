using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    /// <summary>
    /// деталь (позиция) заказа
    /// </summary>
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [ForeignKey("Product")]
        [Required]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(100)]
        public string BrandName { get; set; }

        [MaxLength(255)]
        public string ImagePath { get; set; }

        /// <summary>
        /// Выбранное количество продуктов
        /// </summary>
        [Required]
        public int Count { get; set; }

        [Required]
        public int Price { get; set; }

        public Product Product { get; set; }

        public Order Order { get; set; }
    }
}
