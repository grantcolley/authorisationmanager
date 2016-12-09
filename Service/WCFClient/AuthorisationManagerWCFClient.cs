using System;
using System.ServiceModel;
using System.Threading.Tasks;
using DevelopmentInProgress.AuthorisationManager.Service;
using DevelopmentInProgress.DipCore;
using DevelopmentInProgress.DipCore.Service;
using WCFProxy = DevelopmentInProgress.AuthorisationManager.WCFClient.AuthorisationManagerServiceReference;

namespace DevelopmentInProgress.AuthorisationManager.WCFClient
{
    public class AuthorisationManagerWCFClient : IAuthorisationManagerServiceAsync
    {
        private string endpointAddress =
            "http://localhost:8733/Design_Time_Addresses/AuthorisationManager/AuthorisationManagerService";

        public async Task<string> GetAuthorisation()
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = await authorisationManagerServiceClient.GetAuthorisationAsync().ConfigureAwait(false);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, true);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public async Task<string> SaveActivity(string activity)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = await authorisationManagerServiceClient.SaveActivityAsync(activity).ConfigureAwait(false);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, true);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public async Task<string> SaveRole(string role)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = await authorisationManagerServiceClient.SaveRoleAsync(role).ConfigureAwait(false);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, true);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public async Task<string> SaveUserAuthorisation(string userAuthorisation)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = await authorisationManagerServiceClient.SaveUserAuthorisationAsync(userAuthorisation).ConfigureAwait(false);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, true);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public async Task<string> DeleteActivity(string id)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = await authorisationManagerServiceClient.DeleteActivityAsync(id).ConfigureAwait(false);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, true);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public async Task<string> DeleteRole(string id)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = await authorisationManagerServiceClient.DeleteRoleAsync(id).ConfigureAwait(false);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, true);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public async Task<string> DeleteUserAuthorisation(string id)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = await authorisationManagerServiceClient.DeleteUserAuthorisationAsync(id).ConfigureAwait(false);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, true);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public async Task<string> RemoveActivityFromActivity(string activityId, string parentId)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = await authorisationManagerServiceClient.RemoveActivityFromActivityAsync(activityId, parentId).ConfigureAwait(false);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, true);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public async Task<string> RemoveActivityFromRole(string activityId, string roleId)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = await authorisationManagerServiceClient.RemoveActivityFromRoleAsync(activityId, roleId).ConfigureAwait(false);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, true);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public async Task<string> RemoveRoleFromRole(string roleId, string parentId)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = await authorisationManagerServiceClient.RemoveRoleFromRoleAsync(roleId, parentId).ConfigureAwait(false);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, true);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public async Task<string> RemoveRoleFromUser(string roleId, string userId)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = await authorisationManagerServiceClient.RemoveRoleFromUserAsync(roleId, userId).ConfigureAwait(false);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, true);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public async Task<string> AddActivityToRole(string roleId, string activityId)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = await authorisationManagerServiceClient.AddActivityToRoleAsync(roleId, activityId).ConfigureAwait(false);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, true);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public async Task<string> AddActivityToActivity(string parentActivityId, string activityId)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = await authorisationManagerServiceClient.AddActivityToActivityAsync(parentActivityId, activityId).ConfigureAwait(false);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, true);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public async Task<string> AddRoleToUser(string userId, string roleId)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = await authorisationManagerServiceClient.AddRoleToUserAsync(userId, roleId).ConfigureAwait(false);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, true);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public async Task<string> AddRoleToRole(string parentRoleId, string roleId)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = await authorisationManagerServiceClient.AddRoleToRoleAsync(parentRoleId, roleId).ConfigureAwait(false);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, true);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }
    }
}
