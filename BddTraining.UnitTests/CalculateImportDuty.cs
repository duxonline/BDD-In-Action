using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;
using BddTraining.DomainModel.Factories;
using FluentAssert;
using NUnit.Framework;

namespace BddTraining.UnitTests
{
    [TestFixture]
    public class CalculateImportDuty
    {
        [Test]
        public void ImportDuty_Should_BeCharged_ForImportedProducts()
        {
            // Arrange            
            const bool isImported = true;
            var command = new CreateProductCmd("Pricy Bread", 30, isImported, ProductType.Food);
            var product = ProductFactory.Create(command);

            // Act
            var importDuty = product.CalcImportDuty();

            // Assert
            importDuty.ShouldBeEqualTo(1.5m);
        }

        [Test]
        public void ImportDuty_Should_BeExempted_ForNonImportedProducts()
        {
            // Arrange
            const bool isImported = false;
            var command = new CreateProductCmd("Pricy Bread", 30, isImported, ProductType.Food);
            var product = ProductFactory.Create(command);

            // Act
            var importDuty = product.CalcImportDuty();

            // Assert
            importDuty.ShouldBeEqualTo(0);
        }
    }
}
