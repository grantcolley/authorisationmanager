using System.ServiceModel;
using DevelopmentInProgress.DipCore.Service;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Server
{
    [ServiceContract]
    public interface IAuthorisationManagerServer
    {
        [OperationContract]
        ServiceResponse<Authorisation> GetAuthorisation();

        [OperationContract]
        ServiceResponse<Activity> SaveActivity(Activity activity);

        [OperationContract]
        ServiceResponse<Role> SaveRole(Role role);

        [OperationContract]
        ServiceResponse<UserAuthorisation> SaveUserAuthorisation(UserAuthorisation userAuthorisation);

        [OperationContract]
        ServiceResponse<bool> DeleteActivity(int id);

        [OperationContract]
        ServiceResponse<bool> DeleteRole(int id);

        [OperationContract]
        ServiceResponse<bool> DeleteUserAuthorisation(int id);

        [OperationContract]
        ServiceResponse<bool> RemoveActivityFromActivity(int activityId, int parentId);

        [OperationContract]
        ServiceResponse<bool> RemoveActivityFromRole(int activityId, int roleId);

        [OperationContract]
        ServiceResponse<bool> RemoveRoleFromRole(int roleId, int parentId);

        [OperationContract]
        ServiceResponse<bool> RemoveRoleFromUser(int roleId, int userId);

        [OperationContract]
        ServiceResponse<bool> AddActivityToRole(int roleId, int activityId);

        [OperationContract]
        ServiceResponse<bool> AddActivityToActivity(int parentActivityId, int activityId);

        [OperationContract]
        ServiceResponse<bool> AddRoleToUser(int userId, int roleId);

        [OperationContract]
        ServiceResponse<bool> AddRoleToRole(int parentRoleId, int roleId);
    }
}
