using System;
using System.Collections.Generic;
using System.Linq;
using DevelopmentInProgress.DipCore;
using DevelopmentInProgress.DipCore.Service;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Service.Test
{
    public class AuthorisationManagerTestService : IAuthorisationManagerService
    {
        private readonly List<Activity> activities;
        private readonly List<Role> roles;
        private readonly List<UserAuthorisation> usersAuthorisations;

        public AuthorisationManagerTestService()
        {
            var activity1 = new Activity() {Id = 1, Name = "Read", ActivityCode = "READ", Description = "Read access"};
            var activity2 = new Activity() {Id = 2, Name = "Write", ActivityCode = "WRITE", Description = "Write access"};
            activity2.Activities.Add(activity1);
            activities = new List<Activity>(new[] { activity1, activity2 });

            var role1 = new Role() {Id = 1, Name = "Reader", RoleCode = "READER", Description = "Read permission"};
            role1.Activities.Add(activities[0]);

            var role2 = new Role() {Id = 2, Name = "Writer", RoleCode = "WRITER", Description = "Write permission"};
            role2.Activities.Add(activities[0]);
            role2.Activities.Add(activities[1]);

            roles = new List<Role>(new[] {role1, role2});

            var user1 = new UserAuthorisation() {Id = 1, UserName = "jbloggs", DisplayName = "Joe Bloggs"};
            user1.Roles.Add(roles[0]);

            var user2 = new UserAuthorisation() {Id = 2, UserName = "jmasters", DisplayName = "Jane Masters"};
            user2.Roles.Add(roles[1]);

            usersAuthorisations = new List<UserAuthorisation>(new[] { user1, user2 });
        }

        public string GetActivities()
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                var jsonActivities = Serializer.SerializeToJson(activities);
                serviceResponse = new ServiceResponse() { Message = jsonActivities };
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
                var jsonRoles = Serializer.SerializeToJson(roles);
                serviceResponse = new ServiceResponse() {Message = jsonRoles};
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
                var jsonUserAuthorisations = Serializer.SerializeToJson(usersAuthorisations);
                serviceResponse = new ServiceResponse() {Message = jsonUserAuthorisations};
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
                var activityToSave = Serializer.DeserializeJson<Activity>(activity);
                if (activityToSave.Id.Equals(0))
                {
                    activityToSave.Id = activities.Max(a => a.Id) + 1;
                }

                activities.Add(activityToSave);
                var jsonActivityToSave = Serializer.SerializeToJson(activityToSave);
                serviceResponse = new ServiceResponse() {Message = jsonActivityToSave};
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
                var roleToSave = Serializer.DeserializeJson<Role>(role);
                if (roleToSave.Id.Equals(0))
                {
                    roleToSave.Id = roles.Max(r => r.Id) + 1;
                }

                roles.Add(roleToSave);
                var jsonRoleToSave = Serializer.SerializeToJson(roleToSave);
                serviceResponse = new ServiceResponse() {Message = jsonRoleToSave};
            }
            catch (Exception ex)
            {
                serviceResponse.Exception = ex;
            }

            var json = Serializer.SerializeToJson(serviceResponse);
            return json;
        }

        public string SaveUserAuthorisaion(string userAuthorisation)
        {
            var serviceResponse = new ServiceResponse();

            try
            {
                var userToSave = Serializer.DeserializeJson<UserAuthorisation>(userAuthorisation);
                if (userToSave.Id.Equals(0))
                {
                    userToSave.Id = usersAuthorisations.Max(u => u.Id) + 1;
                }

                usersAuthorisations.Add(userToSave);
                var jsonUserToSave = Serializer.SerializeToJson(userToSave);
                serviceResponse = new ServiceResponse() {Message = jsonUserToSave};
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
                int i;
                Int32.TryParse(id, out i);
                var activity = activities.FirstOrDefault(a => a.Id == i);
                if (activity != null)
                {
                    activities.Remove(activity);
                }
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
                int i;
                Int32.TryParse(id, out i);
                var role = roles.FirstOrDefault(r => r.Id == i);
                if (role != null)
                {
                    roles.Remove(role);
                }
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
                int i;
                Int32.TryParse(id, out i);
                var user = usersAuthorisations.FirstOrDefault(u => u.Id == i);
                if (user != null)
                {
                    usersAuthorisations.Remove(user);
                }
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