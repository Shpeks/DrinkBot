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

        public string Name { get; set; }

        /// <summary>
        /// Номинал
        /// </summary>
        public int Denomination { get; set; }

        public string ImagePath { get; set; }

        public int Count { get; set; }
    }
    
}
