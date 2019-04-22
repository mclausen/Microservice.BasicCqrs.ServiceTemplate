using System;

namespace _CompanyIdentifier_._BoundedContext_._ServiceName_.Infrastructure.Environment
{
    [Serializable]
    public class EnvironmentConfigurationException : Exception
    {
        public EnvironmentConfigurationException(string message)
            :base(message) { }
    }
}
