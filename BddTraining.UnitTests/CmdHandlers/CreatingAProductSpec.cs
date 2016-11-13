using BddTraining.CmdHandlers;
using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;
using BddTraining.DomainModel.Repositories;
using BddTraining.RequestHandlers;
using FluentAssert;
using Moq;
using NUnit.Framework;

namespace BddTraining.UnitTests.CmdHandlers
{
    [TestFixture]
    public class CreatingAProductSpec
    {
        [Test]
        public void Should_CreateAProduct()
        {
            // Arrange
            var cmd = new CreateProductCmd("BDD in Action", 1000m, true, ProductType.Books);
            var repository = new Mock<IProductRepository>();
            var cmdHandler = new CreateProductCmdHandler(repository.Object);

            // Act
            var product = cmdHandler.Handle(cmd);

            // Assert
            product.Name.ShouldBeEqualTo(cmd.Name);
            product.Price.ShouldBeEqualTo(cmd.Price);
            product.IsImported.ShouldBeEqualTo(cmd.IsImported);
            product.Type.ShouldBeEqualTo(cmd.Type);
        }
    }
}
