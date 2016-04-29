using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
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

        public IList<Activity> GetActivities()
        {
            var response = authorisationManagerService.GetActivities();
            var activities = ServiceResponse.Deserialize<IList<Activity>>(response);
            return activities;
        }

        public IList<Role> GetRoles()
        {
            var response = authorisationManagerService.GetRoles();
            var roles = ServiceResponse.Deserialize<IList<Role>>(response);
            return roles;
        }

        public IList<UserAuthorisation> GetUserAuthorisations()
        {
            var response = authorisationManagerService.GetUserAuthorisations();
            var userAuthorisations = ServiceResponse.Deserialize<IList<UserAuthorisation>>(response);
            return userAuthorisations;
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
            var response = authorisationManagerService.SaveUserAuthorisaion(json);
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
    }
}