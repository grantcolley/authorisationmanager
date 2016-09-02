using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.WebAPI.Controllers
{
    public class ActivityController : ApiController
    {
        public IEnumerable<Activity> GetActivities()
        {
            throw new NotImplementedException();
        }

        public Activity SaveActivity(string activity)
        {
            throw new NotImplementedException();
        }

        public string DeleteActivity(string id)
        {
            throw new NotImplementedException();
        }

        public string RemoveActivity(string activityId, string parentId)
        {
            throw new NotImplementedException();
        }

        public string AddActivity(string parentActivityId, string activityId)
        {
            throw new NotImplementedException();
        }
    }
}
