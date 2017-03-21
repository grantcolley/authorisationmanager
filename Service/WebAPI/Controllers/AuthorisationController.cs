using System.Web.Http;
using DevelopmentInProgress.AuthorisationManager.Server;
using DevelopmentInProgress.DipCore.Service;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.WebAPI.Controllers
{
    public class AuthorisationController : ApiController
    {
        private readonly IAuthorisationManagerServer authorisationManagerServer;

        public AuthorisationController(IAuthorisationManagerServer authorisationManagerServer)
        {
            this.authorisationManagerServer = authorisationManagerServer;
        }

        [HttpGet]
        [Route("api/Authorisation/GetAuthorisations")]
        public ServiceResponse<Authorisation> GetAuthorisations()
        {
            return authorisationManagerServer.GetAuthorisation();
        }

        [HttpGet]
        [Route("api/Authorisation/GetUserAuthorisation/{userName}")]
        public ServiceResponse<UserAuthorisation> GetUserAuthorisation(string userName)
        {
            return authorisationManagerServer.GetUserAuthorisation(userName);
        }
    }
}
