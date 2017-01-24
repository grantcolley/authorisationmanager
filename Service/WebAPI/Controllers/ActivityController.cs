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

        public ServiceResponse<Activity> SaveActivity(Activity activity)
        {
            return authorisationManagerServer.SaveActivity(activity);
        }

        public ServiceResponse<bool> DeleteActivity(int id)
        {
            return authorisationManagerServer.DeleteActivity(id);
        }

        public ServiceResponse<bool> AddActivity(int parentActivityId, int activityId)
        {
            return authorisationManagerServer.AddActivityToActivity(parentActivityId, activityId);
        }

        public ServiceResponse<bool> RemoveActivity(int activityId, int parentId)
        {
            return authorisationManagerServer.RemoveActivityFromActivity(activityId, parentId);
        }
    }
}
