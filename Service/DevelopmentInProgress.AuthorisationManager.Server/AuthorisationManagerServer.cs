using System;
using System.Linq;
using DevelopmentInProgress.AuthorisationManager.Data;
using DevelopmentInProgress.DipCore;
using DevelopmentInProgress.DipCore.Logger;
using DevelopmentInProgress.DipCore.Service;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Server
{
    public class AuthorisationManagerServer : IAuthorisationManagerServer
    {
        private readonly IAuthorisationManagerDataProxy authorisationManagerDataProxy;
        private readonly IDipLog logger;

        public AuthorisationManagerServer(IAuthorisationManagerDataProxy authorisationManagerDataProxy, IDipLog logger)
        {
            this.authorisationManagerDataProxy = authorisationManagerDataProxy;
            this.logger = logger;
        }

        public ServiceResponse<Authorisation> GetAuthorisation()
        {
            var serviceResponse = new ServiceResponse<Authorisation>();

            try
            {
                var activities = authorisationManagerDataProxy.GetActivities();
                var roles = authorisationManagerDataProxy.GetRoles(activities);
                var userAuthorisations = authorisationManagerDataProxy.GetUserAuthorisations(roles);

                var authorisation = new Authorisation();
                authorisation.Activities.AddRange(activities);
                authorisation.Roles.AddRange(roles);
                authorisation.UserAuthorisations.AddRange(userAuthorisations);

                serviceResponse = new ServiceResponse<Authorisation>(){Payload = authorisation};
            }
            catch (Exception ex)
            {
                serviceResponse.IsError = true;
                serviceResponse.Message = ex.Message;
                logger.Log("AuthorisationManagerServer.GetAuthorisation" + ex.Message, LogCategory.Exception, LogPriority.None);
                logger.Log(ex.StackTrace, LogCategory.Exception, LogPriority.None);
            }

            return serviceResponse;
        }

        public ServiceResponse<UserAuthorisation> GetUserAuthorisation(string userName)
        {
            var serviceResponse = new ServiceResponse<UserAuthorisation>();

            try
            {
                // TODO: this can be improved...
                var activities = authorisationManagerDataProxy.GetActivities();
                var roles = authorisationManagerDataProxy.GetRoles(activities);
                var userAuthorisations = authorisationManagerDataProxy.GetUserAuthorisations(roles);
                var userAuthorisation = userAuthorisations.SingleOrDefault(u => u.UserName == userName);
                serviceResponse = new ServiceResponse<UserAuthorisation>() { Payload = userAuthorisation };
            }
            catch (Exception ex)
            {
                serviceResponse.IsError = true;
                serviceResponse.Message = ex.Message;
                logger.Log("AuthorisationManagerServer.GetUserAuthorisation(" + userName + "); " + ex.Message, LogCategory.Exception, LogPriority.None);
                logger.Log(ex.StackTrace, LogCategory.Exception, LogPriority.None);
            }

            return serviceResponse;
        }

        public ServiceResponse<Activity> SaveActivity(Activity activity)
        {
            var serviceResponse = new ServiceResponse<Activity>();

            try
            {
                if (string.IsNullOrWhiteSpace(activity.Name)
                    || string.IsNullOrWhiteSpace(activity.ActivityCode))
                {
                    throw new Exception("Mandatory fields: Name, ActivityCode");
                }

                var savedActivity = authorisationManagerDataProxy.SaveActivity(activity);
                serviceResponse.Payload = savedActivity;
            }
            catch (Exception ex)
            {
                serviceResponse.IsError = true;
                serviceResponse.Message = ex.Message;
                logger.Log("AuthorisationManagerServer.SaveActivity - " + ex.Message, LogCategory.Exception, LogPriority.None);
                logger.Log(Serializer.SerializeToJson(activity), LogCategory.Exception, LogPriority.None);
                logger.Log(ex.StackTrace, LogCategory.Exception, LogPriority.None);
            }

            return serviceResponse;
        }

        public ServiceResponse<Role> SaveRole(Role role)
        {
            var serviceResponse = new ServiceResponse<Role>();

            try
            {
                if (string.IsNullOrWhiteSpace(role.Name)
                    || string.IsNullOrWhiteSpace(role.RoleCode))
                {
                    throw new Exception("Mandatory fields: Name, RoleCode");
                }

                var savedRole = authorisationManagerDataProxy.SaveRole(role);
                serviceResponse.Payload = savedRole;
            }
            catch (Exception ex)
            {
                serviceResponse.IsError = true;
                serviceResponse.Message = ex.Message;
                logger.Log("AuthorisationManagerServer.SaveRole - " + ex.Message, LogCategory.Exception, LogPriority.None);
                logger.Log(Serializer.SerializeToJson(role), LogCategory.Exception, LogPriority.None);
                logger.Log(ex.StackTrace, LogCategory.Exception, LogPriority.None);
            }

            return serviceResponse;
        }

        public ServiceResponse<UserAuthorisation> SaveUserAuthorisation(UserAuthorisation userAuthorisation)
        {
            var serviceResponse = new ServiceResponse<UserAuthorisation>();

            try
            {
                if (string.IsNullOrWhiteSpace(userAuthorisation.UserName)
                    || string.IsNullOrWhiteSpace(userAuthorisation.DisplayName))
                {
                    throw new Exception("Mandatory fields: UserName, DisplayName");
                }

                var savedUserAuthorisation = authorisationManagerDataProxy.SaveUserAuthorisation(userAuthorisation);
                serviceResponse.Payload = savedUserAuthorisation;
            }
            catch (Exception ex)
            {
                serviceResponse.IsError = true;
                serviceResponse.Message = ex.Message;
                logger.Log("AuthorisationManagerServer.SaveUserAuthorisation - " + ex.Message, LogCategory.Exception, LogPriority.None);
                logger.Log(Serializer.SerializeToJson(userAuthorisation), LogCategory.Exception, LogPriority.None);
                logger.Log(ex.StackTrace, LogCategory.Exception, LogPriority.None);
            }

            return serviceResponse;
        }

        public ServiceResponse<bool> DeleteActivity(int id)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var result = authorisationManagerDataProxy.DeleteActivity(id);
                serviceResponse.Payload = result;
            }
            catch (Exception ex)
            {
                serviceResponse.IsError = true;
                serviceResponse.Message = ex.Message;
                logger.Log("AuthorisationManagerServer.DeleteActivity - " + ex.Message, LogCategory.Exception, LogPriority.None);
                logger.Log("activityId = " + id, LogCategory.Exception, LogPriority.None);
                logger.Log(ex.StackTrace, LogCategory.Exception, LogPriority.None);
            }

            return serviceResponse;
        }

        public ServiceResponse<bool> DeleteRole(int id)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var result = authorisationManagerDataProxy.DeleteRole(id);
                serviceResponse.Payload = result;
            }
            catch (Exception ex)
            {
                serviceResponse.IsError = true;
                serviceResponse.Message = ex.Message;
                logger.Log("AuthorisationManagerServer.DeleteRole - " + ex.Message, LogCategory.Exception, LogPriority.None);
                logger.Log("RoleId = " + id, LogCategory.Exception, LogPriority.None);
                logger.Log(ex.StackTrace, LogCategory.Exception, LogPriority.None);
            }

            return serviceResponse;
        }

        public ServiceResponse<bool> DeleteUserAuthorisation(int id)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var result = authorisationManagerDataProxy.DeleteUserAuthorisation(id);
                serviceResponse.Payload = result;
            }
            catch (Exception ex)
            {
                serviceResponse.IsError = true;
                serviceResponse.Message = ex.Message;
                logger.Log("AuthorisationManagerServer.DeleteUserAuthorisation - " + ex.Message, LogCategory.Exception, LogPriority.None);
                logger.Log("UserAuthorisationId = " + id, LogCategory.Exception, LogPriority.None);
                logger.Log(ex.StackTrace, LogCategory.Exception, LogPriority.None);
            }

            return serviceResponse;
        }

        public ServiceResponse<bool> RemoveActivityFromActivity(int activityId, int parentId)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var result = authorisationManagerDataProxy.RemoveActivityFromActivity(activityId, parentId);
                serviceResponse.Payload = result;
            }
            catch (Exception ex)
            {
                serviceResponse.IsError = true;
                serviceResponse.Message = ex.Message;
                logger.Log("AuthorisationManagerServer.RemoveActivityFromActivity - " + ex.Message, LogCategory.Exception, LogPriority.None);
                logger.Log("activityId=" + activityId + ";parentId=" + parentId, LogCategory.Exception, LogPriority.None);
                logger.Log(ex.StackTrace, LogCategory.Exception, LogPriority.None);
            }

            return serviceResponse;
        }

        public ServiceResponse<bool> RemoveActivityFromRole(int activityId, int roleId)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var result = authorisationManagerDataProxy.RemoveActivityFromRole(activityId, roleId);
                serviceResponse.Payload = result;
            }
            catch (Exception ex)
            {
                serviceResponse.IsError = true;
                serviceResponse.Message = ex.Message;
                logger.Log("AuthorisationManagerServer.RemoveActivityFromRole - " + ex.Message, LogCategory.Exception, LogPriority.None);
                logger.Log("activityId=" + activityId + ";roleId=" + roleId, LogCategory.Exception, LogPriority.None);
                logger.Log(ex.StackTrace, LogCategory.Exception, LogPriority.None);
            }

            return serviceResponse;
        }

        public ServiceResponse<bool> RemoveRoleFromRole(int roleId, int parentId)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var result = authorisationManagerDataProxy.RemoveRoleFromRole(roleId, parentId);
                serviceResponse.Payload = result;
            }
            catch (Exception ex)
            {
                serviceResponse.IsError = true;
                serviceResponse.Message = ex.Message;
                logger.Log("AuthorisationManagerServer.RemoveRoleFromRole - " + ex.Message, LogCategory.Exception, LogPriority.None);
                logger.Log("roleId=" + roleId + ";parentId=" + parentId, LogCategory.Exception, LogPriority.None);
                logger.Log(ex.StackTrace, LogCategory.Exception, LogPriority.None);
            }

            return serviceResponse;
        }

        public ServiceResponse<bool> RemoveRoleFromUser(int roleId, int userId)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var result = authorisationManagerDataProxy.RemoveRoleFromUser(roleId, userId);
                serviceResponse.Payload = result;
            }
            catch (Exception ex)
            {
                serviceResponse.IsError = true;
                serviceResponse.Message = ex.Message;
                logger.Log("AuthorisationManagerServer.RemoveRoleFromUser - " + ex.Message, LogCategory.Exception, LogPriority.None);
                logger.Log("roleId=" + roleId + ";userId=" + userId, LogCategory.Exception, LogPriority.None);
                logger.Log(ex.StackTrace, LogCategory.Exception, LogPriority.None);
            }

            return serviceResponse;
        }

        public ServiceResponse<bool> AddActivityToRole(int roleId, int activityId)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var result = authorisationManagerDataProxy.AddActivityToRole(roleId, activityId);
                serviceResponse.Payload = result;
            }
            catch (Exception ex)
            {
                serviceResponse.IsError = true;
                serviceResponse.Message = ex.Message;
                logger.Log("AuthorisationManagerServer.AddActivityToRole - " + ex.Message, LogCategory.Exception, LogPriority.None);
                logger.Log("roleId=" + roleId + ";activityId=" + activityId, LogCategory.Exception, LogPriority.None);
                logger.Log(ex.StackTrace, LogCategory.Exception, LogPriority.None);
            }

            return serviceResponse;
        }

        public ServiceResponse<bool> AddActivityToActivity(int parentActivityId, int activityId)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var result = authorisationManagerDataProxy.AddActivityToActivity(parentActivityId, activityId);
                serviceResponse.Payload = result;
            }
            catch (Exception ex)
            {
                serviceResponse.IsError = true;
                serviceResponse.Message = ex.Message;
                logger.Log("AuthorisationManagerServer.AddActivityToActivity - " + ex.Message, LogCategory.Exception, LogPriority.None);
                logger.Log("parentActivityId=" + parentActivityId + ";activityId=" + activityId, LogCategory.Exception, LogPriority.None);
                logger.Log(ex.StackTrace, LogCategory.Exception, LogPriority.None);
            }

            return serviceResponse;
        }

        public ServiceResponse<bool> AddRoleToUser(int userId, int roleId)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var result = authorisationManagerDataProxy.AddRoleToUser(userId, roleId);
                serviceResponse.Payload = result;
            }
            catch (Exception ex)
            {
                serviceResponse.IsError = true;
                serviceResponse.Message = ex.Message;
                logger.Log("AuthorisationManagerServer.AddRoleToUser - " + ex.Message, LogCategory.Exception, LogPriority.None);
                logger.Log("userId=" + userId + ";roleId=" + roleId, LogCategory.Exception, LogPriority.None);
                logger.Log(ex.StackTrace, LogCategory.Exception, LogPriority.None);
            }

            return serviceResponse;
        }

        public ServiceResponse<bool> AddRoleToRole(int parentRoleId, int roleId)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var result = authorisationManagerDataProxy.AddRoleToRole(parentRoleId, roleId);
                serviceResponse.Payload = result;
            }
            catch (Exception ex)
            {
                serviceResponse.IsError = true;
                serviceResponse.Message = ex.Message;
                logger.Log("AuthorisationManagerServer.AddRoleToRole - " + ex.Message, LogCategory.Exception, LogPriority.None);
                logger.Log("parentRoleId=" + parentRoleId + ";roleId=" + roleId, LogCategory.Exception, LogPriority.None);
                logger.Log(ex.StackTrace, LogCategory.Exception, LogPriority.None);
            }

            return serviceResponse;
        }
    }
}
