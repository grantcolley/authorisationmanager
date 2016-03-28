using System;
using System.Collections.Generic;
using DevelopmentInProgress.AuthorisationManager.Service;

namespace DevelopmentInProgress.AuthorisationManager.WPF.Model
{
    public class ServiceManager
    {
        private readonly IAuthorisationManagerServiceProxy authorisationManagerService;

        public ServiceManager(IAuthorisationManagerServiceProxy authorisationManagerService)
        {
            this.authorisationManagerService = authorisationManagerService;
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
