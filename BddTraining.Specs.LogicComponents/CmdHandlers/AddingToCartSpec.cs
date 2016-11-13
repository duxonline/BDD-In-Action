using System;
using System.Linq;
using BddTraining.CmdHandlers;
using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;
using BddTraining.DomainModel.Factories;
using BddTraining.DomainModel.Repositories;
using BddTraining.RequestHandlers;
using FluentAssert;
using Moq;
using NUnit.Framework;

namespace BddTraining.UnitTests.CmdHandlers
{
    [TestFixture]
    public class AddingToCartSpec
    {
        [Test]
        public void Should_AddProductsTo_ANewCart()
        {
            // Arrange
            var createProductCmd = new CreateProductCmd("TV", 1000, true, ProductType.Normal);
            var productToReturn = ProductFactory.Create(createProductCmd);
            productToReturn.ID = Guid.NewGuid();

            var addToCartCmd = new AddToCartCmd(Guid.Empty, productToReturn.ID, 1);
            var commandHandler = BuildCmdHandler(productToReturn, null, addToCartCmd);

            // Act
            var shoppingCart = commandHandler.Handle(addToCartCmd);

            // Assert
            shoppingCart.CartItems.Count().ShouldBeEqualTo(1);
        }

        [Test]
        public void Should_AddProductsTo_AnExistingCart()
        {
            // Arrange
            var createProductCmd = new CreateProductCmd("TV", 1000, true, ProductType.Normal);
            var productToReturn = ProductFactory.Create(createProductCmd);
            productToReturn.ID = Guid.NewGuid();

            var addToCartCmd = new AddToCartCmd(Guid.NewGuid(), productToReturn.ID, 1);
            var cartToReturn = new ShoppingCart {ID = addToCartCmd.CartId};
            var commandHandler = BuildCmdHandler(productToReturn, cartToReturn, addToCartCmd);

            // Act
            var updatedCart = commandHandler.Handle(addToCartCmd);

            // Assert
            updatedCart.CartItems.Count().ShouldBeEqualTo(1);
        }

        [Test]
        public void Should_ThrowException_WithInvalidCartID()
        {
            // Arrange
            var createProductCmd = new CreateProductCmd("TV", 1000, true, ProductType.Normal);
            var productToReturn = ProductFactory.Create(createProductCmd);
            productToReturn.ID = Guid.NewGuid();

            var addToCartCmd = new AddToCartCmd(Guid.NewGuid(), productToReturn.ID, 1);
            var commandHandler = BuildCmdHandler(productToReturn, null, addToCartCmd);

            // Act & Assert
            Assert.Throws<Exception>(() => commandHandler.Handle(addToCartCmd));
        }

        private static AddToCartCmdHandler BuildCmdHandler(Product productToReturn, ShoppingCart cartToReturn, AddToCartCmd command)
        {
            var productRepository = new Mock<IProductRepository>();
            var cartRepository = new Mock<IShoppingCartRepository>();

            productRepository.Setup(x => x.Get(command.ProductId)).Returns(productToReturn);
            cartRepository.Setup(x => x.Get(command.CartId)).Returns(cartToReturn);

            return new AddToCartCmdHandler(cartRepository.Object, productRepository.Object);
        }
    }
}
