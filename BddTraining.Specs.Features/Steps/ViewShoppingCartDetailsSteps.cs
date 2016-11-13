using System.Collections.Generic;
using System.Linq;
using BddTraining.Common;
using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;
using BddTraining.Features.Steps.Utility;
using BddTraining.RequestHandlers.Interfaces;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BddTraining.Features.Steps
{
    [Binding]
    public class ViewShoppingCartDetailsSteps
    {
        private IList<Product> _products;
        private ShoppingCart _cartCreated;
        private ShoppingCart _cartRetrieved;

        [Given(@"I have the following products added to my cart:")]
        public void GivenIHaveTheFollowingProductsAddedToMyCart(Table table)
        {
            var commands = table.CreateSet<CreateProductCmd>();
            _products = ProductBuilder.Build(commands);

            var cmdHandler = DependencyResolver.Resolve<IAddToCartCmdHandler>();

            var firstCmd = new AddToCartCmd(null, _products[0].ID, 1);
            _cartCreated = cmdHandler.Handle(firstCmd);

            var secondCmd = new AddToCartCmd(_cartCreated.ID, _products[1].ID, 1);
            _cartCreated = cmdHandler.Handle(secondCmd);
        }
        
        [When(@"I view my shopping cart details")]
        public void WhenIViewMyShoppingCartDetails()
        {
            var queryHandler = DependencyResolver.Resolve<ICartQueryHandler>();
            _cartRetrieved = queryHandler.GetCartDetails(_cartCreated.ID);
        }
        
        [Then(@"My cart details should look like following:")]
        public void ThenMyCartDetailsShouldLookLikeFollowing(Table table)
        {
            var entriesExpected = table.CreateSet<CartItemInput>().ToList();
            var entriesRetrieved = _cartRetrieved.CartItems.ToList();

            entriesExpected.Count.ShouldBeEquivalentTo(2);
            Validate(entriesRetrieved, entriesExpected);
        }


        [Then(@"The total price is \$(.*)")]
        public void ThenTheTotalPriceIs(decimal subTotal)
        {
            _cartRetrieved.SubTotal.ShouldBeEquivalentTo(subTotal);
        }

        [Then(@"The tax total is \$(.*)")]
        public void ThenTheTaxTotalIs(decimal taxTotal)
        {
            _cartRetrieved.TaxTotal.ShouldBeEquivalentTo(taxTotal);
        }

        [Then(@"The grant total is \$(.*)")]
        public void ThenTheGrantTotalIs(decimal grandTotal)
        {
            _cartRetrieved.GrandTotal.ShouldBeEquivalentTo(grandTotal);
        }

        private static void Validate(IEnumerable<ShoppingCartItem> itemsRetrieved, IEnumerable<CartItemInput> entriesExpected)
        {
            var retrievedEntries = itemsRetrieved.OrderBy(i => i.Name).ToList();
            var expectedEntries = entriesExpected.OrderBy(e => e.Name).ToList();

            for (var index = 0; index < retrievedEntries.Count; index++)
            {
                var retrievedEntry = retrievedEntries[index];
                var expectedEntry = expectedEntries[index];

                Validate(retrievedEntry, expectedEntry);
            }
        }

        private static void Validate(ShoppingCartItem retrievedEntry, CartItemInput expectedEntry)
        {
            retrievedEntry.Name.ShouldBeEquivalentTo(expectedEntry.Name);
            retrievedEntry.Price.ShouldBeEquivalentTo(expectedEntry.Price);
            retrievedEntry.Quantity.ShouldBeEquivalentTo(expectedEntry.Quantity);
            retrievedEntry.SubTotal.ShouldBeEquivalentTo(expectedEntry.SubTotal);
            retrievedEntry.Tax.ShouldBeEquivalentTo(expectedEntry.Tax);
        }    
    }
}
