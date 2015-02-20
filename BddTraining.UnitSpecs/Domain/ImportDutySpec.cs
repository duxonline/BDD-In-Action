using BddTraining.DomainModel;
using FluentAssert;
using NUnit.Framework;

namespace BddTraining.UnitSpecs.Domain
{
    [TestFixture]
    public class ImportDutySpec
    {
        [Test]
        public void Should_BeCharged_ForImportedProducts()
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
        public void Should_BeExempted_ForNonImportedProducts()
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
