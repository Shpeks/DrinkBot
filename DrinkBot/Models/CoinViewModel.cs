using Core.Enum;

namespace DrinkBot.Models
{
    public class CoinViewModel
    {
        public int Id {  get; set; }

        public string ImagePath {  get; set; }

        public string Denomination { get; set; }
        public int Count { get; set; }
    }
}
