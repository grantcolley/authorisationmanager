using System.Web.Http;
using DevelopmentInProgress.AuthorisationManager.Server;
using DevelopmentInProgress.DipCore.Service;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.WebAPI.Controllers
{
    public class ActivityController : ApiController
    {
        private readonly IAuthorisationManagerServer authorisationManagerServer;

        public ActivityController(IAuthorisationManagerServer authorisationManagerServer)
        {
            this.authorisationManagerServer = authorisationManagerServer;
        }

        [HttpPost]
        [Route("api/Activity/SaveActivity/")]
        public ServiceResponse<Activity> SaveActivity(Activity activity)
        {
            return authorisationManagerServer.SaveActivity(activity);
        }

        [HttpDelete]
        [Route("api/Activity/DeleteActivity/{id:int}")]
        public ServiceResponse<bool> DeleteActivity(int id)
        {
            return authorisationManagerServer.DeleteActivity(id);
        }

        [HttpPut]
        [Route("api/Activity/AddActivity/{parentActivityId:int}/{activityId:int}")]
        public ServiceResponse<bool> AddActivity(int parentActivityId, int activityId)
        {
            return authorisationManagerServer.AddActivityToActivity(parentActivityId, activityId);
        }

        [HttpDelete]
        [Route("api/Activity/RemoveActivity/{activityId:int}/{parentId:int}")]
        public ServiceResponse<bool> RemoveActivity(int activityId, int parentId)
        {
            return authorisationManagerServer.RemoveActivityFromActivity(activityId, parentId);
        }
    }
}
