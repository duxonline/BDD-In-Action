using BddTraining.Common;
using NUnit.Framework;

namespace BddTraining.RepositoryTests
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
