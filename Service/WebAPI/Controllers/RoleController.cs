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

        public ServiceResponse<Role> SaveRole(Role role)
        {
            return authorisationManagerServer.SaveRole(role);
        }

        public ServiceResponse<bool> DeleteRole(int id)
        {
            return authorisationManagerServer.DeleteRole(id);
        }

        public ServiceResponse<bool> AddActivity(int roleId, int activityId)
        {
            return authorisationManagerServer.AddActivityToRole(roleId, activityId);
        }

        public ServiceResponse<bool> AddRole(int parentRoleId, int roleId)
        {
            return authorisationManagerServer.AddRoleToRole(parentRoleId, roleId);
        }

        public ServiceResponse<bool> RemoveActivity(int activityId, int roleId)
        {
            return authorisationManagerServer.RemoveActivityFromRole(activityId, roleId);
        }

        public ServiceResponse<bool> RemoveRole(int roleId, int parentId)
        {
            return authorisationManagerServer.RemoveRoleFromRole(roleId, parentId);
        }
    }
}
