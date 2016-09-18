using System.Collections.Generic;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Data
{
    public class AuthorisationManagerDataProxy : IAuthorisationManagerDataProxy
    {
        private readonly IAuthorisationManagerData authorisationManagerServiceData;

        public AuthorisationManagerDataProxy(IAuthorisationManagerData authorisationManagerServiceData)
        {
            this.authorisationManagerServiceData = authorisationManagerServiceData;
        }

        public IList<Activity> GetActivities()
        {
            return authorisationManagerServiceData.GetActivities();
        }

        public IList<Role> GetRoles(IList<Activity> activities)
        {
            return authorisationManagerServiceData.GetRoles(activities);
        }

        public IList<UserAuthorisation> GetUserAuthorisations(IList<Role> roles)
        {
            return authorisationManagerServiceData.GetUserAuthorisations(roles);
        }

        public Activity SaveActivity(Activity activity)
        {
            return authorisationManagerServiceData.SaveActivity(activity);
        }

        public Role SaveRole(Role role)
        {
            return authorisationManagerServiceData.SaveRole(role);
        }

        public UserAuthorisation SaveUserAuthorisation(UserAuthorisation userAuthorisation)
        {
            return authorisationManagerServiceData.SaveUserAuthorisation(userAuthorisation);
        }

        public bool DeleteActivity(int id)
        {
            return authorisationManagerServiceData.DeleteActivity(id);
        }

        public bool DeleteRole(int id)
        {
            return authorisationManagerServiceData.DeleteRole(id);
        }

        public bool DeleteUserAuthorisation(int id)
        {
            return authorisationManagerServiceData.DeleteUserAuthorisation(id);
        }

        public bool RemoveActivityFromActivity(int activityId, int parentId)
        {
            return authorisationManagerServiceData.RemoveActivityFromActivity(activityId, parentId);
        }

        public bool RemoveActivityFromRole(int activityId, int roleId)
        {
            return authorisationManagerServiceData.RemoveActivityFromRole(activityId, roleId);
        }

        public bool RemoveRoleFromRole(int roleId, int parentId)
        {
            return authorisationManagerServiceData.RemoveRoleFromRole(roleId, parentId);
        }

        public bool RemoveRoleFromUser(int roleId, int userId)
        {
            return authorisationManagerServiceData.RemoveRoleFromUser(roleId, userId);
        }

        public bool AddActivityToRole(int roleId, int activityId)
        {
            return authorisationManagerServiceData.AddActivityToRole(roleId, activityId);
        }

        public bool AddActivityToActivity(int parentActivityId, int activityId)
        {
            return authorisationManagerServiceData.AddActivityToActivity(parentActivityId, activityId);
        }

        public bool AddRoleToUser(int userId, int roleId)
        {
            return authorisationManagerServiceData.AddRoleToUser(userId, roleId);
        }

        public bool AddRoleToRole(int parentRoleId, int roleId)
        {
            return authorisationManagerServiceData.AddRoleToRole(parentRoleId, roleId);
        }
    }
}
