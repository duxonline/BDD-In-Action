using BddTraining.Common;
using BddTraining.SharpArch.NHibernate;
using TechTalk.SpecFlow;

namespace BddTraining.Specs.Features.Utility
{
    [Binding]
    public class BeforeAfterTestRun
    {
        [BeforeTestRun]
        public static void Before()
        {
            SessionManager.HbmAssembly = "BddTraining.Repositories.dll";
            DependencyResolver.Initialize();
        }
    }
}
