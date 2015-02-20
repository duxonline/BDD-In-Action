using Castle.Windsor;

namespace BddTraining.Common
{
    public class DependencyResolver
    {
        private static readonly IWindsorContainer IocContainer = new WindsorContainer();

        public static void Initialize()
        {
            ComponentRegistrar.Register(IocContainer);
        }

        public static T Resolve<T>()
        {
            return IocContainer.Resolve<T>();
        }
    }
}
