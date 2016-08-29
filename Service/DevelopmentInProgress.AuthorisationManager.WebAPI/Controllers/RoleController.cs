using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevelopmentInProgress.AuthorisationManager.WebAPI.Controllers
{
    public class RoleController : ApiController
    {
        public string GetRoles()
        {
            throw new NotImplementedException();
        }

        public string SaveRole(string role)
        {
            throw new NotImplementedException();
        }

        public string DeleteRole(string id)
        {
            throw new NotImplementedException();
        }

        public string RemoveActivity(string activityId, string roleId)
        {
            throw new NotImplementedException();
        }

        public string RemoveRole(string roleId, string parentId)
        {
            throw new NotImplementedException();
        }

        public string AddActivity(string roleId, string activityId)
        {
            throw new NotImplementedException();
        }

        public string AddRole(string parentRoleId, string roleId)
        {
            throw new NotImplementedException();
        }
    }
}
