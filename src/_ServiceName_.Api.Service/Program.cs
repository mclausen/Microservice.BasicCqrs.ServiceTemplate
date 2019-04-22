using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using _CompanyIdentifier_._BoundedContext_._ServiceName_.Infrastructure.Environment;
using _CompanyIdentifier_._BoundedContext_._ServiceName_.Infrastructure.Logging;

namespace _CompanyIdentifier_._BoundedContext_._ServiceName_.Api.Service
{
    public class Program
    {
        

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .Enrich.WithEnvironmentDetails(serviceName: Infrastructure.Constants.Service.ServiceName, environmentName: _CompanyIdentifier_Environment.EnvironmentName)
                .WriteTo.ApplicationInsights(instrumentationKey: UmbracoEnvironment.AiInstrumentationKey, telemetryConverter: TelemetryConverter.Traces)
                .CreateLogger();

            CreateWebHostBuilder(args)
                .Build()
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseShutdownTimeout(TimeSpan.FromSeconds(2));
    }
}
