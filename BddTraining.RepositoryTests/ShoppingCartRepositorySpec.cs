using System.Linq;
using BddTraining.Common;
using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;
using BddTraining.DomainModel.Factories;
using BddTraining.DomainModel.RepositoryInterfaces;
using FluentAssert;
using NUnit.Framework;
using RosterLive.SharpArch.NHibernate;

namespace BddTraining.RepositoryTests
{
    [TestFixture]
    public class ShoppingCartRepositorySpec : RepositorySpec
    {
        [Test]
        public void Should_CreateAShoppingCart()
        {
            // Arrange
            const int quantity = 1;
            var newCart = new ShoppingCart();
            var product = CreateProduct();
            newCart.AddItem(product, quantity);

            var cartRepository = DependencyResolver.Resolve<IShoppingCartRepository>();

            // Act
            cartRepository.SaveOrUpdate(newCart);
            SessionManager.CommitTrans();

            //Assert
            var cart = cartRepository.Get(newCart.ID);
            cart.CartItems.Count().ShouldBeEqualTo(quantity);

            Validate(cart.CartItems.ToList()[0], product, quantity);
        }

        private static Product CreateProduct()
        {
            var createProductCmd = new CreateProductCmd("TDD", 500, true, ProductType.Normal);
            var product = ProductFactory.Create(createProductCmd);

            var repository = DependencyResolver.Resolve<IProductRepository>();
            repository.SaveOrUpdate(product);
            SessionManager.CommitTrans();

            return product;
        }

        private static void Validate(ShoppingCartItem cartItem, Product product, int quantity)
        {
            cartItem.Name.ShouldBeEqualTo(product.Name);
            cartItem.Price.ShouldBeEqualTo(product.Price);
            cartItem.Quantity.ShouldBeEqualTo(quantity);
            cartItem.SubTotal.ShouldBeEqualTo(product.Price*quantity);

            var taxPerUnit = product.CalcSalesTax() + product.CalcImportDuty();
            cartItem.Tax.ShouldBeEqualTo(taxPerUnit*quantity);
        }
    }
}
