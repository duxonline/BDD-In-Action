using System;
using System.Linq;
using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;
using BddTraining.DomainModel.Factories;
using FluentAssert;
using NUnit.Framework;

namespace BddTraining.Specs.Components
{
    [TestFixture]
    public class ShoppingCartSpec
    {
        [Test]
        public void a_cart_item_should_be_created_the_first_time()
        {
            // Arrange
            var command = new CreateProductCmd("TDD", 50m, true, ProductType.Book);
            var product = ProductFactory.Create(command);
            product.ID = Guid.NewGuid();

            var shoppingCart = new ShoppingCart();

            // Act
            shoppingCart.Add(product, 1);

            // Assert
            shoppingCart.CartItems.Count().ShouldBeEqualTo(1);

            Validate(shoppingCart, product, 1);
        }

        [Test]
        public void the_car_item_should_be_updated_the_second_time()
        {
            // Arrange
            var command = new CreateProductCmd("TDD", 50m, true, ProductType.Normal);
            var product = ProductFactory.Create(command);
            product.ID = Guid.NewGuid();

            var shoppingCart = new ShoppingCart();

            // Act
            shoppingCart.Add(product, 1);
            shoppingCart.Add(product, 1);

            // Assert
            shoppingCart.CartItems.Count().ShouldBeEqualTo(1);

            Validate(shoppingCart, product, 2);
        }

        private static void Validate(ShoppingCart shoppingCart, Product product, int quantity)
        {
            var cartItem = shoppingCart.CartItems.First();
            cartItem.ProductID.ShouldBeEqualTo(product.ID);
            cartItem.Name.ShouldBeEqualTo(product.Name);
            cartItem.Price.ShouldBeEqualTo(product.Price);
            cartItem.Quantity.ShouldBeEqualTo(quantity);

            cartItem.SubTotal.ShouldBeEqualTo(product.Price * cartItem.Quantity);
            var taxPerUnit = product.CalcSalesTax() + product.CalcImportDuty();
            cartItem.Tax.ShouldBeEqualTo(taxPerUnit * cartItem.Quantity);
        }
    }
}
