using System;
using System.Linq;
using DevelopmentInProgress.AuthorisationManager.Data;
using DevelopmentInProgress.AuthorisationManager.Service;
using DevelopmentInProgress.DipCore;
using DevelopmentInProgress.DipCore.Service;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Server
{
    public class AuthorisationManagerServer : IAuthorisationManagerService
    {
        private readonly IAuthorisationManagerDataProxy authorisationManagerDataProxy;

        public AuthorisationManagerServer(IAuthorisationManagerDataProxy authorisationManagerDataProxy)
        {
            this.authorisationManagerDataProxy = authorisationManagerDataProxy;
        }

        public string GetAuthorisation()
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                var authorisation = new Authorisation();
                authorisationManagerDataProxy.GetActivities().ToList().ForEach(a => authorisation.Activities.Add(a));
                authorisationManagerDataProxy.GetRoles().ToList().ForEach(r => authorisation.Roles.Add(r));
                authorisationManagerDataProxy.GetUserAuthorisations().ToList().ForEach(u => authorisation.UserAuthorisations.Add(u));
                var serialisedAuthorisation = Serializer.SerializeToJson(authorisation);
                serviceResponse = new ServiceResponse() { Message = serialisedAuthorisation };
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            return Serializer.SerializeToJson(serviceResponse);
        }

        public string SaveActivity(string activity)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                var activityToSave = Serializer.DeserializeJson<Activity>(activity);
                var savedActivity = authorisationManagerDataProxy.SaveActivity(activityToSave);
                var serialisedActivity = Serializer.SerializeToJson(savedActivity);
                serviceResponse = new ServiceResponse() {Message = serialisedActivity};
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            return Serializer.SerializeToJson(serviceResponse);
        }

        public string SaveRole(string role)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                var roleToSave = Serializer.DeserializeJson<Role>(role);
                var savedRole = authorisationManagerDataProxy.SaveRole(roleToSave);
                var serialisedRole = Serializer.SerializeToJson(savedRole);
                serviceResponse = new ServiceResponse() {Message = serialisedRole};
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            return Serializer.SerializeToJson(serviceResponse);
        }

        public string SaveUserAuthorisation(string userAuthorisation)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                var userAuthorisationToSave = Serializer.DeserializeJson<UserAuthorisation>(userAuthorisation);
                var savedUserAuthorisation = authorisationManagerDataProxy.SaveUserAuthorisation(userAuthorisationToSave);
                var serialisedUserAuthorisation = Serializer.SerializeToJson(savedUserAuthorisation);
                serviceResponse = new ServiceResponse() {Message = serialisedUserAuthorisation};
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            return Serializer.SerializeToJson(serviceResponse);
        }

        public string DeleteActivity(string id)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                var identity = Int32.Parse(id);
                var result = authorisationManagerDataProxy.DeleteActivity(identity);
                var serialisedResult = Serializer.SerializeToJson(result);
                serviceResponse = new ServiceResponse() {Message = serialisedResult};
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            return Serializer.SerializeToJson(serviceResponse);
        }

        public string DeleteRole(string id)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                var identity = Int32.Parse(id);
                var result = authorisationManagerDataProxy.DeleteRole(identity);
                var serialisedResult = Serializer.SerializeToJson(result);
                serviceResponse = new ServiceResponse() {Message = serialisedResult};
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            return Serializer.SerializeToJson(serviceResponse);
        }

        public string DeleteUserAuthorisation(string id)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                var identity = Int32.Parse(id);
                var result = authorisationManagerDataProxy.DeleteUserAuthorisation(identity);
                var serialisedResult = Serializer.SerializeToJson(result);
                serviceResponse = new ServiceResponse() {Message = serialisedResult};
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            return Serializer.SerializeToJson(serviceResponse);
        }

        public string RemoveActivityFromActivity(string activityId, string parentId)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                var activityIdentity = Int32.Parse(activityId);
                var parentIdentity = Int32.Parse(parentId);
                var result = authorisationManagerDataProxy.RemoveActivityFromActivity(activityIdentity, parentIdentity);
                var serialisedResult = Serializer.SerializeToJson(result);
                serviceResponse = new ServiceResponse() {Message = serialisedResult};
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            return Serializer.SerializeToJson(serviceResponse);
        }

        public string RemoveActivityFromRole(string activityId, string roleId)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                var activityIdentity = Int32.Parse(activityId);
                var roleIdentity = Int32.Parse(roleId);
                var result = authorisationManagerDataProxy.RemoveActivityFromRole(activityIdentity, roleIdentity);
                var serialisedResult = Serializer.SerializeToJson(result);
                serviceResponse = new ServiceResponse() {Message = serialisedResult};
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            return Serializer.SerializeToJson(serviceResponse);
        }

        public string RemoveRoleFromRole(string roleId, string parentId)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                var roleIdentity = Int32.Parse(roleId);
                var parentIdentity = Int32.Parse(parentId);
                var result = authorisationManagerDataProxy.RemoveRoleFromRole(roleIdentity, parentIdentity);
                var serialisedResult = Serializer.SerializeToJson(result);
                serviceResponse = new ServiceResponse() {Message = serialisedResult};
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            return Serializer.SerializeToJson(serviceResponse);
        }

        public string RemoveRoleFromUser(string roleId, string userId)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                var roleIdentity = Int32.Parse(roleId);
                var userIdentity = Int32.Parse(userId);
                var result = authorisationManagerDataProxy.RemoveRoleFromUser(roleIdentity, userIdentity);
                var serialisedResult = Serializer.SerializeToJson(result);
                serviceResponse = new ServiceResponse() {Message = serialisedResult};
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            return Serializer.SerializeToJson(serviceResponse);
        }

        public string AddActivityToRole(string roleId, string activityId)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                var roleIdentity = Int32.Parse(roleId);
                var activityIdentity = Int32.Parse(activityId);
                var result = authorisationManagerDataProxy.AddActivityToRole(roleIdentity, activityIdentity);
                var serialisedResult = Serializer.SerializeToJson(result);
                serviceResponse = new ServiceResponse() {Message = serialisedResult};
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            return Serializer.SerializeToJson(serviceResponse);
        }

        public string AddActivityToActivity(string parentActivityId, string activityId)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                var parentActivityIdentity = Int32.Parse(parentActivityId);
                var activityIdentity = Int32.Parse(activityId);
                var result = authorisationManagerDataProxy.AddActivityToActivity(parentActivityIdentity, activityIdentity);
                var serialisedResult = Serializer.SerializeToJson(result);
                serviceResponse = new ServiceResponse() {Message = serialisedResult};
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            return Serializer.SerializeToJson(serviceResponse);
        }

        public string AddRoleToUser(string userId, string roleId)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                var userIdentity = Int32.Parse(userId);
                var roleIdentity = Int32.Parse(roleId);
                var result = authorisationManagerDataProxy.AddRoleToUser(userIdentity, roleIdentity);
                var serialisedResult = Serializer.SerializeToJson(result);
                serviceResponse = new ServiceResponse() { Message = serialisedResult };
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            return Serializer.SerializeToJson(serviceResponse);
        }

        public string AddRoleToRole(string parentRoleId, string roleId)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                var parentRoleIdentity = Int32.Parse(parentRoleId);
                var roleIdentity = Int32.Parse(roleId);
                var result = authorisationManagerDataProxy.AddRoleToRole(parentRoleIdentity, roleIdentity);
                var serialisedResult = Serializer.SerializeToJson(result);
                serviceResponse = new ServiceResponse() {Message = serialisedResult};
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            return Serializer.SerializeToJson(serviceResponse);
        }
    }
}
