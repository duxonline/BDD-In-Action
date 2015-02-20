using BddTraining.Common;
using Respawn;
using TechTalk.SpecFlow;

namespace BddTraining.Features.Utility
{
    public class FeatureBase
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            DatabaseCleaner.Clean();

            //var checkpoint = new Checkpoint();
            //checkpoint.Reset("BddTraining");
        }
    }
}
