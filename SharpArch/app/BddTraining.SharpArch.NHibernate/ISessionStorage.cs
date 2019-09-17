using NHibernate;
using System.Collections.Generic;

namespace BddTraining.SharpArch.NHibernate
{
    public interface ISessionStorage
    {
        ISession GetSessionForKey(ConnectionInfo connectionInfo);
        void SetSessionForKey(ConnectionInfo connectionInfo, ISession session);
        IEnumerable<ISession> GetAllSessions();
        void RemoveSessions();
    }
}
