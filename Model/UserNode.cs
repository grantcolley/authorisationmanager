using System.Collections.Generic;

namespace DevelopmentInProgress.AuthorisationManager.WPF.Model
{
    public class UserNode : EntityBase
    {
        public UserNode()
        {
            Roles = new List<RoleNode>();
        }

        public List<RoleNode> Roles { get; set; }
    }
}
