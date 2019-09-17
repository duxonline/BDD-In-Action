using BddTraining.DomainModel;
using BddTraining.DomainModel.Commands;
using BddTraining.Specs.Features.Steps.Utility;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BddTraining.Specs.Features.Steps
{
    [Binding]
    public class CalculateImportDutySteps
    {
        private Product _product;
        private decimal _importDuty;

        [Given(@"I have the following product: ""(.*)"", \$(.*), (.*)")]
        public void GivenIHaveTheFollowingProduct(string name, decimal price, bool isImported)
        {
            var command = new CreateProductCmd(name, price, isImported, ProductType.Normal);
            _product = ProductBuilder.Build(command);
        }

        [When(@"I calculate Import duty for the product")]
        public void WhenICalculateImportDutyForTheProduct()
        {
            _importDuty = _product.CalcImportDuty();
        }

        [Then(@"The import duty returned should be equal to \$(.*)")]
        public void ThenTheImportDutyReturnedShouldBeEqualTo(decimal importDuty)
        {
            _importDuty.ShouldBeEquivalentTo(importDuty);
        }
    }
}
