using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class CoinDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Номинал
        /// </summary>
        public CoinDenomination Denomination { get; set; }

        public int Count { get; set; }
    }
    
}
