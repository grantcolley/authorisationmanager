using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevelopmentInProgress.AuthorisationManager.Data.Model;
using DevelopmentInProgress.DipCore;
using DevelopmentInProgress.DipMapper;
using DevelopmentInProgress.DipSecure;
using Oracle.ManagedDataAccess.Client;

namespace DevelopmentInProgress.AuthorisationManager.Data.Oracle
{
    public class AuthorisationManagerData : IAuthorisationManagerData
    {
        private static readonly string ConnectionString;

        static AuthorisationManagerData()
        {
            var password = "eiHhd+H0LXuZ2U3Uk0r5rA==";
            var key = "mtRdRkDqPVCTFUTPSKS+duYpfPR/3fJAaBpCHcPXRy4=";
            var iv = "+xGyGRJCJvHUVCTLU7+dZw==";

            ConnectionString =
                "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=authmanager;Password=" +
                Security.Decrypt(password, key, iv);
        }

        public IList<Activity> GetActivities()
        {
            IList<Activity> activities;
            IList<ActivityActivity> activityActivities;

            using (var conn = new OracleConnection(ConnectionString))
            {
                activities = conn.Select<Activity>().ToList();
                activityActivities = conn.Select<ActivityActivity>().ToList();
            }

            var groups = activityActivities.OrderBy(a => a.ActivityId).GroupBy(a => a.ParentActivityId);
            foreach (var group in groups)
            {
                var parentActivity = activities.SingleOrDefault(a => a.Id == group.Key);
                if (parentActivity == null)
                {
                    continue;
                }

                foreach (var child in group)
                {
                    var childActivity = activities.SingleOrDefault(a => a.Id == child.ActivityId);
                    if (childActivity != null)
                    {
                        parentActivity.Activities.Add(childActivity);
                    }
                }
            }

            return activities;
        }

        public IList<Role> GetRoles(IList<Activity> activities)
        {
            IList<Role> roles;
            IList<RoleRole> roleRoles;
            IList<RoleActivity> roleActivities;

            using (var conn = new OracleConnection(ConnectionString))
            {
                roles = conn.Select<Role>().ToList();
                roleRoles = conn.Select<RoleRole>().ToList();
                roleActivities = conn.Select<RoleActivity>().ToList();
            }

            var roleActivityGroups = roleActivities.OrderBy(r => r.ActivityId).GroupBy(r => r.RoleId);
            foreach (var group in roleActivityGroups)
            {
                var role = roles.SingleOrDefault(r => r.Id.Equals(group.Key));
                if (role == null)
                {
                    continue;
                }

                foreach (var activity in group)
                {
                    var childActivity = activities.SingleOrDefault(a => a.Id == activity.ActivityId);
                    if (childActivity != null)
                    {
                        role.Activities.Add(childActivity);
                    }
                }
            }

            var groups = roleRoles.OrderBy(r => r.RoleId).GroupBy(r => r.ParentRoleId);
            foreach (var group in groups)
            {
                var parentRole = roles.SingleOrDefault(r => r.Id == group.Key);
                if (parentRole == null)
                {
                    continue;
                }

                foreach (var child in group)
                {
                    var childRole = roles.SingleOrDefault(r => r.Id == child.RoleId);
                    if (childRole != null)
                    {
                        parentRole.Roles.Add(childRole);
                    }
                }
            }

            return roles;
        }

        public IList<UserAuthorisation> GetUserAuthorisations(IList<Role> roles)
        {
            IList<UserAuthorisation> userAuthorisations;
            IList<UserRole> userRoles;

            using (var conn = new OracleConnection(ConnectionString))
            {
                userAuthorisations = conn.Select<UserAuthorisation>().ToList();
                userRoles = conn.Select<UserRole>().ToList();
            }

            var groups = userRoles.OrderBy(r => r.RoleId).GroupBy(r => r.Id);
            foreach (var group in groups)
            {
                var userAuthorisation = userAuthorisations.SingleOrDefault(u => u.Id == group.Key);
                if (userAuthorisation == null)
                {
                    continue;
                }

                foreach (var child in group)
                {
                    var role = roles.SingleOrDefault(r => r.Id == child.RoleId);
                    if (role != null)
                    {
                        userAuthorisation.Roles.Add(role);
                    }
                }
            }

            return userAuthorisations;
        }

        public Activity SaveActivity(Activity activity)
        {
            var isInsert = activity.Id.Equals(0);

            using (var conn = new OracleConnection(ConnectionString))
            {
                if (isInsert)
                {
                    activity.Id = Convert.ToInt32(conn.ExecuteScalar("SELECT \"ACTIVITY_SEQ\".NEXTVAL FROM DUAL"));
                    activity = conn.Insert(activity);
                }
                else
                {
                    conn.Update(activity, new OracleParameter() {ParameterName = "Id", Value = activity.Id});
                }
            }

            return activity;
        }

        public Role SaveRole(Role role)
        {
            var isInsert = role.Id.Equals(0);

            using (var conn = new OracleConnection(ConnectionString))
            {
                if (isInsert)
                {
                    role.Id = Convert.ToInt32(conn.ExecuteScalar("SELECT \"ROLE_SEQ\".NEXTVAL FROM DUAL"));
                    role = conn.Insert(role);
                }
                else
                {
                    conn.Update(role, new OracleParameter() {ParameterName = "Id", Value = role.Id});
                }
            }

            return role;
        }

        public UserAuthorisation SaveUserAuthorisation(UserAuthorisation userAuthorisation)
        {
            var isInsert = userAuthorisation.Id.Equals(0);

            using (var conn = new OracleConnection(ConnectionString))
            {
                if (isInsert)
                {
                    userAuthorisation.Id = Convert.ToInt32(conn.ExecuteScalar("SELECT \"USERAUTHORISATION_SEQ\".NEXTVAL FROM DUAL"));
                    userAuthorisation = conn.Insert(userAuthorisation);
                }
                else
                {
                    conn.Update(userAuthorisation,
                        new OracleParameter() {ParameterName = "Id", Value = userAuthorisation.Id});
                }
            }

            return userAuthorisation;
        }

        public bool DeleteActivity(int id)
        {
            var sql = "DELETE FROM ActivityActivity WHERE ParentActivityId = " + id + " or ActivityId = " + id
                      + "; DELETE FROM RoleActivity WHERE ActivityId = " + id
                      + "; DELETE FROM Activity WHERE Id = " + id;

            using (var conn = new OracleConnection(ConnectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    conn.ExecuteNonQuery(sql, null, CommandType.Text, transaction);
                    transaction.Commit();
                }
            }

            return true;
        }

        public bool DeleteRole(int id)
        {
            var sql = "DELETE FROM RoleActivity WHERE RoleId = " + id
                      + "; DELETE FROM UserRole WHERE RoleId = " + id
                      + "; DELETE FROM Role WHERE Id = " + id;

            using (var conn = new OracleConnection(ConnectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    conn.ExecuteNonQuery(sql, null, CommandType.Text, transaction);
                    transaction.Commit();
                }
            }

            return true;
        }

        public bool DeleteUserAuthorisation(int id)
        {
            var sql = "DELETE FROM UserRole WHERE Id = " + id
                      + "; DELETE FROM UserAuthorisation WHERE Id = " + id;

            using (var conn = new OracleConnection(ConnectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    conn.ExecuteNonQuery(sql, null, CommandType.Text, transaction);
                    transaction.Commit();
                }
            }

            return true;
        }

        public bool RemoveActivityFromActivity(int activityId, int parentId)
        {
            using (var conn = new OracleConnection(ConnectionString))
            {
                var parameters = new List<OracleParameter>();
                parameters.Add(new OracleParameter() {ParameterName = "ActivityId", Value = activityId});
                parameters.Add(new OracleParameter() {ParameterName = "ParentActivityId", Value = parentId});
                var recordsAffected = conn.Delete<ActivityActivity>(parameters);
                return recordsAffected.Equals(1);
            }
        }

        public bool RemoveActivityFromRole(int activityId, int roleId)
        {
            using (var conn = new OracleConnection(ConnectionString))
            {
                var parameters = new List<OracleParameter>();
                parameters.Add(new OracleParameter() {ParameterName = "ActivityId", Value = activityId});
                parameters.Add(new OracleParameter() {ParameterName = "RoleId", Value = roleId});
                var recordsAffected = conn.Delete<RoleActivity>(parameters);
                return recordsAffected.Equals(1);
            }
        }

        public bool RemoveRoleFromRole(int roleId, int parentId)
        {
            using (var conn = new OracleConnection(ConnectionString))
            {
                var parameters = new List<OracleParameter>();
                parameters.Add(new OracleParameter() {ParameterName = "RoleId", Value = roleId});
                parameters.Add(new OracleParameter() {ParameterName = "ParentRoleId", Value = parentId});
                var recordsAffected = conn.Delete<RoleRole>(parameters);
                return recordsAffected.Equals(1);
            }
        }

        public bool RemoveRoleFromUser(int roleId, int userId)
        {
            using (var conn = new OracleConnection(ConnectionString))
            {
                var parameters = new List<OracleParameter>();
                parameters.Add(new OracleParameter() {ParameterName = "Id", Value = userId});
                parameters.Add(new OracleParameter() {ParameterName = "RoleId", Value = roleId});
                var recordsAffected = conn.Delete<UserRole>(parameters);
                return recordsAffected.Equals(1);
            }
        }

        public bool AddActivityToRole(int roleId, int activityId)
        {
            var roleActivity = new RoleActivity() {ActivityId = activityId, RoleId = roleId};

            using (var conn = new OracleConnection(ConnectionString))
            {
                conn.Insert(roleActivity);
            }

            return true;
        }

        public bool AddActivityToActivity(int parentActivityId, int activityId)
        {
            var activityActivity = new ActivityActivity() {ActivityId = activityId, ParentActivityId = parentActivityId};

            using (var conn = new OracleConnection(ConnectionString))
            {
                conn.Insert(activityActivity);
            }

            return true;
        }

        public bool AddRoleToUser(int userId, int roleId)
        {
            var userRole = new UserRole() {Id = userId, RoleId = roleId};

            using (var conn = new OracleConnection(ConnectionString))
            {
                conn.Insert(userRole);
            }

            return true;
        }

        public bool AddRoleToRole(int parentRoleId, int roleId)
        {
            var roleRole = new RoleRole() {RoleId = roleId, ParentRoleId = parentRoleId};

            using (var conn = new OracleConnection(ConnectionString))
            {
                conn.Insert(roleRole);
            }

            return true;
        }
    }
}
