using System.Web.Http;
using DevelopmentInProgress.AuthorisationManager.Server;
using DevelopmentInProgress.DipCore.Service;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.WebAPI.Controllers
{
    public class UserAuthorisationController : ApiController
    {
        private readonly IAuthorisationManagerServer authorisationManagerServer;

        public UserAuthorisationController(IAuthorisationManagerServer authorisationManagerServer)
        {
            this.authorisationManagerServer = authorisationManagerServer;
        }

        public ServiceResponse<UserAuthorisation> SaveUserAuthorisation(UserAuthorisation userAuthorisation)
        {
            return authorisationManagerServer.SaveUserAuthorisation(userAuthorisation);
        }

        public ServiceResponse<bool> DeleteUserAuthorisation(int id)
        {
            return authorisationManagerServer.DeleteUserAuthorisation(id);
        }

        public ServiceResponse<bool> AddRole(int userId, int roleId)
        {
            return authorisationManagerServer.AddRoleToUser(userId, roleId);
        }

        public ServiceResponse<bool> RemoveRole(int roleId, int userId)
        {
            return authorisationManagerServer.RemoveRoleFromUser(roleId, userId);
        }
    }
}
