using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Hosting;
using Rebus.Bus;
using Rebus.ServiceProvider;

namespace _CompanyIdentifier_._BoundedContext_._ServiceName_.Worker.Service
{
    public class _ServiceName_ : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Events that this worker subscribes to
        /// </summary>
        private static readonly Type[] EventSubscriptionTypes = {
            // typeof(MyFeatureHasHappenedEvents)
        };

        public _ServiceName_(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            StartRebus();
            return Task.CompletedTask;
        }

        private void StartRebus()
        {
            _serviceProvider.UseRebus(async bus =>
            {
                await ConfigureRebusSubscriptions(bus);
            });
        }

        private static async Task ConfigureRebusSubscriptions(IBus bus)
        {
            foreach (var subscriptionType in EventSubscriptionTypes)
            {
                await bus.Subscribe(subscriptionType);
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await FlushApplicationInsights();
        }

        private static async Task FlushApplicationInsights()
        {
            TelemetryConfiguration.Active.TelemetryChannel.Flush();
            await Task.Delay(2000);
        }
    }
}
