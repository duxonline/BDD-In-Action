using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Web;
using NHibernate;

namespace BddTraining.SharpArch.NHibernate
{
    public class SessionStorage : ISessionStorage
    {
        private const string SessionStorageKey = "SessionStorageKey";

        public ISession GetSessionForKey(ConnectionInfo connectionInfo)
        {
            var dictionary = GetSessionStorage();

            ISession session;

            return !dictionary.TryGetValue(connectionInfo, out session) ? null : session;
        }

        public void SetSessionForKey(ConnectionInfo connectionInfo, ISession session)
        {
            var dictionary = GetSessionStorage();
            dictionary[connectionInfo] = session;
        }

        public IEnumerable<ISession> GetAllSessions()
        {
            var dictionary = GetSessionStorage();
            return dictionary.Values;
        }

        public void RemoveSessions()
        {
            if (IsInWebContext())
                HttpContext.Current.Items.Remove(SessionStorageKey);
            else
                CallContext.FreeNamedDataSlot(SessionStorageKey);
        }

        private static SortedDictionary<ConnectionInfo, ISession> GetSessionStorage()
        {
            var dictionary = GetStorage(SessionStorageKey);

            if (dictionary == null)
            {
                dictionary = new SortedDictionary<ConnectionInfo, ISession>();
                SetStorage(SessionStorageKey, dictionary);
            }

            return dictionary;
        }

        private static void SetStorage(string key, SortedDictionary<ConnectionInfo, ISession> sessionDictionary)
        {
            if (IsInWebContext())
                HttpContext.Current.Items[key] = sessionDictionary;
            else
                CallContext.SetData(key, sessionDictionary);
        }

        private static SortedDictionary<ConnectionInfo, ISession> GetStorage(string key)
        {
            return (SortedDictionary<ConnectionInfo, ISession>)
                   (IsInWebContext() ? HttpContext.Current.Items[key] : CallContext.GetData(key));
        }

        private static bool IsInWebContext()
        {
            return (HttpContext.Current != null);
        }
    }
}
