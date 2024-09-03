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

        /// <summary>
        /// Номинал
        /// </summary>
        [Required]
        public CoinDenomination Denomination { get; set; }

        [Required]
        public int Count { get; set; }
    }

    public enum CoinDenomination
    {
        One = 1,
        Two = 2,
        Five = 5,
        Ten = 10
    }
}
