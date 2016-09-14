using System.Collections.Generic;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Service
{
    public class Authorisation
    {
        public Authorisation()
        {
            Activities = new List<Activity>();
            Roles = new List<Role>();
            UserAuthorisations = new List<UserAuthorisation>();
        }

        public List<Activity> Activities { get; private set; }
        public List<Role> Roles { get; private set; }
        public List<UserAuthorisation> UserAuthorisations { get; private set; }
    }
}
