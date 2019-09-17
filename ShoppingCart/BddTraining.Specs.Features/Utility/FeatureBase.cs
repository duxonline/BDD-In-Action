using BddTraining.Common;
using TechTalk.SpecFlow;

namespace BddTraining.Specs.Features.Utility
{
    public class FeatureBase
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            DatabaseCleaner.Clean();
        }
    }
}
