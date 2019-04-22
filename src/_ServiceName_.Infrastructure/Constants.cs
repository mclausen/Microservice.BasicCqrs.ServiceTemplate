namespace _CompanyIdentifier_._BoundedContext_._ServiceName_.Infrastructure
{
    public static class Constants
    {
        public static class Service
        {
            public const string ServiceName = "_ServiceName_";
            public const string BoundedContext = "_BoundedContext_";
        }

        public static class Logging
        {
            /// <summary>
            /// This is the Operation Id is carried on to Application insights by the Serilog.Sinks.ApplicationInsight packages
            /// </summary>
            public static string CorrelationIdPropertyName = "operationId";
        }

        public static class EnvironmentVariables
        {
            public static string EnvironmentName = "ASPNETCORE_ENVIRONMENT";
            public static string AiInstrumentationKey = "AiInstrumentationKey";
            public static string DockerMarkerVariable = "RunningDocker";
        }
    }
}
