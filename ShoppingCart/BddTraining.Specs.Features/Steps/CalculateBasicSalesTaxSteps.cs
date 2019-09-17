using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;
using BddTraining.Specs.Features.Steps.Utility;
using BddTraining.Specs.Features.Utility;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BddTraining.Specs.Features.Steps
{
    [Binding]
    public class CalculateBasicSalesTaxSteps : FeatureBase
    {
        private Product _product;
        private decimal _tax;

        [Given(@"There is a product with a price of \$(.*) and Its type is (.*)")]
        public void GivenThereIsAProductWithAPriceOfAndItsTypeIsNormal(int price, ProductType type)
        {
            var command = new CreateProductCmd("", price, false, type);
            _product = ProductBuilder.Build(command);
        }

        [When(@"I calculate sales tax for the product")]
        public void WhenICalculateSalesTaxForTheProduct()
        {
            _tax = _product.CalcSalesTax();
        }

        [Then(@"The tax returned should be \$(.*)")]
        public void ThenTheTaxReturnedShouldBe(int tax)
        {
            _tax.ShouldBeEquivalentTo(tax);
        }
    }
}
