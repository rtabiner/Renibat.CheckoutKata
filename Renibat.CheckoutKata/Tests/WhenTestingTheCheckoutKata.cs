using System.Collections.Generic;
using NUnit.Framework;
using Renibat.CheckoutKata.Models;
using Renibat.CheckoutKata.Services;

namespace Renibat.CheckoutKata.Tests
{
    [TestFixture]
    public class WhenTestingTheCheckoutKata
    {
        protected Checkout Checkout { get; set; }

        [TestCase(1, 50, 3, 20, 0, 30, 2, 15, 0, 20, 1, 0, 0, 15, 1, 0, 50)]
        [TestCase(2, 50, 3, 20, 0, 30, 2, 15, 0, 20, 1, 0, 0, 15, 1, 0, 100)]
        [TestCase(3, 50, 3, 20, 0, 30, 2, 15, 0, 20, 1, 0, 0, 15, 1, 0, 130)]
        [TestCase(4, 50, 3, 20, 0, 30, 2, 15, 0, 20, 1, 0, 0, 15, 1, 0, 180)]
        [TestCase(5, 50, 3, 20, 0, 30, 2, 15, 0, 20, 1, 0, 0, 15, 1, 0, 230)]
        [TestCase(6, 50, 3, 20, 0, 30, 2, 15, 0, 20, 1, 0, 0, 15, 1, 0, 260)]
        [TestCase(6, 50, 3, 20, 1, 30, 2, 15, 0, 20, 1, 0, 0, 15, 1, 0, 290)]
        [TestCase(6, 50, 3, 20, 2, 30, 2, 15, 0, 20, 1, 0, 0, 15, 1, 0, 305)]
        [TestCase(6, 50, 3, 20, 3, 30, 2, 15, 0, 20, 1, 0, 0, 15, 1, 0, 335)]
        [TestCase(6, 50, 3, 20, 4, 30, 2, 15, 0, 20, 1, 0, 0, 15, 1, 0, 350)]
        [TestCase(6, 50, 3, 20, 4, 30, 2, 15, 1, 20, 1, 0, 0, 15, 1, 0, 370)]
        [TestCase(6, 50, 3, 20, 4, 30, 2, 15, 2, 20, 1, 0, 0, 15, 1, 0, 390)]
        [TestCase(6, 50, 3, 20, 4, 30, 2, 15, 2, 20, 1, 0, 1, 15, 1, 0, 405)]
        [TestCase(6, 50, 3, 20, 4, 30, 2, 15, 2, 20, 1, 0, 2, 15, 1, 0, 420)]
        public void ThenGivenCheckoutItemsReturnExpectedTotal(int numberOfA, int priceOfA, int discountRuleA, int discountValueA, int numberOfB, int priceOfB, int discountRuleB, int discountValueB, int numberOfC, int priceOfC, int discountRuleC, int discountValueC, int numberOfD, int priceOfD, int discountRuleD, int discountValueD, int expectedTotal)
        {
            Checkout = new Checkout();

            var checkoutItems = new Dictionary<CheckoutItem, int>();

            checkoutItems.Add(new CheckoutItem { DiscountMultiplier = discountRuleA, DiscountReduction = discountValueA, Price = priceOfA, Sku = "A" }, numberOfA);
            checkoutItems.Add(new CheckoutItem { DiscountMultiplier = discountRuleB, DiscountReduction = discountValueB, Price = priceOfB, Sku = "B" }, numberOfB);
            checkoutItems.Add(new CheckoutItem { DiscountMultiplier = discountRuleC, DiscountReduction = discountValueC, Price = priceOfC, Sku = "C" }, numberOfC);
            checkoutItems.Add(new CheckoutItem { DiscountMultiplier = discountRuleD, DiscountReduction = discountValueD, Price = priceOfD, Sku = "D" }, numberOfD);

            var result = Checkout.GetTotalPrice(checkoutItems);

            Assert.That(result, Is.EqualTo(expectedTotal));
        }
    }
}
