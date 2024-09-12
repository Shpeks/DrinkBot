using API.Repository;
using DAL.Entities;
using DAL.Repository;
using DrinkBot.Extensions;
using DrinkBot.Mapping;
using DrinkBot.Models;
using Microsoft.AspNetCore.Mvc;
using Core.DTO;
using API.Interfaces.Services;
using System.Drawing.Drawing2D;

namespace DrinkBot.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IProductService _productService;
        
        public ProductController(IProductRepository productRepository, IBrandRepository brandRepository, IProductService productService)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index(string brand, List<int> SelectedItems)
        {
            var productDto = _productRepository.GetAllProducts();

            var brands = _brandRepository.GetAllBrands().ToDictionary(b => b.Id, b => b.Name);

            if (!string.IsNullOrEmpty(brand))
            {
                int brandId = brands.FirstOrDefault(b => b.Value == brand).Key;
                productDto = productDto.Where(p => p.BrandId == brandId).ToList();
            }

            var productViewModel = productDto
                .Select(dto => dto.GetProductViewModel())
                .ToList();

            ViewBag.Brands = brands.Values;
            ViewBag.SelectedBrand = brand;

            // Передаем выбранные товары в представление
            ViewBag.SelectedItems = SelectedItems ?? new List<int>();

            return View(productViewModel);
        }


        [HttpPost("ImportExcel")]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            await _productService.ImportExcelAsync(file);
            return RedirectToAction("Index");
        }

        [HttpGet("GetProductsByPriceRange")]
        public IActionResult GetProductsByPriceRange(decimal minPrice, decimal maxPrice, string brand)
        {
            var products = _productRepository.GetAllProducts()
                                             .Where(p => p.Price >= minPrice && p.Price <= maxPrice);

            if (!string.IsNullOrEmpty(brand))
            {
                var brands = _brandRepository.GetAllBrands().ToDictionary(b => b.Id, b => b.Name);
                int brandId = brands.FirstOrDefault(b => b.Value == brand).Key;
                products = products.Where(p => p.BrandId == brandId);
            }

            return Ok(products.ToList());
        }

        [HttpPost]
        public IActionResult SaveSelectedProducts(List<int> SelectedItems)
        {
            if (SelectedItems == null || !SelectedItems.Any())
            {
                // Если ничего не выбрано, вернуться на исходную страницу
                return RedirectToAction("Index");
            }

            // Передача выбранных элементов через параметры
            return RedirectToAction("Index", "OrderItem", new { selectedItems = SelectedItems });
        }
    }
}
