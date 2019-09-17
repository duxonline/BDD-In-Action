using System;

namespace BddTraining.SharpArch.NHibernate
{
    public class NHibernateInitializer
    {
        private static readonly object SyncLock = new object();
        private static NHibernateInitializer _instance;

        protected NHibernateInitializer() { }

        private bool _nHibernateSessionIsLoaded;

        public static NHibernateInitializer Instance()
        {
            if (_instance == null)
            {
                lock (SyncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new NHibernateInitializer();
                    }
                }
            }

            return _instance;
        }
 
        public void InitializeOnce(Action initMethod)
        {
            lock (SyncLock)
            {
                if (!_nHibernateSessionIsLoaded)
                {
                    initMethod();
                    _nHibernateSessionIsLoaded = true;
                }
            }
        }
    }
}
