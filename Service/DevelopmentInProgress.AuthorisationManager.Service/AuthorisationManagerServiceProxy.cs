using System.Collections.Generic;
using DevelopmentInProgress.DipCore;
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
            var json = authorisationManagerService.GetActivities();
            var activities = Serializer.DeserializeJson<IList<Activity>>(json);
            return activities;
        }

        public IList<Role> GetRoles()
        {
            var json = authorisationManagerService.GetRoles();
            var roles = Serializer.DeserializeJson<IList<Role>>(json);
            return roles;
        }

        public IList<UserAuthorisation> GetUserAuthorisations()
        {
            var json = authorisationManagerService.GetUserAuthorisations();
            var userAuthorisations = Serializer.DeserializeJson<IList<UserAuthorisation>>(json);
            return userAuthorisations;
        }

        public Activity SaveActivity(Activity activity)
        {
            var json = Serializer.SerializeToJson(activity);
            var result = authorisationManagerService.SaveActivity(json);
            activity = Serializer.DeserializeJson<Activity>(result);
            return activity;
        }

        public Role SaveRole(Role role)
        {
            var json = Serializer.SerializeToJson(role);
            var result = authorisationManagerService.SaveRole(json);
            role = Serializer.DeserializeJson<Role>(result);
            return role;
        }

        public UserAuthorisation SaveUserAuthorisation(UserAuthorisation userAuthorisation)
        {
            return null;
        }
    }
}