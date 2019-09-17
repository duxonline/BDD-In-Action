using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;
using BddTraining.DomainModel.Factories;
using FluentAssert;
using NUnit.Framework;

namespace BddTraining.Specs.Components
{
    [TestFixture]
    public class CalculateSalesTax
    {
        [Test]
        public void sales_tax_Should_be_charged_for_norml_products()
        {
            var command = new CreateProductCmd("TV", 100m, false, ProductType.Normal);
            var normalProduct = ProductFactory.Create(command);

            var salesTax = normalProduct.CalcSalesTax();

            salesTax.ShouldBeEqualTo(10m);
        }

        [Test]
        public void sales_tax_should_be_exempted_for_books()
        {
            var command = new CreateProductCmd("Book", 100m, false, ProductType.Book);
            var book = ProductFactory.Create(command);

            var salesTax = book.CalcSalesTax();

            salesTax.ShouldBeEqualTo(0);
        }

        [Test]
        public void sales_tax_should_be_charged_for_food()
        {
            var command = new CreateProductCmd("Food", 100m, false, ProductType.Food);
            var food = ProductFactory.Create(command);

            var salesTax = food.CalcSalesTax();

            salesTax.ShouldBeEqualTo(20);
        }

        [Test]
        public void sales_tax_should_be_exempted_for_medical_products()
        {
            var command = new CreateProductCmd("Medical Product", 100m, false, ProductType.Medical);
            var medicalProduct = ProductFactory.Create(command);

            var salesTax = medicalProduct.CalcSalesTax();

            salesTax.ShouldBeEqualTo(0);
        }
    }
}
