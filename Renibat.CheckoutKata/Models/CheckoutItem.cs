
namespace Renibat.CheckoutKata.Models
{
    public class CheckoutItem
    {
        public string Sku { get; set; }
        public int Price { get; set; }
        public int DiscountMultiplier { get; set; }
        public int DiscountReduction { get; set; }
    }
}
