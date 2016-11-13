using BddTraining.Common;
using NUnit.Framework;
using RosterLive.SharpArch.NHibernate;

namespace BddTraining.RepositoryTests
{
    [SetUpFixture]
    public class GlobalSetup
    {
        [OneTimeSetUp]
        public void ShowSomeTrace()
        {
            SessionManager.HbmAssembly = "BddTraining.Repositories.dll";
            DependencyResolver.Initialize();
        }
    }
}
