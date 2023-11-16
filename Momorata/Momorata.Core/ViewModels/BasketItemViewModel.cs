namespace Momorata.Core.ViewModels
{
    public class BasketItemViewModel
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
