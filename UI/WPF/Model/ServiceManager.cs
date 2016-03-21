using System;
using System.Collections.Generic;
using DevelopmentInProgress.AuthorisationManager.Model;

namespace DevelopmentInProgress.AuthorisationManager.WPF.Model
{
    public class ServiceManager
    {
        private readonly IServiceFactory serviceFactory;

        public ServiceManager(IServiceFactory serviceFactory)
        {
            this.serviceFactory = serviceFactory;
        }

        public List<ActivityNode> GetActivityNodes()
        {
            throw new NotImplementedException();
        }

        public List<RoleNode> GetRolesNodes()
        {
            throw new NotImplementedException();
        }

        public List<UserNode> GetUserNodes()
        {
            throw new NotImplementedException();
        }
    }
}
