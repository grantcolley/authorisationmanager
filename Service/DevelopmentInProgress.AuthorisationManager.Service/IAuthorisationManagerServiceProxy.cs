using System.Collections.Generic;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Service
{
    public interface IAuthorisationManagerServiceProxy
    {
        IList<Activity> GetActivities();
        IList<Role> GetRoles();
        IList<UserAuthorisation> GetUserAuthorisations();
        Activity SaveActivity(Activity activity);
        Role SaveRole(Role role);
        UserAuthorisation SaveUserAuthorisation(UserAuthorisation userAuthorisation);
    }
}