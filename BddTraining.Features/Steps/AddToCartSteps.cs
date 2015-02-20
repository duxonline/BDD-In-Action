using System;
using System.Linq;
using BddTraining.DomainModel;
using BddTraining.Features.Steps.Utility;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BddTraining.Features.Steps
{
    [Binding]
    public class AddToCartSteps
    {
        private Product _product;
        private ShoppingCart _shoppingCart;

        [Given(@"I have the following product:")]
        public void GivenIHaveTheFollowingProduct(Table table)
        {
            var command = table.CreateInstance<CreateProductCmd>();
            _product = ProductBuilder.Build(command);
        }

        [When(@"I add the product to my cart")]
        public void WhenIAddTheProductToMyCart()
        {
            var addToCartCmd = new AddToCartCmd(Guid.Empty, _product.ID, 1);
            _shoppingCart = CartBuilder.Build(addToCartCmd);
        }

        [Then(@"My cart item should look like the following:")]
        public void ThenMyCartItemShouldLookLikeTheFollowing(Table table)
        {
            var itemEntry = table.CreateInstance<CartItemEntry>();
            var cartItem = _shoppingCart.CartItems.First();

            cartItem.Name.ShouldBeEquivalentTo(itemEntry.Name);
            cartItem.Price.ShouldBeEquivalentTo(itemEntry.Price);
            cartItem.Quantity.ShouldBeEquivalentTo(itemEntry.Quantity);
        }
    }
}
