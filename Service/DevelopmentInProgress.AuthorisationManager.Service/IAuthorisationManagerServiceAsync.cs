using System.ServiceModel;
using System.Threading.Tasks;

namespace DevelopmentInProgress.AuthorisationManager.Service
{
    [ServiceContract]
    public interface IAuthorisationManagerServiceAsync
    {
        [OperationContract]
        Task<string> GetAuthorisation();

        [OperationContract]
        Task<string> SaveActivity(string activity);

        [OperationContract]
        Task<string> SaveRole(string role);

        [OperationContract]
        Task<string> SaveUserAuthorisation(string userAuthorisation);

        [OperationContract]
        Task<string> DeleteActivity(string id);

        [OperationContract]
        Task<string> DeleteRole(string id);

        [OperationContract]
        Task<string> DeleteUserAuthorisation(string id);

        [OperationContract]
        Task<string> RemoveActivityFromActivity(string activityId, string parentId);

        [OperationContract]
        Task<string> RemoveActivityFromRole(string activityId, string roleId);

        [OperationContract]
        Task<string> RemoveRoleFromRole(string roleId, string parentId);

        [OperationContract]
        Task<string> RemoveRoleFromUser(string roleId, string userId);

        [OperationContract]
        Task<string> AddActivityToRole(string roleId, string activityId);

        [OperationContract]
        Task<string> AddActivityToActivity(string parentActivityId, string activityId);

        [OperationContract]
        Task<string> AddRoleToUser(string userId, string roleId);

        [OperationContract]
        Task<string> AddRoleToRole(string parentRoleId, string roleId);
    }
}
