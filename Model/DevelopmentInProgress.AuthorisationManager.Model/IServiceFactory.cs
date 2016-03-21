using System.Collections.Generic;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Model
{
    public interface IServiceFactory
    {
        IList<Activity> GetActivities();
        IList<Role> GetRoles();
        IList<UserAuthorisation> GetUserAuthorisations();
    }
}
