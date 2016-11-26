using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;

namespace DevelopmentInProgress.AuthorisationManager.WCFServiceHost
{
    public class UnityServiceBehavior : IServiceBehavior
    {
        private readonly IUnityContainer container;

        public UnityServiceBehavior(IUnityContainer container)
        {
            this.container = container;
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase,
            Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                {
                    if (endpointDispatcher.ContractName != "IMetadataExchange")
                    {
                        string contractName = endpointDispatcher.ContractName;
                        ServiceEndpoint serviceEndpoint =
                            serviceDescription.Endpoints.FirstOrDefault(ep => ep.Contract.Name == contractName);
                        if (serviceEndpoint != null)
                        {
                            endpointDispatcher.DispatchRuntime.InstanceProvider = new UnityInstanceProvider(container,
                                serviceEndpoint.Contract.ContractType);
                        }
                    }
                }
            }
        }
    }
}
