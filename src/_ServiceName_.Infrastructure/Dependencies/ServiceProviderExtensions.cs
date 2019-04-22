using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace _CompanyIdentifier_._BoundedContext_._ServiceName_.Infrastructure.Dependencies
{
    public static class ServiceProviderExtensions
    {
        public static void RegisterFromAssembly<TAssemblyType>(this IServiceCollection self)
        {
            if(self == null)
                throw new ArgumentNullException(nameof(self));

            var assemblyToRegister = GetAssembly<TAssemblyType>();

            RegisterAssembly(self, assemblyToRegister);
        }


        private static Assembly GetAssembly<THandler>()
        {
            return typeof(THandler).Assembly;
        }

       private static void RegisterAssembly(IServiceCollection services, Assembly assemblyToRegister)
        {
            var typesToAutoRegister = assemblyToRegister.GetTypes()
                .Where(IsDependencyInstaller)
                .ToList();
                
            foreach (var type in typesToAutoRegister)
            {
                var instance = Activator.CreateInstance(type);
                var typedInstance = instance as IDependencyInstaller;
                typedInstance?.Install(services);
            }
        }

        private static bool IsDependencyInstaller(Type type)
        {
            return !type.IsInterface 
                   && !type.IsAbstract
                   && typeof(IDependencyInstaller).IsAssignableFrom(type);
        }
    }
}
