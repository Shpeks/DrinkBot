using API.Repository;
using Core.DTO;
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
        public IActionResult Index(int totalSum, string productData)
        {
            var productDictionary = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, int>>(productData);

            var productIds = productDictionary.Keys.ToList();
            var counts = productDictionary.Values.ToList();

            var cointDto = _coinRepository.GetAllCoins();

            var coinViewModel = cointDto
                .Select(dto => dto.GetCoinViewModel())
                .ToList();


            ViewBag.TotalSum = totalSum;
            ViewBag.ProductIds = productIds;
            ViewBag.Counts = counts;

            return View(coinViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(List<int> productIds, int totalSum)
        {

            var orderDto = new OrderDto
            {
                TotalPrice = totalSum,
                OrderDate = DateTime.Now,
                OrderItems = new List<OrderItemDto>()
            };

            await _orderRepository.CreateOrderAsync(orderDto);

            int orderId = orderDto.Id;

            //foreach (var productEntry in productDictionary)
            //{
            //    int productid = productEntry.Key;
            //    int count = productEntry.Value;

            //    var product = _productRepository.GetProductById(productid);
            //    var brand = _brandRepository.GetBrandById(product.BrandId);

            //    if (product != null)
            //    {
            //        var orderItemDto = new OrderItemDto
            //        {
            //            OrderId = orderId,
            //            ProductName = product.Name,
            //            BrandName = brand.Name,
            //            ProductId = productid,
            //            ImagePath = product.ImagePath,
            //            Count = count,
            //            Price = product.Price,
            //        };

            //        await _orderItemRepository.CreateOrderItemAsync(orderItemDto);
            //    }
            //}

            return View();
        }
    }
}
