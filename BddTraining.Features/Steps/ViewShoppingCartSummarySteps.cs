using System;
using System.Collections.Generic;
using System.Linq;
using BddTraining.DomainModel;
using BddTraining.Features.Steps.Utility;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BddTraining.Features.Steps
{
    [Binding]
    public class ViewShoppingCartSummarySteps
    {
        private IList<Product> _products;
        private ShoppingCart _shoppingCart;

        [Given(@"I have the following two products:")]
        public void GivenIHaveTheFollowingTwoProducts(Table table)
        {
            var commands = table.CreateSet<CreateProductCmd>();
            _products = ProductBuilder.Build(commands);
        }

        [When(@"I add them to my cart")]
        public void WhenIAddThemToMyCart()
        {
            _shoppingCart = AddToCart();
        }

        [Then(@"My cart summary should look like following:")]
        public void ThenMyCartSummaryShouldLookLikeFollowing(Table table)
        {
            var entriesExpected = table.CreateSet<CartItemEntry>().ToList();
            var itemsFound = _shoppingCart.CartItems.ToList();

            entriesExpected.Count.ShouldBeEquivalentTo(2);
            Validate(itemsFound, entriesExpected);
        }

        [Then(@"The total price is \$(.*)")]
        public void ThenTheTotalPriceIs(decimal subTotal)
        {
            _shoppingCart.SubTotal.ShouldBeEquivalentTo(subTotal);
        }

        [Then(@"The tax total is \$(.*)")]
        public void ThenTheTaxTotalIs(decimal taxTotal)
        {
            _shoppingCart.TaxTotal.ShouldBeEquivalentTo(taxTotal);
        }

        [Then(@"The grant total is \$(.*)")]
        public void ThenTheGrantTotalIs(decimal grandTotal)
        {
            _shoppingCart.GrandTotal.ShouldBeEquivalentTo(grandTotal);
        }

        private static void Validate(IEnumerable<ShoppingCartItem> itemsFound, IEnumerable<CartItemEntry> entriesExpected)
        {
            var foundItems = itemsFound.OrderBy(i => i.Name).ToList();
            var expectedEntries = entriesExpected.OrderBy(e => e.Name).ToList();

            for (var index = 0; index < foundItems.Count; index++)
            {
                var foundItem = foundItems[index];
                var expectedEntry = expectedEntries[index];

                Validate(foundItem, expectedEntry);
            }
        }

        private static void Validate(ShoppingCartItem foundItem, CartItemEntry expectedEntry)
        {
            foundItem.Name.ShouldBeEquivalentTo(expectedEntry.Name);
            foundItem.Price.ShouldBeEquivalentTo(expectedEntry.Price);
            foundItem.Quantity.ShouldBeEquivalentTo(expectedEntry.Quantity);
            foundItem.SubTotal.ShouldBeEquivalentTo(expectedEntry.SubTotal);
            foundItem.Tax.ShouldBeEquivalentTo(expectedEntry.Tax);
        }

        private ShoppingCart AddToCart()
        {
            var firstCmd = new AddToCartCmd(Guid.Empty, _products[0].ID, 1);
            var firstCart = CartBuilder.Build(firstCmd);

            var secondCmd = new AddToCartCmd(firstCart.ID, _products[1].ID, 1);
            return CartBuilder.Build(secondCmd);
        }
    }
}
