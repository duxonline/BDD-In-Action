using BddTraining.Common;
using NUnit.Framework;

namespace BddTraining.Specs.Repositories
{
    public class RepositorySpec
    {
        [OneTimeSetUp]
        public void CleanDatabase()
        {
            DatabaseCleaner.Clean();
        }
    }
}
