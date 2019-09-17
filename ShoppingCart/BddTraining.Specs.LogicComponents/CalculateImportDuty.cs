using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;
using BddTraining.DomainModel.Factories;
using FluentAssert;
using NUnit.Framework;

namespace BddTraining.Specs.Components
{
    [TestFixture]
    public class CalculateImportDuty
    {
        [Test]
        public void import_duty_should_be_charged_for_imported_products()
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
        public void impor_duty_should_be_exempted_for_non_imported_products()
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
