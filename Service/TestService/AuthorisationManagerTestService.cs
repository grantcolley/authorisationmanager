using System;
using DevelopmentInProgress.AuthorisationManager.Server;
using DevelopmentInProgress.AuthorisationManager.Service;
using DevelopmentInProgress.DipCore;
using DevelopmentInProgress.DipCore.Service;

namespace DevelopmentInProgress.AuthorisationManager.TestService
{
    public class AuthorisationManagerTestService : IAuthorisationManagerService
    {
        private readonly AuthorisationManagerServer authorisationManagerServer;

        public AuthorisationManagerTestService(AuthorisationManagerServer authorisationManagerServer)
        {
            this.authorisationManagerServer = authorisationManagerServer;
        }

        public string GetAuthorisation()
        {
            try
            {
                return authorisationManagerServer.GetAuthorisation();
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string SaveActivity(string activity)
        {
            try
            {
                return authorisationManagerServer.SaveActivity(activity);
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string SaveRole(string role)
        {
            try
            {
                return authorisationManagerServer.SaveRole(role);
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string SaveUserAuthorisation(string userAuthorisation)
        {
            try
            {
                return authorisationManagerServer.SaveUserAuthorisation(userAuthorisation);
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string DeleteActivity(string id)
        {
            try
            {
                return authorisationManagerServer.DeleteActivity(id);
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string DeleteRole(string id)
        {
            try
            {
                return authorisationManagerServer.DeleteRole(id);
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string DeleteUserAuthorisation(string id)
        {
            try
            {
                return authorisationManagerServer.DeleteUserAuthorisation(id);
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string RemoveActivityFromActivity(string activityId, string parentId)
        {
            try
            {
                return authorisationManagerServer.RemoveActivityFromActivity(activityId, parentId);
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string RemoveActivityFromRole(string activityId, string roleId)
        {
            try
            {
                return authorisationManagerServer.RemoveActivityFromRole(activityId, roleId);
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string RemoveRoleFromRole(string roleId, string parentId)
        {
            try
            {
                return authorisationManagerServer.RemoveRoleFromRole(roleId, parentId);
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string RemoveRoleFromUser(string roleId, string userId)
        {
            try
            {
                return authorisationManagerServer.RemoveRoleFromUser(roleId, userId);
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string AddActivityToRole(string roleId, string activityId)
        {
            try
            {
                return authorisationManagerServer.AddActivityToRole(roleId, activityId);
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string AddActivityToActivity(string parentActivityId, string activityId)
        {
            try
            {
                return authorisationManagerServer.AddActivityToActivity(parentActivityId, activityId);
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string AddRoleToUser(string userId, string roleId)
        {
            try
            {
                return authorisationManagerServer.AddRoleToUser(userId, roleId);
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string AddRoleToRole(string parentRoleId, string roleId)
        {
            try
            {
                 return authorisationManagerServer.AddRoleToRole(parentRoleId, roleId);
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }
    }
}