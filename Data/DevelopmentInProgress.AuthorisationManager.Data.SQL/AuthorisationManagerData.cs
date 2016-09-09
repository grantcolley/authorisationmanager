﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DevelopmentInProgress.AuthorisationManager.Data.SQL.Model;
using DevelopmentInProgress.DipMapper;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Data.SQL
{
    public class AuthorisationManagerData : IAuthorisationManagerData
    {
        private static string connectionString = "Data Source=(local);Initial Catalog=AuthorisationManager;Integrated Security=true";

        public IList<Activity> GetActivities()
        {
            IList<Activity> activities;
            IList<ActivityActivity> activityActivity;

            using (var conn = new SqlConnection(connectionString))
            {
                activities = conn.Select<Activity>().ToList();
                activityActivity = conn.Select<ActivityActivity>().ToList();
            }

            var groups = activityActivity.OrderBy(a => a.ActivityId).GroupBy(a => a.ParentActivityId);
            foreach (var group in groups)
            {
                var parentActivity = activities.SingleOrDefault(a => a.Id == group.Key);
                if (parentActivity == null)
                {
                    continue;
                }

                foreach (var child in group)
                {
                    var childActivity = activities.First(a => a.Id == child.ActivityId);
                    parentActivity.Activities.Add(childActivity);
                }
            }

            return activities;
        }

        public IList<Role> GetRoles()
        {
            IList<Role> roles;
            IList<RoleRole> roleRoles;
            IList<RoleActivity> roleActivityActivities;

            using (var conn = new SqlConnection(connectionString))
            {
                roles = conn.Select<Role>().ToList();
                roleRoles = conn.Select<RoleRole>().ToList();
                roleActivityActivities = conn.Select<RoleActivity>().ToList();
            }

            var activities = GetActivities();

            var groups = roleRoles.OrderBy(r => r.RoleId).GroupBy(r => r.ParentRoleId);
            foreach (var group in groups)
            {
                var parentRole = roles.SingleOrDefault(r => r.Id == group.Key);
                if (parentRole == null)
                {
                    continue;
                }

                var roleActivities = roleActivityActivities.Where(ra => ra.RoleId == parentRole.Id);
                foreach (var roleActivity in roleActivities)
                {
                    var activity = activities.SingleOrDefault(a => a.Id == roleActivity.ActivityId);
                    if (activity != null)
                    {
                        parentRole.Activities.Add(activity);
                    }
                }

                foreach (var child in group)
                {
                    var childRole = roles.First(r => r.Id == child.RoleId);
                    parentRole.Roles.Add(childRole);
                }
            }

            return roles;
        }

        public IList<UserAuthorisation> GetUserAuthorisations()
        {
            IList<UserAuthorisation> userAuthorisations;
            IList<UserRole> userRoles;

            using (var conn = new SqlConnection(connectionString))
            {
                userAuthorisations = conn.Select<UserAuthorisation>().ToList();
                userRoles = conn.Select<UserRole>().ToList();
            }

            var roles = GetRoles();

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
                    var role = roles.First(r => r.Id == child.RoleId);
                    userAuthorisation.Roles.Add(role);
                }
            }

            return userAuthorisations;
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
                    conn.Update(activity, new Dictionary<string, object>() {{"Id", activity.Id}}, new[] {"Id"});
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
                    conn.Update(role, new Dictionary<string, object>() {{"Id", role.Id}}, new[] {"Id"});
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
                    conn.Update(userAuthorisation, new Dictionary<string, object>() {{"Id", userAuthorisation.Id}}, new[] {"Id"});
                }
            }

            return userAuthorisation;
        }

        public bool DeleteActivity(int id)
        {
            var sql = "DELETE FROM ActivityActivity WHERE ParentActivityId = " + id + " or ActivityId = " + id
                      + "; DELETE FROM RoleActivity WHERE ActivityId = " + id
                      + "; DELETE FROM Activity WHERE Id = " + id;

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(var transaction = conn.BeginTransaction())
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

            using (var conn = new SqlConnection(connectionString))
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

            using (var conn = new SqlConnection(connectionString))
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
            using (var conn = new SqlConnection(connectionString))
            {
                var recordsAffected =
                    conn.Delete<ActivityActivity>(new Dictionary<string, object>()
                    {
                        {"ActivityId", activityId},
                        {"ParentActivityId", parentId}
                    });

                return recordsAffected.Equals(1);
            }
        }

        public bool RemoveActivityFromRole(int activityId, int roleId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var recordsAffected =
                    conn.Delete<RoleActivity>(new Dictionary<string, object>()
                    {
                        {"ActivityId", activityId},
                        {"RoleId", roleId}
                    });

                return recordsAffected.Equals(1);
            }
        }

        public bool RemoveRoleFromRole(int roleId, int parentId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var recordsAffected =
                    conn.Delete<RoleRole>(new Dictionary<string, object>()
                    {
                        {"RoleId", roleId},
                        {"ParentRoleId", parentId}
                    });

                return recordsAffected.Equals(1);
            }
        }

        public bool RemoveRoleFromUser(int roleId, int userId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var recordsAffected =
                    conn.Delete<UserRole>(new Dictionary<string, object>()
                    {
                        {"Id", userId},
                        {"RoleId", roleId}
                    });

                return recordsAffected.Equals(1);
            }
        }

        public bool AddActivityToRole(int roleId, int activityId)
        {
            var roleActivity = new RoleActivity() {ActivityId = activityId, RoleId = roleId};

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Insert(roleActivity);
            }

            return true;
        }

        public bool AddActivityToActivity(int parentActivityId, int activityId)
        {
            var activityActivity = new ActivityActivity() {ActivityId = activityId, ParentActivityId = parentActivityId};

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Insert(activityActivity);
            }

            return true;
        }

        public bool AddRoleToUser(int userId, int roleId)
        {
            var userRole = new UserRole() {Id = userId, RoleId = roleId};

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Insert(userRole);
            }

            return true;
        }

        public bool AddRoleToRole(int parentRoleId, int roleId)
        {
            var roleRole = new RoleRole() {RoleId = roleId, ParentRoleId = parentRoleId};

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Insert(roleRole);
            }

            return true;
        }
    }
}