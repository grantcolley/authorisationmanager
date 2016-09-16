using DevelopmentInProgress.DipCore;
using DevelopmentInProgress.DipCore.Service;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Service
{
    public class AuthorisationManagerServiceProxy : IAuthorisationManagerServiceProxy
    {
        private readonly IAuthorisationManagerService authorisationManagerService;

        public AuthorisationManagerServiceProxy(IAuthorisationManagerService authorisationManagerService)
        {
            this.authorisationManagerService = authorisationManagerService;
        }

        public Authorisation GetAuthorisation()
        {
            var response = authorisationManagerService.GetAuthorisation();
            var authorisation = ServiceResponse.Deserialize<Authorisation>(response);
            return authorisation;
        }

        public Activity SaveActivity(Activity activity)
        {
            var json = Serializer.SerializeToJson(activity);
            var response = authorisationManagerService.SaveActivity(json);
            activity = ServiceResponse.Deserialize<Activity>(response);
            return activity;
        }

        public Role SaveRole(Role role)
        {
            var json = Serializer.SerializeToJson(role);
            var response = authorisationManagerService.SaveRole(json);
            role = ServiceResponse.Deserialize<Role>(response);
            return role;
        }

        public UserAuthorisation SaveUserAuthorisation(UserAuthorisation userAuthorisation)
        {
            var json = Serializer.SerializeToJson(userAuthorisation);
            var response = authorisationManagerService.SaveUserAuthorisation(json);
            userAuthorisation = ServiceResponse.Deserialize<UserAuthorisation>(response);
            return userAuthorisation;
        }

        public void DeleteActivity(int id)
        {
            var response = authorisationManagerService.DeleteActivity(id.ToString());
            ServiceResponse.Deserialize(response);
        }

        public void DeleteRole(int id)
        {
            var response = authorisationManagerService.DeleteRole(id.ToString());
            ServiceResponse.Deserialize(response);
        }

        public void DeleteUserAuthorisation(int id)
        {
            var response = authorisationManagerService.DeleteUserAuthorisation(id.ToString());
            ServiceResponse.Deserialize(response);
        }

        public void RemoveActivityFromActivity(int activityId, int parentId)
        {
            var response = authorisationManagerService.RemoveActivityFromActivity(activityId.ToString(), parentId.ToString());
            ServiceResponse.Deserialize(response);
        }

        public void RemoveActivityFromRole(int activityId, int roleId)
        {
            var response = authorisationManagerService.RemoveActivityFromRole(activityId.ToString(), roleId.ToString());
            ServiceResponse.Deserialize(response);
        }

        public void RemoveRoleFromRole(int roleId, int parentId)
        {
            var response = authorisationManagerService.RemoveRoleFromRole(roleId.ToString(), parentId.ToString());
            ServiceResponse.Deserialize(response);
        }

        public void RemoveRoleFromUser(int roleId, int userId)
        {
            var response = authorisationManagerService.RemoveRoleFromUser(roleId.ToString(), userId.ToString());
            ServiceResponse.Deserialize(response);
        }

        public void AddActivityToRole(int roleId, int activityId)
        {
            var response = authorisationManagerService.AddActivityToRole(roleId.ToString(), activityId.ToString());
            ServiceResponse.Deserialize(response);
        }

        public void AddActivityToActivity(int parentActivityId, int activityId)
        {
            var response = authorisationManagerService.AddActivityToActivity(parentActivityId.ToString(), activityId.ToString());
            ServiceResponse.Deserialize(response);
        }

        public void AddRoleToUser(int userId, int roleId)
        {
            var response = authorisationManagerService.AddRoleToUser(userId.ToString(), roleId.ToString());
            ServiceResponse.Deserialize(response);
        }

        public void AddRoleToRole(int parentRoleId, int roleId)
        {
            var response = authorisationManagerService.AddRoleToRole(parentRoleId.ToString(), roleId.ToString());
            ServiceResponse.Deserialize(response);
        }
    }
}