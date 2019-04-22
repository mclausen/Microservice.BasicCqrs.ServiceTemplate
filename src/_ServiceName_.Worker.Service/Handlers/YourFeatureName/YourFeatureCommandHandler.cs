using System;
using System.Threading.Tasks;
using Rebus.Handlers;
using _CompanyIdentifier_._BoundedContext_._ServiceName_.Messages.External.Commands;

namespace _CompanyIdentifier_._BoundedContext_._ServiceName_.Worker.Service.Handlers.YourFeatureName
{
    public class YourFeatureCommandHandler : IHandleMessages<YourFeatureCommand>
    {
        public Task Handle(YourFeatureCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
