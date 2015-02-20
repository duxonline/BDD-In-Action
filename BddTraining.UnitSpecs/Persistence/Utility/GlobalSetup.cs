using BddTraining.Common;
using NUnit.Framework;
using RosterLive.SharpArch.NHibernate;

namespace BddTraining.UnitSpecs.Persistence
{
    [SetUpFixture]
    public class GlobalSetup
    {
        [SetUp]
        public void ShowSomeTrace()
        {
            SessionManager.HbmAssembly = "BddTraining.DomainModel.Repositories.dll";
            DependencyResolver.Initialize();
        }
    }
}
