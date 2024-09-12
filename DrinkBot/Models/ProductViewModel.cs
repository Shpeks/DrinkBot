namespace DrinkBot.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public string BrandName { get; set; }

        public int Count { get; set; }

        public string ImagePath { get; set; }

        public bool IsSelected { get; set; } = false;
    }
}
