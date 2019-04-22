using System;
using Serilog.Core;
using Serilog.Events;

namespace _CompanyIdentifier_._BoundedContext_._ServiceName_.Infrastructure.Logging.Enrichers
{
    public class EnvironmentStampEnricher : ILogEventEnricher
    {
        private readonly string _environmentName;
        private const string EnvironmentStampPropertyName = "EnvironmentName";
        private LogEventProperty _cachedEventProperty;

        public EnvironmentStampEnricher(string environmentName)
        {
            if(string.IsNullOrEmpty(environmentName)) throw new ArgumentNullException(nameof(environmentName));
            _environmentName = environmentName;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            _cachedEventProperty = _cachedEventProperty ?? propertyFactory.CreateProperty(EnvironmentStampPropertyName, _environmentName);
            logEvent.AddPropertyIfAbsent(_cachedEventProperty);
        }
    }
}