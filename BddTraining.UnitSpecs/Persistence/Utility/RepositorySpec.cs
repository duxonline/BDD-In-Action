using BddTraining.Common;
using NUnit.Framework;

namespace BddTraining.UnitSpecs.Persistence.Utility
{
    public class RepositorySpec
    {
        [SetUp]
        public void CleanDatabase()
        {
            DatabaseCleaner.Clean();
        }
    }
}
