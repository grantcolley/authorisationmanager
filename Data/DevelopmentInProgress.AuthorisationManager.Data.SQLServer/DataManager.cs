using System;
using System.Collections.Generic;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Data.SQLServer
{
    public class DataManager : IAuthorisationManagerData
    {
        public IList<Activity> GetActivities()
        {
            throw new NotImplementedException();
        }

        public IList<Role> GetRoles()
        {
            throw new NotImplementedException();
        }

        public IList<UserAuthorisation> GetUserAuthorisations()
        {
            throw new NotImplementedException();
        }

        public Activity SaveActivity(Activity activity)
        {
            throw new NotImplementedException();
        }

        public Role SaveRole(Role role)
        {
            throw new NotImplementedException();
        }

        public UserAuthorisation SaveUserAuthorisation(UserAuthorisation userAuthorisation)
        {
            throw new NotImplementedException();
        }

        public bool DeleteActivity(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRole(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUserAuthorisation(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveActivityFromActivity(int activityId, int parentId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveActivityFromRole(int activityId, int roleId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRoleFromRole(int roleId, int parentId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRoleFromUser(int roleId, int userId)
        {
            throw new NotImplementedException();
        }

        public bool AddActivityToRole(int roleId, int activityId)
        {
            throw new NotImplementedException();
        }

        public bool AddActivityToActivity(int parentActivityId, int activityId)
        {
            throw new NotImplementedException();
        }

        public bool AddRoleToUser(int userId, int roleId)
        {
            throw new NotImplementedException();
        }

        public bool AddRoleToRole(int parentRoleId, int roleId)
        {
            throw new NotImplementedException();
        }
    }
}