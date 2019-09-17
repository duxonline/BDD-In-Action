using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;
using BddTraining.DomainModel.Factories;
using FluentAssert;
using NUnit.Framework;

namespace BddTraining.Specs.Components
{
    [TestFixture]
    public class CreateProduct
    {
        [Test]
        public void prouduct_and_command_should_match()
        {
            // Arrange
            var cmd = new CreateProductCmd("BDD in Action", 1000m, true, ProductType.Book);

            // Act
            var product = ProductFactory.Create(cmd);

            // Assert
            product.Name.ShouldBeEqualTo(cmd.Name);
            product.Price.ShouldBeEqualTo(cmd.Price);
            product.IsImported.ShouldBeEqualTo(cmd.IsImported);
            product.Type.ShouldBeEqualTo(cmd.Type);
        }
    }
}
