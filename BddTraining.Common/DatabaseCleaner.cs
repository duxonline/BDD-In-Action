using System.Configuration;
using Respawn;

namespace BddTraining.Common
{
    public class DatabaseCleaner
    {
        public static void Clean()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BddTraining"].ConnectionString;
            var checkpoint = new Checkpoint();
            checkpoint.Reset(connectionString);
        }
    }
}
