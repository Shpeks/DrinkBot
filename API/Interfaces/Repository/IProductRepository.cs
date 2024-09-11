using Core.DTO;

namespace API.Repository
{
    public interface IProductRepository
    {
        Task CreateProductAsync(ProductDto productDto);
        Task DeleteProductAsync(int id);
        List<ProductDto> GetAllProducts();
        ProductDto GetProductById(int id);
        void UpdateProductAsync(ProductDto productDto);
    }
}