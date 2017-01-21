using System;
using System.ServiceModel;
using System.Threading.Tasks;
using DevelopmentInProgress.AuthorisationManager.Service;
using DevelopmentInProgress.DipCore.Service;
using DevelopmentInProgress.DipSecure;
using WCFProxy = DevelopmentInProgress.AuthorisationManager.WCFClient.AuthorisationManagerServiceReference;

namespace DevelopmentInProgress.AuthorisationManager.WCFClient
{
    public class AuthorisationManagerWCFClient : IAuthorisationManagerServiceAsync
    {
        private string endpointAddress =
            "http://localhost:8733/Design_Time_Addresses/AuthorisationManager/AuthorisationManagerService";

        public async Task<ServiceResponse<Authorisation>> GetAuthorisation()
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

                var serviceResponse = new ServiceResponse<Authorisation>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<Activity>> SaveActivity(Activity activity)
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

                var serviceResponse = new ServiceResponse<Activity>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<Role>> SaveRole(Role role)
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

                var serviceResponse = new ServiceResponse<Role>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<UserAuthorisation>> SaveUserAuthorisation(UserAuthorisation userAuthorisation)
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

                var serviceResponse = new ServiceResponse<UserAuthorisation>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> DeleteActivity(int id)
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

                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> DeleteRole(int id)
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

                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> DeleteUserAuthorisation(int id)
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

                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> RemoveActivityFromActivity(int activityId, int parentId)
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

                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> RemoveActivityFromRole(int activityId, int roleId)
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

                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> RemoveRoleFromRole(int roleId, int parentId)
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

                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> RemoveRoleFromUser(int roleId, int userId)
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

                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> AddActivityToRole(int roleId, int activityId)
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

                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> AddActivityToActivity(int parentActivityId, int activityId)
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

                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> AddRoleToUser(int userId, int roleId)
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

                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<bool>> AddRoleToRole(int parentRoleId, int roleId)
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

                var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
                return serviceResponse;
            }
        }
    }
}
