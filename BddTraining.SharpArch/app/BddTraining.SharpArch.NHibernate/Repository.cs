using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using BddTraining.SharpArch.Domain.DataInterfaces;

namespace BddTraining.SharpArch.NHibernate
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected const string ConnectionStringFormat = "Data Source={0};Initial Catalog={1};User ID={2};Password={3};";

        public abstract ConnectionInfo ConnectionInfo { get; }

        protected virtual ISession Session
        {
            get { return SessionManager.GetSession(ConnectionInfo); }
        }

        public virtual T Get(Guid id) {
            return Session.Get<T>(id);
        }

        public virtual IQueryable<T> GetAll() {
            return Session.Query<T>();
        }

        public virtual T SaveOrUpdate(T entity) {
            Session.SaveOrUpdate(entity);
            return entity;
        }

        /// <summary>
        /// This deletes the object and commits the deletion immediately.  We don't want to delay deletion
        /// until a transaction commits, as it may throw a foreign key constraint exception which we could
        /// likely handle and inform the user about.  Accordingly, this tries to delete right away; if there
        /// is a foreign key constraint preventing the deletion, an exception will be thrown.
        /// </summary>
        public virtual void Delete(T entity) {
            Session.Delete(entity);
            Session.Flush();
        }
    }
}
