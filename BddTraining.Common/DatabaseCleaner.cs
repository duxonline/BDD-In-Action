using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace BddTraining.Common
{
    public class DatabaseCleaner
    {
        public static void Clean()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BddTraining"].ConnectionString;
            var fileInfo = new FileInfo(@"D:\GitHub\BddTraining\BddTraining.Common\CleanDatabase.sql");
            var script = fileInfo.OpenText().ReadToEnd();

            var connection = new SqlConnection(connectionString);
            var server = new Server(new ServerConnection(connection));
            server.ConnectionContext.ExecuteNonQuery(script);
        }
    }
}
