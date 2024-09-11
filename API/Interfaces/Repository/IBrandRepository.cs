using Core.DTO;

namespace API.Repository
{
    public interface IBrandRepository
    {
        Task CreateBrandAsync(BrandDto brandDto);
        Task DeleteBrandAsync(int id);
        List<BrandDto> GetAllBrands();
        BrandDto GetBrandById(int id);
        void UpdateBrandAsync(BrandDto brandDto);
    }
}