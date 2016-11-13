using System;
using System.Collections.Generic;
using System.Linq;
using BddTraining.Common;
using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;
using BddTraining.Features.Steps.Utility;
using BddTraining.RequestHandlers;
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
            var cmdHandler = DependencyResolver.Resolve<AddToCartCmdHandler>();

            var firstCmd = new AddToCartCmd(null, _products[0].ID, 1);
            _shoppingCart = cmdHandler.Handle(firstCmd);

            var secondCmd = new AddToCartCmd(_shoppingCart.ID, _products[1].ID, 1);
            _shoppingCart = cmdHandler.Handle(secondCmd);
        }

        [Then(@"My cart summary should look like following:")]
        public void ThenMyCartSummaryShouldLookLikeFollowing(Table table)
        {
            var entriesExpected = table.CreateSet<CartItemInput>().ToList();
            var entriesFound = _shoppingCart.CartItems.ToList();

            entriesExpected.Count.ShouldBeEquivalentTo(2);
            Validate(entriesFound, entriesExpected);
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

        private static void Validate(IEnumerable<ShoppingCartItem> itemsFound, IEnumerable<CartItemInput> entriesExpected)
        {
            var foundEntries = itemsFound.OrderBy(i => i.Name).ToList();
            var expectedEntries = entriesExpected.OrderBy(e => e.Name).ToList();

            for (var index = 0; index < foundEntries.Count; index++)
            {
                var foundEntry = foundEntries[index];
                var expectedEntry = expectedEntries[index];

                Validate(foundEntry, expectedEntry);
            }
        }

        private static void Validate(ShoppingCartItem foundEntry, CartItemInput expectedEntry)
        {
            foundEntry.Name.ShouldBeEquivalentTo(expectedEntry.Name);
            foundEntry.Price.ShouldBeEquivalentTo(expectedEntry.Price);
            foundEntry.Quantity.ShouldBeEquivalentTo(expectedEntry.Quantity);
            foundEntry.SubTotal.ShouldBeEquivalentTo(expectedEntry.SubTotal);
            foundEntry.Tax.ShouldBeEquivalentTo(expectedEntry.Tax);
        }
    }
}
