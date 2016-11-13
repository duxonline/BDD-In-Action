using BddTraining.Common;
using TechTalk.SpecFlow;

namespace BddTraining.Features.Utility
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
