using Core.DTO;
using DrinkBot.Models;

namespace DrinkBot.Extensions
{
    public static class CoinViewModelExtension
    {
        public static CoinViewModel GetCoinViewModel(this CoinDto modelDto)
        {
            var coin = new CoinViewModel
            {
                Id = modelDto.Id,
                Count = modelDto.Count,
                Denomination = modelDto.Denomination.ToString(),
                ImagePath = modelDto.ImagePath,
            };

            return coin;
        }
    }
}
