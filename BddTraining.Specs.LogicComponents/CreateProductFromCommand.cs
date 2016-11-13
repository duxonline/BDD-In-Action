using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;
using BddTraining.DomainModel.Factories;
using FluentAssert;
using NUnit.Framework;

namespace BddTraining.Specs.LogicComponents
{
    [TestFixture]
    public class CreateProductFromCommand
    {
        [Test]
        public void ProuductAndCommand_Should_Match()
        {
            // Arrange
            var cmd = new CreateProductCmd("BDD in Action", 1000m, true, ProductType.Books);

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
