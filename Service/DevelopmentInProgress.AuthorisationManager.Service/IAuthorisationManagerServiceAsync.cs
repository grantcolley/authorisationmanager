using System.ServiceModel;
using System.Threading.Tasks;
using DevelopmentInProgress.DipCore.Service;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Service
{
    [ServiceContract]
    public interface IAuthorisationManagerServiceAsync
    {
        [OperationContract]
        Task<ServiceResponse<Authorisation>> GetAuthorisation();

        [OperationContract]
        Task<ServiceResponse<UserAuthorisation>> GetUserAuthorisation(string userName);

        [OperationContract]
        Task<ServiceResponse<Activity>> SaveActivity(Activity activity);

        [OperationContract]
        Task<ServiceResponse<Role>> SaveRole(Role role);

        [OperationContract]
        Task<ServiceResponse<UserAuthorisation>> SaveUserAuthorisation(UserAuthorisation userAuthorisation);

        [OperationContract]
        Task<ServiceResponse<bool>> DeleteActivity(int id);

        [OperationContract]
        Task<ServiceResponse<bool>> DeleteRole(int id);

        [OperationContract]
        Task<ServiceResponse<bool>> DeleteUserAuthorisation(int id);

        [OperationContract]
        Task<ServiceResponse<bool>> RemoveActivityFromActivity(int activityId, int parentId);

        [OperationContract]
        Task<ServiceResponse<bool>> RemoveActivityFromRole(int activityId, int roleId);

        [OperationContract]
        Task<ServiceResponse<bool>> RemoveRoleFromRole(int roleId, int parentId);

        [OperationContract]
        Task<ServiceResponse<bool>> RemoveRoleFromUser(int roleId, int userId);

        [OperationContract]
        Task<ServiceResponse<bool>> AddActivityToRole(int roleId, int activityId);

        [OperationContract]
        Task<ServiceResponse<bool>> AddActivityToActivity(int parentActivityId, int activityId);

        [OperationContract]
        Task<ServiceResponse<bool>> AddRoleToUser(int userId, int roleId);

        [OperationContract]
        Task<ServiceResponse<bool>> AddRoleToRole(int parentRoleId, int roleId);
    }
}
