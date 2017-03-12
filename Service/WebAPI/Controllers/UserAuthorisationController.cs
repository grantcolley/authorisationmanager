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

        [HttpPost]
        [Route("api/UserAuthorisation/SaveUserAuthorisation/")]
        public ServiceResponse<UserAuthorisation> SaveUserAuthorisation(UserAuthorisation userAuthorisation)
        {
            return authorisationManagerServer.SaveUserAuthorisation(userAuthorisation);
        }

        [HttpDelete]
        [Route("api/UserAuthorisation/DeleteUserAuthorisation/{id:int}")]
        public ServiceResponse<bool> DeleteUserAuthorisation(int id)
        {
            return authorisationManagerServer.DeleteUserAuthorisation(id);
        }

        [HttpGet]
        [Route("api/UserAuthorisation/AddRole/{userId:int}/{roleId:int}")]
        public ServiceResponse<bool> AddRole(int userId, int roleId)
        {
            return authorisationManagerServer.AddRoleToUser(userId, roleId);
        }

        [HttpGet]
        [Route("api/UserAuthorisation/RemoveRole/{roleId:int}/{userId:int}")]
        public ServiceResponse<bool> RemoveRole(int roleId, int userId)
        {
            return authorisationManagerServer.RemoveRoleFromUser(roleId, userId);
        }
    }
}
