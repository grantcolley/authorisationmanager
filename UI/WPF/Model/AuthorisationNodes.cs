using System.Collections.Generic;

namespace DevelopmentInProgress.AuthorisationManager.WPF.Model
{
    public class AuthorisationNodes
    {
        public AuthorisationNodes()
        {
            ActivityNodes = new List<ActivityNode>();
            RoleNodes = new List<RoleNode>();
            UserNodes = new List<UserNode>();
        }

        public IList<ActivityNode> ActivityNodes { get; private set; }
        public IList<RoleNode> RoleNodes { get; private set; }
        public IList<UserNode> UserNodes { get; private set; }
    }
}
