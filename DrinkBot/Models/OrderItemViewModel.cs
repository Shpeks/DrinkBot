namespace DrinkBot.Models
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }
        
        public string BrandName { get; set; }

        public int Count { get; set; }

        public int Price { get; set; }

        public string ImagePath { get; set; }
    }
}
