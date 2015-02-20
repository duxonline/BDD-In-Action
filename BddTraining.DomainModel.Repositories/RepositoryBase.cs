using System.Configuration;
using RosterLive.SharpArch.NHibernate;

namespace BddTraining.DomainModel.Repositories
{
    public class RepositoryBase<T> : Repository<T> where T : class
    {
        public override ConnectionInfo ConnectionInfo
        {
            get
            {
                return new ConnectionInfo
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings["BddTraining"].ConnectionString,
                    Priority = 0
                };
            }
        }
    }
}
