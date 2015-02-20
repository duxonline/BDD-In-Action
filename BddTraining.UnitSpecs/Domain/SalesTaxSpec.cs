using BddTraining.DomainModel;
using FluentAssert;
using NUnit.Framework;

namespace BddTraining.UnitSpecs.Domain
{
    [TestFixture]
    public class SalesTaxSpec
    {
        [Test]
        public void Should_BeCharged_ForNormlProducts()
        {
            var command = new CreateProductCmd("TV", 100m, false, ProductType.Normal);
            var normalProduct = ProductFactory.Create(command);

            var salesTax = normalProduct.CalcSalesTax();

            salesTax.ShouldBeEqualTo(10m);
        }

        [Test]
        public void Should_BeExempted_ForBooks()
        {
            var command = new CreateProductCmd("Book", 100m, false, ProductType.Books);
            var book = ProductFactory.Create(command);

            var salesTax = book.CalcSalesTax();

            salesTax.ShouldBeEqualTo(0);
        }

        [Test]
        public void Should_BeExempted_ForFood()
        {
            var command = new CreateProductCmd("Food", 100m, false, ProductType.Food);
            var food = ProductFactory.Create(command);

            var salesTax = food.CalcSalesTax();

            salesTax.ShouldBeEqualTo(0);
        }

        [Test]
        public void Should_BeExempted_ForMedicalProducts()
        {
            var command = new CreateProductCmd("Medical Product", 100m, false, ProductType.Medical);
            var medicalProduct = ProductFactory.Create(command);

            var salesTax = medicalProduct.CalcSalesTax();

            salesTax.ShouldBeEqualTo(0);
        }
    }
}
