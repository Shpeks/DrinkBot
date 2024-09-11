namespace DrinkBot.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int BrandId { get; set; }

        public int Count { get; set; }

        public string ImagePath { get; set; }

        public bool IsSelected { get; set; } = false;
    }
}
