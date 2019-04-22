using Microsoft.Extensions.DependencyInjection;
using Rebus.Config;
using Rebus.Retry.Simple;
using Rebus.ServiceProvider;
using _CompanyIdentifier_._BoundedContext_._ServiceName_.Infrastructure.Dependencies;
using _CompanyIdentifier_._BoundedContext_._ServiceName_.Worker.Service.Environment;

namespace _CompanyIdentifier_._BoundedContext_._ServiceName_.Worker.Service.Installers
{
    public class RebusInstaller : IDependencyInstaller
    {
        public void Install(IServiceCollection services)
        {
            services.AutoRegisterHandlersFromAssemblyOf<Program>();
            services.AddRebus(configure => configure
                .Logging(l => l.ColoredConsole())
                .Transport(t => t.UseAzureServiceBus(
                    connectionStringNameOrConnectionString: _CompanyIdentifier_Environment.ServiceBusConnectionString,
                    inputQueueAddress: Constants.ServiceBus.InputQueue))
                .Options(o => o.SimpleRetryStrategy(errorQueueAddress: Constants.ServiceBus.ErrorQueue, maxDeliveryAttempts: 5))
            );
        }
    }
}
