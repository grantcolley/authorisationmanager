using System;
using System.Threading.Tasks;
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
            ServiceResponseErrorHandler(response);
            return response.Payload;
        }

        public async Task<UserAuthorisation> GetUserAuthorisation(string userName)
        {
            var response = await authorisationManagerService.GetUserAuthorisation(userName).ConfigureAwait(false);
            ServiceResponseErrorHandler(response);
            return response.Payload;
        }

        public async Task<Activity> SaveActivity(Activity activity)
        {
            var response = await authorisationManagerService.SaveActivity(activity).ConfigureAwait(false);
            ServiceResponseErrorHandler(response);
            return response.Payload;
        }

        public async Task<Role> SaveRole(Role role)
        {
            var response = await authorisationManagerService.SaveRole(role).ConfigureAwait(false);
            ServiceResponseErrorHandler(response);
            return response.Payload;
        }

        public async Task<UserAuthorisation> SaveUserAuthorisation(UserAuthorisation userAuthorisation)
        {
            var response = await authorisationManagerService.SaveUserAuthorisation(userAuthorisation).ConfigureAwait(false);
            ServiceResponseErrorHandler(response);
            return response.Payload;
        }

        public async Task<bool> DeleteActivity(int id)
        {
            var response = await authorisationManagerService.DeleteActivity(id).ConfigureAwait(false);
            ServiceResponseErrorHandler(response);
            return response.Payload;
        }

        public async Task<bool> DeleteRole(int id)
        {
            var response = await authorisationManagerService.DeleteRole(id).ConfigureAwait(false);
            ServiceResponseErrorHandler(response);
            return response.Payload;
        }

        public async Task<bool> DeleteUserAuthorisation(int id)
        {
            var response = await authorisationManagerService.DeleteUserAuthorisation(id).ConfigureAwait(false);
            ServiceResponseErrorHandler(response);
            return response.Payload;
        }

        public async Task<bool> RemoveActivityFromActivity(int activityId, int parentId)
        {
            var response = await authorisationManagerService.RemoveActivityFromActivity(activityId, parentId).ConfigureAwait(false);
            ServiceResponseErrorHandler(response);
            return response.Payload;
        }

        public async Task<bool> RemoveActivityFromRole(int activityId, int roleId)
        {
            var response = await authorisationManagerService.RemoveActivityFromRole(activityId, roleId).ConfigureAwait(false);
            ServiceResponseErrorHandler(response);
            return response.Payload;
        }

        public async Task<bool> RemoveRoleFromRole(int roleId, int parentId)
        {
            var response = await authorisationManagerService.RemoveRoleFromRole(roleId, parentId).ConfigureAwait(false);
            ServiceResponseErrorHandler(response);
            return response.Payload;
        }

        public async Task<bool> RemoveRoleFromUser(int roleId, int userId)
        {
            var response = await authorisationManagerService.RemoveRoleFromUser(roleId, userId).ConfigureAwait(false);
            ServiceResponseErrorHandler(response);
            return response.Payload;
        }

        public async Task<bool> AddActivityToRole(int roleId, int activityId)
        {
            var response = await authorisationManagerService.AddActivityToRole(roleId, activityId).ConfigureAwait(false);
            ServiceResponseErrorHandler(response);
            return response.Payload;
        }

        public async Task<bool> AddActivityToActivity(int parentActivityId, int activityId)
        {
            var response = await authorisationManagerService.AddActivityToActivity(parentActivityId, activityId).ConfigureAwait(false);
            ServiceResponseErrorHandler(response);
            return response.Payload;
        }

        public async Task<bool> AddRoleToUser(int userId, int roleId)
        {
            var response = await authorisationManagerService.AddRoleToUser(userId, roleId).ConfigureAwait(false);
            ServiceResponseErrorHandler(response);
            return response.Payload;
        }

        public async Task<bool> AddRoleToRole(int parentRoleId, int roleId)
        {
            var response = await authorisationManagerService.AddRoleToRole(parentRoleId, roleId).ConfigureAwait(false);
            ServiceResponseErrorHandler(response);
            return response.Payload;
        }

        private void ServiceResponseErrorHandler<T>(ServiceResponse<T> serviceResponse)
        {
            if (serviceResponse.IsError)
            {
                throw new Exception(serviceResponse.Message);
            }
        }
    }
}