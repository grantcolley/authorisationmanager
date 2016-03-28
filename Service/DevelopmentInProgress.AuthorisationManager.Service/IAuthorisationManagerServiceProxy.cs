using System.Collections.Generic;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Service
{
    public interface IAuthorisationManagerServiceProxy
    {
        IList<Activity> GetActivities();
        IList<Role> GetRoles();
        IList<UserAuthorisation> GetUserAuthorisations();
    }
}