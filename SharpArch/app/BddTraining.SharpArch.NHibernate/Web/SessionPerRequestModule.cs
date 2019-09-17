using System;
using System.Web;

namespace BddTraining.SharpArch.NHibernate.Web
{
    /// <summary>
    /// </summary>
    public class SessionPerRequestModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.EndRequest += ContextEndRequest;
        }

        private static void ContextEndRequest(object sender, EventArgs e)
        {
            SessionManager.CommitTrans();
        }

        public void Dispose() { }
    }
}
