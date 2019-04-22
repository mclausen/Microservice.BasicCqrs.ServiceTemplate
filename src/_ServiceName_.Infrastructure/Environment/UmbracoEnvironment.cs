namespace _CompanyIdentifier_._BoundedContext_._ServiceName_.Infrastructure.Environment
{
    public partial class _CompanyIdentifier_Environment
    {
        public static string EnvironmentName
        {
            get
            {
                var variable = System.Environment.GetEnvironmentVariable(Constants.EnvironmentVariables.EnvironmentName);
                if(string.IsNullOrEmpty(variable))
                    throw new EnvironmentConfigurationException($"Environment variable '{Constants.EnvironmentVariables.EnvironmentName}' was not defined");

                return variable;
            }
        }

        public static string AiInstrumentationKey
        {
            get
            {
                var variable = System.Environment.GetEnvironmentVariable(Constants.EnvironmentVariables.AiInstrumentationKey);
                if(string.IsNullOrEmpty(variable))
                    throw new EnvironmentConfigurationException($"Environment variable '{Constants.EnvironmentVariables.AiInstrumentationKey}' was not defined");

                return variable;
            }
        }

        public static string IsRunningDocker
        {
            get
            {
                var variable = System.Environment.GetEnvironmentVariable(Constants.EnvironmentVariables.DockerMarkerVariable);
                if(string.IsNullOrEmpty(variable))
                    throw new EnvironmentConfigurationException($"Environment variable '{Constants.EnvironmentVariables.DockerMarkerVariable}' was not defined");

                return variable;
            }
        }
    }
}
