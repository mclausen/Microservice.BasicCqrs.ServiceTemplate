namespace _CompanyIdentifier_._BoundedContext_._ServiceName_.Worker.Service
{
    public static class Constants
    {
        public static class ServiceBus
        {
            public static string InputQueue => $"{Infrastructure.Constants.Service.BoundedContext.ToLower()}-{Infrastructure.Constants.Service.ServiceName.ToLower()}-input";
            public static string ErrorQueue => $"{Infrastructure.Constants.Service.BoundedContext.ToLower()}-{Infrastructure.Constants.Service.ServiceName.ToLower()}-error";
        }

        public static class EnvironmentVariables
        {
            public static string ServiceBusConnectionString = "ServiceBusConnectionString";
        }
    }
}