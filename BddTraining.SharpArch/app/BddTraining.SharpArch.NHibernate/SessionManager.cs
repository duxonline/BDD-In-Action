using System;
using System.Collections.Generic;
using System.IO;
using FluentNHibernate.Cfg;
using NHibernate;
using System.Reflection;
using BddTraining.SharpArch.NHibernate.Conventions;

namespace BddTraining.SharpArch.NHibernate
{
    public static class SessionManager
    {
        private static readonly IDictionary<string, ISessionFactory> SessionFactories = new Dictionary<string, ISessionFactory>();
        private static readonly ISessionStorage SessionStorage = new SessionStorage();

        public static string HbmAssembly { get; set; }

        public static ISession GetSession(ConnectionInfo connectionInfo)
        {
            var connectionString = connectionInfo.ConnectionString;

            // NOTE: Session factory key needs to be unique and case insensitive
            var factoryKey = connectionInfo.ConnectionString.ToLower();

            // Check if there is an existing session
            var session = SessionStorage.GetSessionForKey(connectionInfo);

            if (session != null)
                return session;

            ISessionFactory sessionFactory = null;

            if (SessionFactories.ContainsKey(factoryKey))
                sessionFactory = SessionFactories[factoryKey];

            // Create the session factory if it doesn't exist yet
            if (sessionFactory == null)
            {
                sessionFactory = CreateSessionFactory(connectionString);
                SessionFactories.Add(factoryKey, sessionFactory);
            }

            // Create a new session
            session = sessionFactory.OpenSession();
            session.BeginTransaction();
            SessionStorage.SetSessionForKey(connectionInfo, session);

            return session;
        }

        public static void CommitTrans()
        {
            try
            {
                Commit();
            }
            catch (Exception)
            {
                RollbackTrans();
                throw;
            }
            finally
            {
                SessionStorage.RemoveSessions();
            }
        }

        public static void RollbackTrans()
        {
            try
            {
                foreach (var session in SessionStorage.GetAllSessions())
                {
                    if (session.Transaction != null && session.Transaction.IsActive)
                        session.Transaction.Rollback();
                }
            }
            finally 
            {
                foreach (var session in SessionStorage.GetAllSessions())
                {
                    if (session.IsOpen)
                        session.Close();

                    session.Dispose();
                }
            }
        }

        
        private static void Commit()
        {
            foreach (var session in SessionStorage.GetAllSessions())
            {
                if (session.Transaction != null && session.Transaction.IsActive)
                    session.Transaction.Commit();
            }
        }
        
        private static ISessionFactory CreateSessionFactory(string connectionString)
        {
            var assembly = Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, HbmAssembly));

            return Fluently
                .Configure()
                .Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                .Mappings(m =>
                              {
                                  m.HbmMappings.AddFromAssembly(assembly);
                                  m.FluentMappings.AddFromAssembly(assembly)
                                      .Conventions.Add<TableNameConvention>();
                              }
                )
                .BuildSessionFactory();
        }
    }
}
