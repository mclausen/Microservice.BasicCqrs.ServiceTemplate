using Microsoft.Extensions.DependencyInjection;

namespace _CompanyIdentifier_._BoundedContext_._ServiceName_.Infrastructure.Dependencies
{
    public interface IDependencyInstaller
    {
        void Install(IServiceCollection serviceCollection);
    }
}