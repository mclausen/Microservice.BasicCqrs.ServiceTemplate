using System;
using Serilog.Core;
using Serilog.Events;

namespace UmbracoCloud._BoundedContext_._ServiceName_.Infrastructure.Logging.Enrichers
{
    public class ServiceNameEnricher : ILogEventEnricher
    {
        private readonly string _serviceName;
        private const string ServiceNamePropertyName = "ServiceName";
        private LogEventProperty _cachedEventProperty;

        public ServiceNameEnricher(string serviceName)
        {
            if(string.IsNullOrEmpty(serviceName)) throw new ArgumentNullException(nameof(serviceName));
            _serviceName = serviceName;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            _cachedEventProperty = _cachedEventProperty ?? propertyFactory.CreateProperty(ServiceNamePropertyName, _serviceName);
            logEvent.AddPropertyIfAbsent(_cachedEventProperty);
        }
    }
}