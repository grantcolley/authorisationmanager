using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;

namespace DevelopmentInProgress.AuthorisationManager.WCFServiceHost
{
    public class UnityInstanceProvider : IInstanceProvider
    {
        private readonly IUnityContainer container;
        private readonly Type contractType;

        public UnityInstanceProvider(IUnityContainer container, Type contractType)
        {
            this.container = container;
            this.contractType = contractType;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return container.Resolve(contractType);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            container.Teardown(instance);
        }
    }
}
