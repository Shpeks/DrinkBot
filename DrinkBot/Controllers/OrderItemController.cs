using API.Repository;
using Core.DTO;
using DrinkBot.Extensions;
using DrinkBot.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrinkBot.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        public OrderItemController(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository, IProductRepository productRepository, IBrandRepository brandRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public IActionResult Index(List<int> selectedItems)
        {
            var products = new List<ProductViewModel>();

            foreach (var itemId in selectedItems)
            {
                var productById = _productRepository.GetProductById(itemId);
                var brandById = _brandRepository.GetBrandById(productById.BrandId);

                if (productById != null)
                {
                    var productViewModel = productById.GetProductViewModel();
                    productViewModel.BrandName = brandById.Name;
                    products.Add(productViewModel);
                }
            }

            return View(products);
        }

        [HttpPost]
        public IActionResult ProceedToPayment(List<int> SelectedProduct, int TotalSum)
        {
            // Проверка на наличие выбранных товаров
            if (SelectedProduct == null || !SelectedProduct.Any())
            {
                return RedirectToAction("Index");
            }

            // Перенаправляем на действие Payment контроллера Payment
            return RedirectToAction("Index", "Payment", new { selectedProduct = SelectedProduct, totalSum = TotalSum });
        }
    }
}
