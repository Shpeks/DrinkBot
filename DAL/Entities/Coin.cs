using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Coin
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Номинал
        /// </summary>
        [Required]
        public int Denomination { get; set; }

        public string ImagePath {  get; set; }

        [Required]
        public int Count { get; set; }
    }
}
