using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using RosterLive.SharpArch.Domain.DataInterfaces;
using RosterLive.SharpArch.NHibernate;
using RosterLive.SharpArch.Web;

namespace BddTraining.Common
{
    public class ComponentRegistrar
    {
        public static void Register(IWindsorContainer container)
        {
            AddGenericRepositories(container);
            AddCustomRepositories(container);
            AddRequestHandlers(container);
        }

        public static void AddGenericRepositories(IWindsorContainer container)
        {
            container.Register(
                Component.For(typeof(IRepository<>))
                    .ImplementedBy(typeof(Repository<>))
                    .Named("repository"));
        }

        public static void AddCustomRepositories(IWindsorContainer container)
        {
            container.Register(
                Classes.FromAssembly(Assembly.Load("BddTraining.Repositories"))
                    .Pick()
                .WithService.InterfaceNamespace("BddTraining.DomainModel.RepositoryInterfaces"));
        }

        public static void AddRequestHandlers(IWindsorContainer container)
        {
            container.Register(
                Classes.FromAssembly(Assembly.Load("BddTraining.RequestHandlers"))
                    .Pick()
                .WithService.InterfaceNamespace("BddTraining.RequestHandlers.Interfaces"));
        }
    }
}
