using System;
using DevelopmentInProgress.AuthorisationManager.Service;
using DevelopmentInProgress.DipCore;
using DevelopmentInProgress.DipCore.Service;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Server
{
    public class AuthorisationManagerServer : IAuthorisationManagerService
    {
        public string GetActivities()
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                //var jsonActivities = Serializer.SerializeToJson(activities);
                //serviceResponse = new ServiceResponse() { Message = jsonActivities };
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            var json = Serializer.SerializeToJson(serviceResponse);
            return json;
        }

        public string GetRoles()
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                //var jsonRoles = Serializer.SerializeToJson(roles);
                //serviceResponse = new ServiceResponse() { Message = jsonRoles };
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            var json = Serializer.SerializeToJson(serviceResponse);
            return json;
        }

        public string GetUserAuthorisations()
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                //var jsonUserAuthorisations = Serializer.SerializeToJson(usersAuthorisations);
                //serviceResponse = new ServiceResponse() { Message = jsonUserAuthorisations };
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            var json = Serializer.SerializeToJson(serviceResponse);
            return json;
        }

        public string SaveActivity(string activity)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                //var activityToSave = Serializer.DeserializeJson<Activity>(activity);
                //if (activityToSave.Id.Equals(0))
                //{
                //    activityToSave.Id = activities.Max(a => a.Id) + 1;
                //}

                //activities.Add(activityToSave);
                //var jsonActivityToSave = Serializer.SerializeToJson(activityToSave);
                //serviceResponse = new ServiceResponse() { Message = jsonActivityToSave };
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            var json = Serializer.SerializeToJson(serviceResponse);
            return json;
        }

        public string SaveRole(string role)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                //var roleToSave = Serializer.DeserializeJson<Role>(role);
                //if (roleToSave.Id.Equals(0))
                //{
                //    roleToSave.Id = roles.Max(r => r.Id) + 1;
                //}

                //roles.Add(roleToSave);
                //var jsonRoleToSave = Serializer.SerializeToJson(roleToSave);
                //serviceResponse = new ServiceResponse() { Message = jsonRoleToSave };
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            var json = Serializer.SerializeToJson(serviceResponse);
            return json;
        }

        public string SaveUserAuthorisation(string userAuthorisation)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                //var userToSave = Serializer.DeserializeJson<UserAuthorisation>(userAuthorisation);
                //if (userToSave.Id.Equals(0))
                //{
                //    userToSave.Id = usersAuthorisations.Max(u => u.Id) + 1;
                //}

                //usersAuthorisations.Add(userToSave);
                //var jsonUserToSave = Serializer.SerializeToJson(userToSave);
                //serviceResponse = new ServiceResponse() { Message = jsonUserToSave };
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            var json = Serializer.SerializeToJson(serviceResponse);
            return json;
        }

        public string DeleteActivity(string id)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                //int i;
                //Int32.TryParse(id, out i);
                //var activity = activities.FirstOrDefault(a => a.Id == i);
                //if (activity != null)
                //{
                //    activities.Remove(activity);
                //}
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            var json = Serializer.SerializeToJson(serviceResponse);
            return json;
        }

        public string DeleteRole(string id)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                //int i;
                //Int32.TryParse(id, out i);
                //var role = roles.FirstOrDefault(r => r.Id == i);
                //if (role != null)
                //{
                //    roles.Remove(role);
                //}
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            var json = Serializer.SerializeToJson(serviceResponse);
            return json;
        }

        public string DeleteUserAuthorisation(string id)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                //int i;
                //Int32.TryParse(id, out i);
                //var user = usersAuthorisations.FirstOrDefault(u => u.Id == i);
                //if (user != null)
                //{
                //    usersAuthorisations.Remove(user);
                //}
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            var json = Serializer.SerializeToJson(serviceResponse);
            return json;
        }

        public string RemoveActivityFromActivity(string activityId, string parentId)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                // do stuff...
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            var json = Serializer.SerializeToJson(serviceResponse);
            return json;
        }

        public string RemoveActivityFromRole(string activityId, string roleId)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                // do stuff...
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            var json = Serializer.SerializeToJson(serviceResponse);
            return json;
        }

        public string RemoveRoleFromRole(string roleId, string parentId)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                // do stuff...
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            var json = Serializer.SerializeToJson(serviceResponse);
            return json;
        }

        public string RemoveRoleFromUser(string roleId, string userId)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                // do stuff...
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            var json = Serializer.SerializeToJson(serviceResponse);
            return json;
        }

        public string AddActivityToRole(string roleId, string activityId)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                // do stuff...
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            var json = Serializer.SerializeToJson(serviceResponse);
            return json;
        }

        public string AddActivityToActivity(string parentActivityId, string activityId)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                // do stuff...
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            var json = Serializer.SerializeToJson(serviceResponse);
            return json;
        }

        public string AddRoleToUser(string userId, string roleId)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                // do stuff...
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            var json = Serializer.SerializeToJson(serviceResponse);
            return json;
        }

        public string AddRoleToRole(string parentRoleId, string roleId)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                // do stuff...
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            var json = Serializer.SerializeToJson(serviceResponse);
            return json;
        }
    }
}
