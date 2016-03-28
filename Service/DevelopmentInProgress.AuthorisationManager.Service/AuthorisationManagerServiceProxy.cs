using System;
using System.Collections.Generic;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Service
{
    public class AuthorisationManagerServiceProxy : IAuthorisationManagerServiceProxy
    {
        private readonly IAuthorisationManagerService authorisationManagerService;

        public AuthorisationManagerServiceProxy(IAuthorisationManagerService authorisationManagerService)
        {
            this.authorisationManagerService = authorisationManagerService;
        }

        public IList<Activity> GetActivities()
        {
            throw new NotImplementedException();
        }

        public IList<Role> GetRoles()
        {
            throw new NotImplementedException();
        }

        public IList<UserAuthorisation> GetUserAuthorisations()
        {
            throw new NotImplementedException();
        }
    }
}