using System;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rebus.Config;
using Serilog;
using _CompanyIdentifier_._BoundedContext_._ServiceName_.Infrastructure.Dependencies;
using _CompanyIdentifier_._BoundedContext_._ServiceName_.Infrastructure.Environment;
using _CompanyIdentifier_._BoundedContext_._ServiceName_.Infrastructure.Logging;

namespace _CompanyIdentifier_._BoundedContext_._ServiceName_.Worker.Service
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .Enrich.WithRebusCorrelationId(Infrastructure.Constants.Logging.CorrelationIdPropertyName)
                .Enrich.WithEnvironmentDetails(serviceName: Infrastructure.Constants.Service.ServiceName, environmentName: _CompanyIdentifier_Environment.EnvironmentName)
                .WriteTo.ApplicationInsights(instrumentationKey: _CompanyIdentifier_Environment.AiInstrumentationKey, telemetryConverter: TelemetryConverter.Traces)
                .CreateLogger();

            var builder = new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddEnvironmentVariables();
                })
                .ConfigureServices((hostingContext, services) =>
                {
                    services.RegisterFromAssembly<Program>();
                    services.AddSingleton<IHostedService, _ServiceName_>();
                })
                .ConfigureHostConfiguration(config => { });

            await builder.RunConsoleAsync();
        }
    }
}
