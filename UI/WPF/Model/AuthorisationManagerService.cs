using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevelopmentInProgress.AuthorisationManager.Service;
using DevelopmentInProgress.DipSecure;
using Microsoft.Practices.ObjectBuilder2;

namespace DevelopmentInProgress.AuthorisationManager.WPF.Model
{
    public class AuthorisationManagerService
    {
        private readonly IAuthorisationManagerServiceProxy authorisationManagerServiceProxy;

        public AuthorisationManagerService(IAuthorisationManagerServiceProxy authorisationManagerServiceProxy)
        {
            this.authorisationManagerServiceProxy = authorisationManagerServiceProxy;
        }

        public List<ActivityNode> GetActivityNodes()
        {
            var activityNodes = new List<ActivityNode>();
            var activities = authorisationManagerServiceProxy.GetActivities();
            activities.ForEach(a => activityNodes.Add(GetActivityNode(a)));
            return activityNodes;
        }

        public List<RoleNode> GetRoleNodes()
        {
            var roleNodes = new List<RoleNode>();
            var roles = authorisationManagerServiceProxy.GetRoles();
            roles.ForEach(r => roleNodes.Add(GetRoleNode(r)));
            return roleNodes;
        }

        public List<UserNode> GetUserNodes()
        {
            var userNodes = new List<UserNode>();
            var userAuthorisations = authorisationManagerServiceProxy.GetUserAuthorisations();
            userAuthorisations.ForEach(u => userNodes.Add(GetUserNode(u)));
            return userNodes;
        }

        private ActivityNode GetActivityNode(Activity activity)
        {
            var activityNode = new ActivityNode() { Id = activity.Id, Text = activity.Name };
            activity.Activities.ForEach(a => activityNode.Activities.Add(GetActivityNode(a)));
            return activityNode;
        }

        private RoleNode GetRoleNode(Role role)
        {
            var roleNode = new RoleNode() {Id = role.Id, Text = role.Name};
            role.Activities.ForEach(a => roleNode.Activities.Add(GetActivityNode(a)));
            role.Roles.ForEach(r => roleNode.Roles.Add(GetRoleNode(r)));
            return roleNode;
        }

        private UserNode GetUserNode(UserAuthorisation userAuthorisation)
        {
            var userNode = new UserNode() {Id = userAuthorisation.Id, Text = userAuthorisation.DisplayName};
            userAuthorisation.Roles.ForEach(r => userNode.Roles.Add(GetRoleNode(r)));
            return userNode;
        }
    }
}
