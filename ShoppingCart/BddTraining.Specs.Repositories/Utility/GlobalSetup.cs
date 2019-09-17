using BddTraining.Common;
using NUnit.Framework;
using BddTraining.SharpArch.NHibernate;

namespace BddTraining.Specs.Repositories
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
