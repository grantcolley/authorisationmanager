using System.Threading.Tasks;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Service
{
    public interface IAuthorisationManagerServiceProxy
    {
        Task<Authorisation> GetAuthorisation();
        Task<UserAuthorisation> GetUserAuthorisation(string userName);
        Task<Activity> SaveActivity(Activity activity);
        Task<Role> SaveRole(Role role);
        Task<UserAuthorisation> SaveUserAuthorisation(UserAuthorisation userAuthorisation);
        Task<bool> DeleteActivity(int id);
        Task<bool> DeleteRole(int id);
        Task<bool> DeleteUserAuthorisation(int id);
        Task<bool> RemoveActivityFromActivity(int activityId, int parentId);
        Task<bool> RemoveActivityFromRole(int activityId, int roleId);
        Task<bool> RemoveRoleFromRole(int roleId, int parentId);
        Task<bool> RemoveRoleFromUser(int roleId, int userId);
        Task<bool> AddActivityToRole(int roleId, int activityId);
        Task<bool> AddActivityToActivity(int parentActivityId, int activityId);
        Task<bool> AddRoleToUser(int userId, int roleId);
        Task<bool> AddRoleToRole(int parentRoleId, int roleId);
    }
}