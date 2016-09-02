using System;
using System.Collections.Generic;
using System.Linq;
using DevelopmentInProgress.AuthorisationManager.Server;

namespace DevelopmentInProgress.AuthorisationManager.Service.Test
{
    public class AuthorisationManagerTestService : IAuthorisationManagerService
    {
        public string GetActivities()
        {
            string response = string.Empty;

            try
            {
                var authorisationManagerServer = new AuthorisationManagerServer();
                response = authorisationManagerServer.GetActivities();
            }
            catch (Exception ex)
            {
                // do stuff here...
            }

            return response;
        }

        public string GetRoles()
        {
            string response = string.Empty;

            try
            {
                var authorisationManagerServer = new AuthorisationManagerServer();
                response = authorisationManagerServer.GetRoles();
            }
            catch (Exception ex)
            {
                // do stuff here...
            }

            return response;
        }

        public string GetUserAuthorisations()
        {
            string response = string.Empty;

            try
            {
                var authorisationManagerServer = new AuthorisationManagerServer();
                response = authorisationManagerServer.GetUserAuthorisations();
            }
            catch (Exception ex)
            {
                // do stuff here...
            }

            return response;
        }

        public string SaveActivity(string activity)
        {
            string response = string.Empty;

            try
            {
                var authorisationManagerServer = new AuthorisationManagerServer();
                response = authorisationManagerServer.SaveActivity(activity);
            }
            catch (Exception ex)
            {
                // do stuff here...
            }

            return response;
        }

        public string SaveRole(string role)
        {
            string response = string.Empty;

            try
            {
                var authorisationManagerServer = new AuthorisationManagerServer();
                response = authorisationManagerServer.SaveRole(role);
            }
            catch (Exception ex)
            {
                // do stuff here...
            }

            return response;
        }

        public string SaveUserAuthorisation(string userAuthorisation)
        {
            string response = string.Empty;

            try
            {
                var authorisationManagerServer = new AuthorisationManagerServer();
                response = authorisationManagerServer.SaveUserAuthorisation(userAuthorisation);
            }
            catch (Exception ex)
            {
                // do stuff here...
            }

            return response;
        }

        public string DeleteActivity(string id)
        {
            string response = string.Empty;

            try
            {
                var authorisationManagerServer = new AuthorisationManagerServer();
                response = authorisationManagerServer.DeleteActivity(id);
            }
            catch (Exception ex)
            {
                // do stuff here...
            }

            return response;
        }

        public string DeleteRole(string id)
        {
            string response = string.Empty;

            try
            {
                var authorisationManagerServer = new AuthorisationManagerServer();
                response = authorisationManagerServer.DeleteRole(id);
            }
            catch (Exception ex)
            {
                // do stuff here...
            }

            return response;
        }

        public string DeleteUserAuthorisation(string id)
        {
            string response = string.Empty;

            try
            {
                var authorisationManagerServer = new AuthorisationManagerServer();
                response = authorisationManagerServer.DeleteUserAuthorisation(id);
            }
            catch (Exception ex)
            {
                // do stuff here...
            }

            return response;
        }

        public string RemoveActivityFromActivity(string activityId, string parentId)
        {
            string response = string.Empty;

            try
            {
                var authorisationManagerServer = new AuthorisationManagerServer();
                response = authorisationManagerServer.RemoveActivityFromActivity(activityId, parentId);
            }
            catch (Exception ex)
            {
                // do stuff here...
            }

            return response;
        }

        public string RemoveActivityFromRole(string activityId, string roleId)
        {
            string response = string.Empty;

            try
            {
                var authorisationManagerServer = new AuthorisationManagerServer();
                response = authorisationManagerServer.RemoveActivityFromRole(activityId, roleId);
            }
            catch (Exception ex)
            {
                // do stuff here...
            }

            return response;
        }

        public string RemoveRoleFromRole(string roleId, string parentId)
        {
            string response = string.Empty;

            try
            {
                var authorisationManagerServer = new AuthorisationManagerServer();
                response = authorisationManagerServer.RemoveRoleFromRole(roleId, parentId);
            }
            catch (Exception ex)
            {
                // do stuff here...
            }

            return response;
        }

        public string RemoveRoleFromUser(string roleId, string userId)
        {
            string response = string.Empty;

            try
            {
                var authorisationManagerServer = new AuthorisationManagerServer();
                response = authorisationManagerServer.RemoveRoleFromUser(roleId, userId);
            }
            catch (Exception ex)
            {
                // do stuff here...
            }

            return response;
        }

        public string AddActivityToRole(string roleId, string activityId)
        {
            string response = string.Empty;

            try
            {
                var authorisationManagerServer = new AuthorisationManagerServer();
                response = authorisationManagerServer.AddActivityToRole(roleId, activityId);
            }
            catch (Exception ex)
            {
                // do stuff here...
            }

            return response;
        }

        public string AddActivityToActivity(string parentActivityId, string activityId)
        {
            string response = string.Empty;

            try
            {
                var authorisationManagerServer = new AuthorisationManagerServer();
                response = authorisationManagerServer.AddActivityToActivity(parentActivityId, activityId);
            }
            catch (Exception ex)
            {
                // do stuff here...
            }

            return response;
        }

        public string AddRoleToUser(string userId, string roleId)
        {
            string response = string.Empty;

            try
            {
                var authorisationManagerServer = new AuthorisationManagerServer();
                response = authorisationManagerServer.AddRoleToUser(userId, roleId);
            }
            catch (Exception ex)
            {
                // do stuff here...
            }

            return response;
        }

        public string AddRoleToRole(string parentRoleId, string roleId)
        {
            string response = string.Empty;

            try
            {
                var authorisationManagerServer = new AuthorisationManagerServer();
                response = authorisationManagerServer.AddRoleToRole(parentRoleId, roleId);
            }
            catch (Exception ex)
            {
                // do stuff here...
            }

            return response;
        }
    }
}