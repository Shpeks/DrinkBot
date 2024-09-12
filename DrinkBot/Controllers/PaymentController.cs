using API.Repository;
using DrinkBot.Extensions;
using DrinkBot.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrinkBot.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly ICoinRepository _coinRepository;
        public PaymentController(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository, IProductRepository productRepository, IBrandRepository brandRepository, ICoinRepository coinRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _coinRepository = coinRepository;
        }

        [HttpGet]
        public IActionResult Index(List<int> selectedProduct, int totalSum)
        {
            var cointDto = _coinRepository.GetAllCoins();

            var coinViewModel = cointDto
                .Select(dto => dto.GetCoinViewModel())
                .ToList();
            //var products = new List<ProductViewModel>();

            //foreach (var itemId in selectedProduct)
            //{
            //    var productById = _productRepository.GetProductById(itemId);
            //    var brandById = _brandRepository.GetBrandById(productById.BrandId);

            //    if (productById != null)
            //    {
            //        var productViewModel = productById.GetProductViewModel();
            //        productViewModel.BrandName = brandById.Name;
            //        products.Add(productViewModel);
            //    }
            //}

            return View(coinViewModel);
        }
    }
}
