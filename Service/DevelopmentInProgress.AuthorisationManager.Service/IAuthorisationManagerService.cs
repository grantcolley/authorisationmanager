using System.ServiceModel;

namespace DevelopmentInProgress.AuthorisationManager.Service
{
    [ServiceContract]
    public interface IAuthorisationManagerService
    {
        [OperationContract]
        string GetAuthorisation();

        [OperationContract]
        string SaveActivity(string activity);

        [OperationContract]
        string SaveRole(string role);

        [OperationContract]
        string SaveUserAuthorisation(string userAuthorisation);

        [OperationContract]
        string DeleteActivity(string id);

        [OperationContract]
        string DeleteRole(string id);

        [OperationContract]
        string DeleteUserAuthorisation(string id);

        [OperationContract]
        string RemoveActivityFromActivity(string activityId, string parentId);

        [OperationContract]
        string RemoveActivityFromRole(string activityId, string roleId);

        [OperationContract]
        string RemoveRoleFromRole(string roleId, string parentId);

        [OperationContract]
        string RemoveRoleFromUser(string roleId, string userId);

        [OperationContract]
        string AddActivityToRole(string roleId, string activityId);

        [OperationContract]
        string AddActivityToActivity(string parentActivityId, string activityId);

        [OperationContract]
        string AddRoleToUser(string userId, string roleId);

        [OperationContract]
        string AddRoleToRole(string parentRoleId, string roleId);
    }
}
