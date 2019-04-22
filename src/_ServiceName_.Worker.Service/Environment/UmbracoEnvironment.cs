using _CompanyIdentifier_._BoundedContext_._ServiceName_.Infrastructure.Environment;

namespace _CompanyIdentifier_._BoundedContext_._ServiceName_.Worker.Service.Environment
{
    public partial class _CompanyIdentifier_Environment
    {
        public static string ServiceBusConnectionString
        {
            get
            {
                var variable = System.Environment.GetEnvironmentVariable(Constants.EnvironmentVariables.ServiceBusConnectionString);
                if(string.IsNullOrEmpty(variable))
                    throw new EnvironmentConfigurationException($"Environment variable '{Constants.EnvironmentVariables.ServiceBusConnectionString}' was not defined");

                return variable;
            }
        }
    }
}
