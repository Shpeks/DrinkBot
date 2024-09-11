using DrinkBot.Models;
using Core.DTO;

namespace DrinkBot.Extensions
{
    public static class ProductViewModelExtension
    {
        public static ProductViewModel GetProductViewModel(this ProductDto modelDto)
        {
            var product = new ProductViewModel
            {
                Id = modelDto.Id,
                Name = modelDto.Name,
                BrandId = modelDto.BrandId,
                ImagePath = modelDto.ImagePath,
                Price = modelDto.Price,
                Count = modelDto.Count,
            };

            return product;
        }
    }
}
