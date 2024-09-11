using Microsoft.AspNetCore.Http;

namespace API.Interfaces.Services
{
    public interface IProductService
    {
        Task<string> ImportExcelAsync(IFormFile file);
    }
}