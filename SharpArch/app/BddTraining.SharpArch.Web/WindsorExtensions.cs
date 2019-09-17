using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace BddTraining.SharpArch.Web
{
    public static class WindsorExtensions
    {
        public static IWindsorContainer RegisterControllers(this IWindsorContainer container, Func<Type, bool> isControllerType, params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                RegisterControllers(container, isControllerType, assembly.GetExportedTypes());
            }

            return container;
        }

        public static BasedOnDescriptor InterfaceNamespace(this ServiceDescriptor descriptor, string interfaceNamespace)
        {
            return descriptor.Select(delegate(Type type, Type[] baseType)
            {
                var interfaces = type.GetInterfaces()
                    .Where(t => !t.IsGenericType
                                && (t.Namespace != null && t.Namespace.StartsWith(interfaceNamespace)));

                var enumerable = interfaces as IList<Type> ?? interfaces.ToList();
                if (enumerable.Any())
                {
                    return new[] { enumerable.ElementAt(0) };
                }

                return null;
            });
        }

        private static void RegisterControllers(IWindsorContainer container, Func<Type, bool> isControllerType, params Type[] controllerTypes)
        {
            foreach (var type in controllerTypes)
            {
                if (isControllerType(type))
                {
                    container.Register(Component.For(type).LifeStyle.Is(LifestyleType.Transient));
                }
            }

        }
    }
}
