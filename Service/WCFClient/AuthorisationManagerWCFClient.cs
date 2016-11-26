using System;
using System.ServiceModel;
using DevelopmentInProgress.AuthorisationManager.Service;
using DevelopmentInProgress.DipCore;
using DevelopmentInProgress.DipCore.Service;
using AuthorisationManagerWCFProxy = DevelopmentInProgress.AuthorisationManager.WCFClient.AuthorisationManagerServiceReference;

namespace DevelopmentInProgress.AuthorisationManager.WCFClient
{
    public class AuthorisationManagerWCFClient : IAuthorisationManagerService
    {
        private readonly AuthorisationManagerWCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient;

        public AuthorisationManagerWCFClient()
        {
            authorisationManagerServiceClient =
                new AuthorisationManagerWCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                    new EndpointAddress(
                        "http://localhost:8733/Design_Time_Addresses/AuthorisationManager/AuthorisationManagerService"));
        }

        public string GetAuthorisation()
        {
            try
            {
                return authorisationManagerServiceClient.GetAuthorisation();
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
                return authorisationManagerServiceClient.SaveActivity(activity);
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
                return authorisationManagerServiceClient.SaveRole(role);
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
                return authorisationManagerServiceClient.SaveUserAuthorisation(userAuthorisation);
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
                return authorisationManagerServiceClient.DeleteActivity(id);
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
                return authorisationManagerServiceClient.DeleteRole(id);
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
                return authorisationManagerServiceClient.DeleteUserAuthorisation(id);
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
                return authorisationManagerServiceClient.RemoveActivityFromActivity(activityId, parentId);
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
                return authorisationManagerServiceClient.RemoveActivityFromRole(activityId, roleId);
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
                return authorisationManagerServiceClient.RemoveRoleFromRole(roleId, parentId);
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
                return authorisationManagerServiceClient.RemoveRoleFromUser(roleId, userId);
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
                return authorisationManagerServiceClient.AddActivityToRole(roleId, activityId);
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
                return authorisationManagerServiceClient.AddActivityToActivity(parentActivityId, activityId);
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
                return authorisationManagerServiceClient.AddRoleToUser(userId, roleId);
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
                return authorisationManagerServiceClient.AddRoleToRole(parentRoleId, roleId);
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
