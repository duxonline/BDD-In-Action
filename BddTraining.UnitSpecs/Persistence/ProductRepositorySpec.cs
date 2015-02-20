using BddTraining.Common;
using BddTraining.DomainModel;
using BddTraining.DomainModel.RepositoryInterfaces;
using FluentAssert;
using NUnit.Framework;
using RosterLive.SharpArch.NHibernate;

namespace BddTraining.UnitSpecs.Persistence
{
    [TestFixture]
    public class ProductRepositorySpec : RepositorySpec
    {
        [Test]
        public void Should_CreateAProduct()
        {
            // Arrange
            var command = new CreateProductCmd("Digital TV", 1000m, true, ProductType.Books);
            var product = ProductFactory.Create(command);
            var productRepository = DependencyResolver.Resolve<IProductRepository>();

            // Act
            productRepository.SaveOrUpdate(product);
            SessionManager.CommitTrans();
            
            // Assert
            var dbProduct = productRepository.Get(product.ID);
            SessionManager.CommitTrans();

            dbProduct.ShouldNotBeNull();
            dbProduct.Name.ShouldBeEqualTo(product.Name);
            dbProduct.Price.ShouldBeEqualTo(product.Price);
            dbProduct.IsImported.ShouldBeEqualTo(product.IsImported); 
            dbProduct.Type.ShouldBeEqualTo(product.Type);
        }
    }
}
