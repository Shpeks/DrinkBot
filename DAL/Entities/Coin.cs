using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enum;

namespace DAL.Entities
{
    public class Coin
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Номинал
        /// </summary>
        [Required]
        public CoinDenomination Denomination { get; set; }

        [Required]
        public int Count { get; set; }
    }
}
