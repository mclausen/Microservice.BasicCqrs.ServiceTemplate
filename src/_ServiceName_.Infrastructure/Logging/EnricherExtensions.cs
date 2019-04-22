using System;
using Serilog;
using Serilog.Configuration;
using _CompanyIdentifier_._BoundedContext_._ServiceName_.Infrastructure.Logging.Enrichers;

namespace _CompanyIdentifier_._BoundedContext_._ServiceName_.Infrastructure.Logging
{
    public static class EnricherExtensions
    {
        public static LoggerConfiguration WithEnvironmentDetails(this LoggerEnrichmentConfiguration self, string serviceName, string environmentName)
        {
            if (self == null) throw new ArgumentNullException(nameof(self));
            if(string.IsNullOrEmpty(serviceName)) throw new ArgumentNullException(serviceName);
            if(string.IsNullOrEmpty(environmentName)) throw new ArgumentNullException(environmentName);

            return self.With(
                new ServiceNameEnricher(serviceName),
                new EnvironmentStampEnricher(environmentName)
            );
        }
    }
}
