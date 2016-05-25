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
        void DeleteActivity(int id);
        void DeleteRole(int id);
        void DeleteUserAuthorisation(int id);
        void RemoveActivityFromActivity(int activityId, int parentId);
        void RemoveActivityFromRole(int activityId, int roleId);
        void RemoveRoleFromRole(int roleId, int parentId);
        void RemoveRoleFromUser(int roleId, int userId);
    }
}