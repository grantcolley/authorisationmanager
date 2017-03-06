using System;
using System.Threading.Tasks;
using DevelopmentInProgress.AuthorisationManager.Service;
using DevelopmentInProgress.DipCore.Service;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.WebApiClient
{
    public class AuthorisationManagerWebApiClient : IAuthorisationManagerServiceAsync
    {
        public async Task<ServiceResponse<Authorisation>> GetAuthorisation()
        {
            throw new NotImplementedException();
            //WCFProxy.AuthorisationManagerServerClient authorisationManagerServerClient = null;

            //try
            //{
            //    authorisationManagerServerClient
            //        = new WCFProxy.AuthorisationManagerServerClient(new WSHttpBinding(),
            //            new EndpointAddress(endpointAddress));

            //    var result = await authorisationManagerServerClient.GetAuthorisationAsync().ConfigureAwait(false);

            //    authorisationManagerServerClient.Close();

            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    if (authorisationManagerServerClient != null)
            //    {
            //        authorisationManagerServerClient.Abort();
            //    }

            //    var serviceResponse = new ServiceResponse<Authorisation>(ex.Message, true);
            //    return serviceResponse;
            //}
        }

        public async Task<ServiceResponse<Activity>> SaveActivity(Activity activity)
        {
            throw new NotImplementedException();
            //WCFProxy.AuthorisationManagerServerClient authorisationManagerServerClient = null;

            //try
            //{
            //    authorisationManagerServerClient
            //        = new WCFProxy.AuthorisationManagerServerClient(new WSHttpBinding(),
            //            new EndpointAddress(endpointAddress));

            //    var result = await authorisationManagerServerClient.SaveActivityAsync(activity).ConfigureAwait(false);

            //    authorisationManagerServerClient.Close();

            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    if (authorisationManagerServerClient != null)
            //    {
            //        authorisationManagerServerClient.Abort();
            //    }

            //    var serviceResponse = new ServiceResponse<Activity>(ex.Message, true);
            //    return serviceResponse;
            //}
        }

        public async Task<ServiceResponse<Role>> SaveRole(Role role)
        {
            throw new NotImplementedException();
            //WCFProxy.AuthorisationManagerServerClient authorisationManagerServerClient = null;

            //try
            //{
            //    authorisationManagerServerClient
            //        = new WCFProxy.AuthorisationManagerServerClient(new WSHttpBinding(),
            //            new EndpointAddress(endpointAddress));

            //    var result = await authorisationManagerServerClient.SaveRoleAsync(role).ConfigureAwait(false);

            //    authorisationManagerServerClient.Close();

            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    if (authorisationManagerServerClient != null)
            //    {
            //        authorisationManagerServerClient.Abort();
            //    }

            //    var serviceResponse = new ServiceResponse<Role>(ex.Message, true);
            //    return serviceResponse;
            //}
        }

        public async Task<ServiceResponse<UserAuthorisation>> SaveUserAuthorisation(UserAuthorisation userAuthorisation)
        {
            throw new NotImplementedException();
            //WCFProxy.AuthorisationManagerServerClient authorisationManagerServerClient = null;

            //try
            //{
            //    authorisationManagerServerClient
            //        = new WCFProxy.AuthorisationManagerServerClient(new WSHttpBinding(),
            //            new EndpointAddress(endpointAddress));

            //    var result = await authorisationManagerServerClient.SaveUserAuthorisationAsync(userAuthorisation).ConfigureAwait(false);

            //    authorisationManagerServerClient.Close();

            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    if (authorisationManagerServerClient != null)
            //    {
            //        authorisationManagerServerClient.Abort();
            //    }

            //    var serviceResponse = new ServiceResponse<UserAuthorisation>(ex.Message, true);
            //    return serviceResponse;
            //}
        }

        public async Task<ServiceResponse<bool>> DeleteActivity(int id)
        {
            throw new NotImplementedException();
            //WCFProxy.AuthorisationManagerServerClient authorisationManagerServerClient = null;

            //try
            //{
            //    authorisationManagerServerClient
            //        = new WCFProxy.AuthorisationManagerServerClient(new WSHttpBinding(),
            //            new EndpointAddress(endpointAddress));

            //    var result = await authorisationManagerServerClient.DeleteActivityAsync(id).ConfigureAwait(false);

            //    authorisationManagerServerClient.Close();

            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    if (authorisationManagerServerClient != null)
            //    {
            //        authorisationManagerServerClient.Abort();
            //    }

            //    var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
            //    return serviceResponse;
            //}
        }

        public async Task<ServiceResponse<bool>> DeleteRole(int id)
        {
            throw new NotImplementedException();
            //WCFProxy.AuthorisationManagerServerClient authorisationManagerServerClient = null;

            //try
            //{
            //    authorisationManagerServerClient
            //        = new WCFProxy.AuthorisationManagerServerClient(new WSHttpBinding(),
            //            new EndpointAddress(endpointAddress));

            //    var result = await authorisationManagerServerClient.DeleteRoleAsync(id).ConfigureAwait(false);

            //    authorisationManagerServerClient.Close();

            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    if (authorisationManagerServerClient != null)
            //    {
            //        authorisationManagerServerClient.Abort();
            //    }

            //    var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
            //    return serviceResponse;
            //}
        }

        public async Task<ServiceResponse<bool>> DeleteUserAuthorisation(int id)
        {
            throw new NotImplementedException();
            //WCFProxy.AuthorisationManagerServerClient authorisationManagerServerClient = null;

            //try
            //{
            //    authorisationManagerServerClient
            //        = new WCFProxy.AuthorisationManagerServerClient(new WSHttpBinding(),
            //            new EndpointAddress(endpointAddress));

            //    var result = await authorisationManagerServerClient.DeleteUserAuthorisationAsync(id).ConfigureAwait(false);

            //    authorisationManagerServerClient.Close();

            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    if (authorisationManagerServerClient != null)
            //    {
            //        authorisationManagerServerClient.Abort();
            //    }

            //    var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
            //    return serviceResponse;
            //}
        }

        public async Task<ServiceResponse<bool>> RemoveActivityFromActivity(int activityId, int parentId)
        {
            throw new NotImplementedException();
            //WCFProxy.AuthorisationManagerServerClient authorisationManagerServerClient = null;

            //try
            //{
            //    authorisationManagerServerClient
            //        = new WCFProxy.AuthorisationManagerServerClient(new WSHttpBinding(),
            //            new EndpointAddress(endpointAddress));

            //    var result = await authorisationManagerServerClient.RemoveActivityFromActivityAsync(activityId, parentId).ConfigureAwait(false);

            //    authorisationManagerServerClient.Close();

            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    if (authorisationManagerServerClient != null)
            //    {
            //        authorisationManagerServerClient.Abort();
            //    }

            //    var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
            //    return serviceResponse;
            //}
        }

        public async Task<ServiceResponse<bool>> RemoveActivityFromRole(int activityId, int roleId)
        {
            throw new NotImplementedException();
            //WCFProxy.AuthorisationManagerServerClient authorisationManagerServerClient = null;

            //try
            //{
            //    authorisationManagerServerClient
            //        = new WCFProxy.AuthorisationManagerServerClient(new WSHttpBinding(),
            //            new EndpointAddress(endpointAddress));

            //    var result = await authorisationManagerServerClient.RemoveActivityFromRoleAsync(activityId, roleId).ConfigureAwait(false);

            //    authorisationManagerServerClient.Close();

            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    if (authorisationManagerServerClient != null)
            //    {
            //        authorisationManagerServerClient.Abort();
            //    }

            //    var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
            //    return serviceResponse;
            //}
        }

        public async Task<ServiceResponse<bool>> RemoveRoleFromRole(int roleId, int parentId)
        {
            throw new NotImplementedException();
            //WCFProxy.AuthorisationManagerServerClient authorisationManagerServerClient = null;

            //try
            //{
            //    authorisationManagerServerClient
            //        = new WCFProxy.AuthorisationManagerServerClient(new WSHttpBinding(),
            //            new EndpointAddress(endpointAddress));

            //    var result = await authorisationManagerServerClient.RemoveRoleFromRoleAsync(roleId, parentId).ConfigureAwait(false);

            //    authorisationManagerServerClient.Close();

            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    if (authorisationManagerServerClient != null)
            //    {
            //        authorisationManagerServerClient.Abort();
            //    }

            //    var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
            //    return serviceResponse;
            //}
        }

        public async Task<ServiceResponse<bool>> RemoveRoleFromUser(int roleId, int userId)
        {
            throw new NotImplementedException();
            //WCFProxy.AuthorisationManagerServerClient authorisationManagerServerClient = null;

            //try
            //{
            //    authorisationManagerServerClient
            //        = new WCFProxy.AuthorisationManagerServerClient(new WSHttpBinding(),
            //            new EndpointAddress(endpointAddress));

            //    var result = await authorisationManagerServerClient.RemoveRoleFromUserAsync(roleId, userId).ConfigureAwait(false);

            //    authorisationManagerServerClient.Close();

            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    if (authorisationManagerServerClient != null)
            //    {
            //        authorisationManagerServerClient.Abort();
            //    }

            //    var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
            //    return serviceResponse;
            //}
        }

        public async Task<ServiceResponse<bool>> AddActivityToRole(int roleId, int activityId)
        {
            throw new NotImplementedException();
            //WCFProxy.AuthorisationManagerServerClient authorisationManagerServerClient = null;

            //try
            //{
            //    authorisationManagerServerClient
            //        = new WCFProxy.AuthorisationManagerServerClient(new WSHttpBinding(),
            //            new EndpointAddress(endpointAddress));

            //    var result = await authorisationManagerServerClient.AddActivityToRoleAsync(roleId, activityId).ConfigureAwait(false);

            //    authorisationManagerServerClient.Close();

            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    if (authorisationManagerServerClient != null)
            //    {
            //        authorisationManagerServerClient.Abort();
            //    }

            //    var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
            //    return serviceResponse;
            //}
        }

        public async Task<ServiceResponse<bool>> AddActivityToActivity(int parentActivityId, int activityId)
        {
            throw new NotImplementedException();
            //WCFProxy.AuthorisationManagerServerClient authorisationManagerServerClient = null;

            //try
            //{
            //    authorisationManagerServerClient
            //        = new WCFProxy.AuthorisationManagerServerClient(new WSHttpBinding(),
            //            new EndpointAddress(endpointAddress));

            //    var result = await authorisationManagerServerClient.AddActivityToActivityAsync(parentActivityId, activityId).ConfigureAwait(false);

            //    authorisationManagerServerClient.Close();

            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    if (authorisationManagerServerClient != null)
            //    {
            //        authorisationManagerServerClient.Abort();
            //    }

            //    var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
            //    return serviceResponse;
            //}
        }

        public async Task<ServiceResponse<bool>> AddRoleToUser(int userId, int roleId)
        {
            throw new NotImplementedException();
            //WCFProxy.AuthorisationManagerServerClient authorisationManagerServerClient = null;

            //try
            //{
            //    authorisationManagerServerClient
            //        = new WCFProxy.AuthorisationManagerServerClient(new WSHttpBinding(),
            //            new EndpointAddress(endpointAddress));

            //    var result = await authorisationManagerServerClient.AddRoleToUserAsync(userId, roleId).ConfigureAwait(false);

            //    authorisationManagerServerClient.Close();

            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    if (authorisationManagerServerClient != null)
            //    {
            //        authorisationManagerServerClient.Abort();
            //    }

            //    var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
            //    return serviceResponse;
            //}
        }

        public async Task<ServiceResponse<bool>> AddRoleToRole(int parentRoleId, int roleId)
        {
            throw new NotImplementedException();
            //WCFProxy.AuthorisationManagerServerClient authorisationManagerServerClient = null;

            //try
            //{
            //    authorisationManagerServerClient
            //        = new WCFProxy.AuthorisationManagerServerClient(new WSHttpBinding(),
            //            new EndpointAddress(endpointAddress));

            //    var result = await authorisationManagerServerClient.AddRoleToRoleAsync(parentRoleId, roleId).ConfigureAwait(false);

            //    authorisationManagerServerClient.Close();

            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    if (authorisationManagerServerClient != null)
            //    {
            //        authorisationManagerServerClient.Abort();
            //    }

            //    var serviceResponse = new ServiceResponse<bool>(ex.Message, true);
            //    return serviceResponse;
            //}
        }
    }
}
