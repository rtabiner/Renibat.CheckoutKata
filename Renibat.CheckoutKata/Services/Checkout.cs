using System.Collections.Generic;
using Renibat.CheckoutKata.Models;

namespace Renibat.CheckoutKata.Services
{
    public class Checkout
    {
        public int GetTotalPrice(Dictionary<CheckoutItem, int> checkoutItems)
        {
            var totalPrice = 0;

            foreach (var checkoutItem in checkoutItems)
            {
                totalPrice += checkoutItem.Value * checkoutItem.Key.Price;
                totalPrice -= (checkoutItem.Value / checkoutItem.Key.DiscountMultiplier) * checkoutItem.Key.DiscountReduction;
            }

            return totalPrice;
        }
    }
}
