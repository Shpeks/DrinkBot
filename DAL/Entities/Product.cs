using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string? ImagePath { get; set; }

        [Required]
        public int Price { get; set; }

        /// <summary>
        /// Имеется в автомате
        /// </summary>
        [Required]
        public int Count { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
