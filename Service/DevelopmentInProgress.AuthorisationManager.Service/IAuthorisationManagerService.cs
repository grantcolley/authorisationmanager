namespace DevelopmentInProgress.AuthorisationManager.Service
{
    public interface IAuthorisationManagerService
    {
        string GetActivities();
        string GetRoles();
        string GetUserAuthorisations();
        string SaveActivity(string activity);
        string SaveRole(string role);
        string SaveUserAuthorisaion(string userAuthorisation);
        string DeleteActivity(string id);
        string DeleteRole(string id);
        string DeleteUserAuthorisation(string id);
        string RemoveActivityFromActivity(string activityId, string parentId);
        string RemoveActivityFromRole(string activityId, string roleId);
        string RemoveRoleFromRole(string roleId, string parentId);
        string RemoveRoleFromUser(string roleId, string userId);
        string AddActivityToRole(string roleId, string activityId);
        string AddActivityToActivity(string parentActivityId, string activityId);
        string AddRoleToUser(string userId, string roleId);
        string AddRoleToRole(string parentRoleId, string roleId);
    }
}
