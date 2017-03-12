using System.Web.Http;
using DevelopmentInProgress.AuthorisationManager.Server;
using DevelopmentInProgress.DipCore.Service;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.WebAPI.Controllers
{
    public class RoleController : ApiController
    {
        private readonly IAuthorisationManagerServer authorisationManagerServer;

        public RoleController(IAuthorisationManagerServer authorisationManagerServer)
        {
            this.authorisationManagerServer = authorisationManagerServer;
        }

        [HttpPost]
        [Route("api/Role/SaveRole/")]
        public ServiceResponse<Role> SaveRole(Role role)
        {
            return authorisationManagerServer.SaveRole(role);
        }

        [HttpDelete]
        [Route("api/Role/DeleteRole/{id:int}")]
        public ServiceResponse<bool> DeleteRole(int id)
        {
            return authorisationManagerServer.DeleteRole(id);
        }

        [HttpPost]
        [Route("api/Role/AddActivity/{roleId:int}/{activityId:int}")]
        public ServiceResponse<bool> AddActivity(int roleId, int activityId)
        {
            return authorisationManagerServer.AddActivityToRole(roleId, activityId);
        }

        [HttpPost]
        [Route("api/Role/AddRole/{parentRoleId:int}/{roleId:int}")]
        public ServiceResponse<bool> AddRole(int parentRoleId, int roleId)
        {
            return authorisationManagerServer.AddRoleToRole(parentRoleId, roleId);
        }

        [HttpDelete]
        [Route("api/Role/RemoveActivity/{activityId:int}/{roleId:int}")]
        public ServiceResponse<bool> RemoveActivity(int activityId, int roleId)
        {
            return authorisationManagerServer.RemoveActivityFromRole(activityId, roleId);
        }

        [HttpDelete]
        [Route("api/Role/RemoveRole/{roleId:int}/{parentId:int}")]
        public ServiceResponse<bool> RemoveRole(int roleId, int parentId)
        {
            return authorisationManagerServer.RemoveRoleFromRole(roleId, parentId);
        }
    }
}
