using System.Threading.Tasks;
using DevelopmentInProgress.DipCore;
using DevelopmentInProgress.DipCore.Service;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Service
{
    public class AuthorisationManagerServiceProxy : IAuthorisationManagerServiceProxy
    {
        private readonly IAuthorisationManagerServiceAsync authorisationManagerService;

        public AuthorisationManagerServiceProxy(IAuthorisationManagerServiceAsync authorisationManagerServiceAsync)
        {
            this.authorisationManagerService = authorisationManagerServiceAsync;
        }

        public async Task<Authorisation> GetAuthorisation()
        {
            var response = await authorisationManagerService.GetAuthorisation().ConfigureAwait(false);
            var authorisation = ServiceResponse.Deserialize<Authorisation>(response);
            return authorisation;
        }

        public async Task<Activity> SaveActivity(Activity activity)
        {
            var json = Serializer.SerializeToJson(activity);
            var response = await authorisationManagerService.SaveActivity(json).ConfigureAwait(false);
            activity = ServiceResponse.Deserialize<Activity>(response);
            return activity;
        }

        public async Task<Role> SaveRole(Role role)
        {
            var json = Serializer.SerializeToJson(role);
            var response = await authorisationManagerService.SaveRole(json).ConfigureAwait(false);
            role = ServiceResponse.Deserialize<Role>(response);
            return role;
        }

        public async Task<UserAuthorisation> SaveUserAuthorisation(UserAuthorisation userAuthorisation)
        {
            var json = Serializer.SerializeToJson(userAuthorisation);
            var response = await authorisationManagerService.SaveUserAuthorisation(json).ConfigureAwait(false);
            userAuthorisation = ServiceResponse.Deserialize<UserAuthorisation>(response);
            return userAuthorisation;
        }

        public async Task<bool> DeleteActivity(int id)
        {
            var response = await authorisationManagerService.DeleteActivity(id.ToString()).ConfigureAwait(false);
            ServiceResponse.Deserialize(response);
            return true;
        }

        public async Task<bool> DeleteRole(int id)
        {
            var response = await authorisationManagerService.DeleteRole(id.ToString()).ConfigureAwait(false);
            ServiceResponse.Deserialize(response);
            return true;
        }

        public async Task<bool> DeleteUserAuthorisation(int id)
        {
            var response = await authorisationManagerService.DeleteUserAuthorisation(id.ToString()).ConfigureAwait(false);
            ServiceResponse.Deserialize(response);
            return true;
        }

        public async Task<bool> RemoveActivityFromActivity(int activityId, int parentId)
        {
            var response = await authorisationManagerService.RemoveActivityFromActivity(activityId.ToString(), parentId.ToString()).ConfigureAwait(false);
            ServiceResponse.Deserialize(response);
            return true;
        }

        public async Task<bool> RemoveActivityFromRole(int activityId, int roleId)
        {
            var response = await authorisationManagerService.RemoveActivityFromRole(activityId.ToString(), roleId.ToString()).ConfigureAwait(false);
            ServiceResponse.Deserialize(response);
            return true;
        }

        public async Task<bool> RemoveRoleFromRole(int roleId, int parentId)
        {
            var response = await authorisationManagerService.RemoveRoleFromRole(roleId.ToString(), parentId.ToString()).ConfigureAwait(false);
            ServiceResponse.Deserialize(response);
            return true;
        }

        public async Task<bool> RemoveRoleFromUser(int roleId, int userId)
        {
            var response = await authorisationManagerService.RemoveRoleFromUser(roleId.ToString(), userId.ToString()).ConfigureAwait(false);
            ServiceResponse.Deserialize(response);
            return true;
        }

        public async Task<bool> AddActivityToRole(int roleId, int activityId)
        {
            var response = await authorisationManagerService.AddActivityToRole(roleId.ToString(), activityId.ToString()).ConfigureAwait(false);
            ServiceResponse.Deserialize(response);
            return true;
        }

        public async Task<bool> AddActivityToActivity(int parentActivityId, int activityId)
        {
            var response = await authorisationManagerService.AddActivityToActivity(parentActivityId.ToString(), activityId.ToString()).ConfigureAwait(false);
            ServiceResponse.Deserialize(response);
            return true;
        }

        public async Task<bool> AddRoleToUser(int userId, int roleId)
        {
            var response = await authorisationManagerService.AddRoleToUser(userId.ToString(), roleId.ToString()).ConfigureAwait(false);
            ServiceResponse.Deserialize(response);
            return true;
        }

        public async Task<bool> AddRoleToRole(int parentRoleId, int roleId)
        {
            var response = await authorisationManagerService.AddRoleToRole(parentRoleId.ToString(), roleId.ToString()).ConfigureAwait(false);
            ServiceResponse.Deserialize(response);
            return true;
        }
    }
}