using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Service
{
    public interface IAuthorisationManagerServiceProxy
    {
        Authorisation GetAuthorisation();
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
        void AddActivityToRole(int roleId, int activityId);
        void AddActivityToActivity(int parentActivityId, int activityId);
        void AddRoleToUser(int userId, int roleId);
        void AddRoleToRole(int parentRoleId, int roleId);
    }
}