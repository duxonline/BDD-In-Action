using BddTraining.Common;
using NUnit.Framework;
using Respawn;

namespace BddTraining.UnitSpecs.Persistence
{
    public class RepositorySpec
    {
        [SetUp]
        public void CleanDatabase()
        {
             DatabaseCleaner.Clean();

            //var checkpoint = new Checkpoint()
            //{
            //    TablesToIgnore = new string[] { },
            //    SchemasToExclude = new string[] { }
            //};
            //checkpoint.Reset("BddTraining");
        }
    }
}
