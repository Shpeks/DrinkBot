using Core.DTO;
using DrinkBot.Models;

namespace DrinkBot.Mapping
{
    public static class ProductToDTO
    {
        public static ProductDto GetProductDTO(this ProductViewModel viewModel)
        {
            var product = new ProductDto
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                BrandId = viewModel.BrandId,
                ImagePath = viewModel.ImagePath,
                Price = viewModel.Price,
                Count = viewModel.Count,
            };

            return product;
        }
    }
}
