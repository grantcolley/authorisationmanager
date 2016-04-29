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
    }
}
