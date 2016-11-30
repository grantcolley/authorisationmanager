using System;
using System.ServiceModel;
using DevelopmentInProgress.AuthorisationManager.Service;
using DevelopmentInProgress.DipCore;
using DevelopmentInProgress.DipCore.Service;
using WCFProxy = DevelopmentInProgress.AuthorisationManager.WCFClient.AuthorisationManagerServiceReference;

namespace DevelopmentInProgress.AuthorisationManager.WCFClient
{
    public class AuthorisationManagerWCFClient : IAuthorisationManagerService
    {
        private string endpointAddress =
            "http://localhost:8733/Design_Time_Addresses/AuthorisationManager/AuthorisationManagerService";

        public string GetAuthorisation()
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = authorisationManagerServiceClient.GetAuthorisation();

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string SaveActivity(string activity)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = authorisationManagerServiceClient.SaveActivity(activity);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string SaveRole(string role)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = authorisationManagerServiceClient.SaveRole(role);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string SaveUserAuthorisation(string userAuthorisation)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = authorisationManagerServiceClient.SaveUserAuthorisation(userAuthorisation);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string DeleteActivity(string id)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = authorisationManagerServiceClient.DeleteActivity(id);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string DeleteRole(string id)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = authorisationManagerServiceClient.DeleteRole(id);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string DeleteUserAuthorisation(string id)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = authorisationManagerServiceClient.DeleteUserAuthorisation(id);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string RemoveActivityFromActivity(string activityId, string parentId)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = authorisationManagerServiceClient.RemoveActivityFromActivity(activityId, parentId);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string RemoveActivityFromRole(string activityId, string roleId)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = authorisationManagerServiceClient.RemoveActivityFromRole(activityId, roleId);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string RemoveRoleFromRole(string roleId, string parentId)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = authorisationManagerServiceClient.RemoveRoleFromRole(roleId, parentId);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string RemoveRoleFromUser(string roleId, string userId)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = authorisationManagerServiceClient.RemoveRoleFromUser(roleId, userId);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string AddActivityToRole(string roleId, string activityId)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = authorisationManagerServiceClient.AddActivityToRole(roleId, activityId);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string AddActivityToActivity(string parentActivityId, string activityId)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = authorisationManagerServiceClient.AddActivityToActivity(parentActivityId, activityId);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string AddRoleToUser(string userId, string roleId)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = authorisationManagerServiceClient.AddRoleToUser(userId, roleId);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }

        public string AddRoleToRole(string parentRoleId, string roleId)
        {
            WCFProxy.AuthorisationManagerServiceClient authorisationManagerServiceClient = null;

            try
            {
                authorisationManagerServiceClient
                    = new WCFProxy.AuthorisationManagerServiceClient(new WSHttpBinding(),
                        new EndpointAddress(endpointAddress));

                var result = authorisationManagerServiceClient.AddRoleToRole(parentRoleId, roleId);

                authorisationManagerServiceClient.Close();

                return result;
            }
            catch (Exception ex)
            {
                if (authorisationManagerServiceClient != null)
                {
                    authorisationManagerServiceClient.Abort();
                }

                var serviceResponse = new ServiceResponse(ex.Message, ex);
                var response = Serializer.SerializeToJson(serviceResponse);
                return response;
            }
        }
    }
}
