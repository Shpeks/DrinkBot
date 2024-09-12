namespace DrinkBot.Models
{
    public class OrderPaymentView
    {
        public IDictionary<int, int> Products { get; set; }

        public int TotalSum { get; set; }
    }
}
