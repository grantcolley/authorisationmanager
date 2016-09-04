using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DevelopmentInProgress.DipMapper;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Data.SQL
{
    public class AuthorisationManagerData : IAuthorisationManagerData
    {
        private static string connectionString = "Data Source=(local);Initial Catalog=AuthorisationManager;Integrated Security=true";

        public IList<Activity> GetActivities()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Select<Activity>().ToList();
            }
        }

        public IList<Role> GetRoles()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Select<Role>().ToList();
            }
        }

        public IList<UserAuthorisation> GetUserAuthorisations()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Select<UserAuthorisation>().ToList();
            }
        }

        public Activity SaveActivity(Activity activity)
        {
            var isInsert = activity.Id.Equals(0);

            using (var conn = new SqlConnection(connectionString))
            {
                if (isInsert)
                {
                    activity = conn.Insert(activity, "Id");
                }
                else
                {
                    conn.Update(activity, new Dictionary<string, object>() {{"Id", activity.Id}});
                }
            }

            return activity;
        }

        public Role SaveRole(Role role)
        {
            var isInsert = role.Id.Equals(0);

            using (var conn = new SqlConnection(connectionString))
            {
                if (isInsert)
                {
                    role = conn.Insert(role, "Id");
                }
                else
                {
                    conn.Update(role, new Dictionary<string, object>() {{"Id", role.Id}});
                }
            }

            return role;
        }

        public UserAuthorisation SaveUserAuthorisation(UserAuthorisation userAuthorisation)
        {
            var isInsert = userAuthorisation.Id.Equals(0);

            using (var conn = new SqlConnection(connectionString))
            {
                if (isInsert)
                {
                    userAuthorisation = conn.Insert(userAuthorisation, "Id");
                }
                else
                {
                    conn.Update(userAuthorisation, new Dictionary<string, object>() {{"Id", userAuthorisation.Id}});
                }
            }

            return userAuthorisation;
        }

        public bool DeleteActivity(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                // TODO: Delete relationships too...

                var recordsAffected = conn.Delete<Activity>(new Dictionary<string, object>() {{"Id", id}});
                return recordsAffected.Equals(1);
            }
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