using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DevelopmentInProgress.AuthorisationManager.Service;
using DevelopmentInProgress.DipCore.Service;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.WebApiClient
{
    public class AuthorisationManagerWebApiClient : IAuthorisationManagerServiceAsync
    {
        private readonly string baseAddress = "http://localhost:58599/";

        public async Task<ServiceResponse<Authorisation>> GetAuthorisation()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Authorisation/GetAuthorisations");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsAsync<ServiceResponse<Authorisation>>();
                return content;
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse<Authorisation>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<UserAuthorisation>> GetUserAuthorisation(string userName)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Authorisation/GetUserAuthorisation/" + userName);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsAsync<ServiceResponse<UserAuthorisation>>();
                return content;
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse<UserAuthorisation>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<Activity>> SaveActivity(Activity activity)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Activity/SaveActivity/", activity);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsAsync<ServiceResponse<Activity>>();
                return content;
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse<Activity>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<Role>> SaveRole(Role role)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Role/SaveRole/", role);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsAsync<ServiceResponse<Role>>();
                return content;
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse<Role>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<UserAuthorisation>> SaveUserAuthorisation(UserAuthorisation userAuthorisation)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/UserAuthorisation/SaveUserAuthorisation/", userAuthorisation);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsAsync<ServiceResponse<UserAuthorisation>>();
                return content;
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse<UserAuthorisation>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> DeleteActivity(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);

            try
            {
                HttpResponseMessage response = await client.DeleteAsync("api/Activity/DeleteActivity/" + id);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsAsync<ServiceResponse<bool>>();
                return content;
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> DeleteRole(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);

            try
            {
                HttpResponseMessage response = await client.DeleteAsync("api/Role/DeleteRole/" + id);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsAsync<ServiceResponse<bool>>();
                return content;
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> DeleteUserAuthorisation(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);

            try
            {
                HttpResponseMessage response = await client.DeleteAsync("api/UserAuthorisation/DeleteUserAuthorisation/" + id);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsAsync<ServiceResponse<bool>>();
                return content;
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> RemoveActivityFromActivity(int activityId, int parentId)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);

            try
            {
                HttpResponseMessage response =
                    await client.GetAsync("api/Activity/RemoveActivity/" + activityId + "/" + parentId);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsAsync<ServiceResponse<bool>>();
                return content;
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> RemoveActivityFromRole(int activityId, int roleId)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);

            try
            {
                HttpResponseMessage response =
                    await client.GetAsync("api/Role/RemoveActivity/" + activityId + "/" + roleId);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsAsync<ServiceResponse<bool>>();
                return content;
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> RemoveRoleFromRole(int roleId, int parentId)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);

            try
            {
                HttpResponseMessage response =
                    await client.GetAsync("api/Role/RemoveRole/" + roleId + "/" + parentId);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsAsync<ServiceResponse<bool>>();
                return content;
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> RemoveRoleFromUser(int roleId, int userId)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);

            try
            {
                HttpResponseMessage response =
                    await client.GetAsync("api/UserAuthorisation/RemoveRole/" + roleId + "/" + userId);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsAsync<ServiceResponse<bool>>();
                return content;
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> AddActivityToRole(int roleId, int activityId)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response =
                    await client.GetAsync("api/Role/AddActivity/" + roleId + "/" + activityId);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsAsync<ServiceResponse<bool>>();
                return content;
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> AddActivityToActivity(int parentActivityId, int activityId)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response =
                    await client.GetAsync("api/Activity/AddActivity/" + parentActivityId + "/" + activityId);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsAsync<ServiceResponse<bool>>();
                return content;
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> AddRoleToUser(int userId, int roleId)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response =
                    await client.GetAsync("api/UserAuthorisation/AddRole/" + userId + "/" + roleId);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsAsync<ServiceResponse<bool>>();
                return content;
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> AddRoleToRole(int parentRoleId, int roleId)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response =
                    await client.GetAsync("api/Role/AddRole/" + parentRoleId + "/" + roleId);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsAsync<ServiceResponse<bool>>();
                return content;
            }
            catch (Exception ex)
            {
                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }
    }
}
