using BddTraining.Common;
using RosterLive.SharpArch.NHibernate;
using TechTalk.SpecFlow;

namespace BddTraining.Features.Utility
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
