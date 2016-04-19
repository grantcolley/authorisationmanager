using System.Collections.Generic;
using System.Linq;
using DevelopmentInProgress.AuthorisationManager.Service;
using DevelopmentInProgress.DipSecure;

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
            activities.ToList().ForEach(a => activityNodes.Add(GetActivityNode(a)));
            return activityNodes;
        }

        public List<RoleNode> GetRoleNodes()
        {
            var roleNodes = new List<RoleNode>();
            var roles = authorisationManagerServiceProxy.GetRoles();
            roles.ToList().ForEach(r => roleNodes.Add(GetRoleNode(r)));
            return roleNodes;
        }

        public List<UserNode> GetUserNodes()
        {
            var userNodes = new List<UserNode>();
            var userAuthorisations = authorisationManagerServiceProxy.GetUserAuthorisations();
            userAuthorisations.ToList().ForEach(u => userNodes.Add(GetUserNode(u)));
            return userNodes;
        }

        public ActivityNode SaveActivity(ActivityNode activityNode)
        {
            var activity = authorisationManagerServiceProxy.SaveActivity(activityNode.Activity);
            var savedActivityNode = GetActivityNode(activity);

            activityNode.Id = savedActivityNode.Id;
            activityNode.Text = savedActivityNode.Text;
            activityNode.Code = savedActivityNode.Code;
            activityNode.Description = savedActivityNode.Description;
            return activityNode;
        }

        public RoleNode SaveRole(RoleNode roleNode)
        {
            var role = authorisationManagerServiceProxy.SaveRole(roleNode.Role);
            var savedRoleNode = GetRoleNode(role);

            roleNode.Id = savedRoleNode.Id;
            roleNode.Text = savedRoleNode.Text;
            roleNode.Code = savedRoleNode.Code;
            roleNode.Description = savedRoleNode.Description;
            return roleNode;
        }

        public UserNode SaveUser(UserNode userNode)
        {
            var user = authorisationManagerServiceProxy.SaveUserAuthorisation(userNode.UserAuthorisation);
            var savedUserNode = GetUserNode(user);

            userNode.Id = savedUserNode.Id;
            userNode.Text = savedUserNode.Text;
            userNode.Description = savedUserNode.Description;
            return userNode;
        }

        public void DeleteActivity(int id)
        {
            authorisationManagerServiceProxy.DeleteActivity(id);
        }

        public void DeleteRole(int id)
        {
            authorisationManagerServiceProxy.DeleteRole(id);
        }

        public void DeleteUserAuthorisation(int id)
        {
            authorisationManagerServiceProxy.DeleteUserAuthorisation(id);
        }
        
        private ActivityNode GetActivityNode(Activity activity)
        {
            var activityNode = new ActivityNode(activity);
            activity.Activities.ToList().ForEach(a =>
            {
                var an = GetActivityNode(a);
                an.Parent = activityNode;
                activityNode.Activities.Add(an);
            });
            return activityNode;
        }

        private RoleNode GetRoleNode(Role role)
        {
            var roleNode = new RoleNode(role);
            role.Activities.ToList().ForEach(a =>
            {
                var an = GetActivityNode(a);
                an.Parent = roleNode;
                roleNode.Activities.Add(an);
            });
            role.Roles.ToList().ForEach(r =>
            {
                var rn = GetRoleNode(r);
                rn.Parent = roleNode;
                roleNode.Roles.Add(GetRoleNode(r));
            });
            return roleNode;
        }

        private UserNode GetUserNode(UserAuthorisation userAuthorisation)
        {
            var userNode = new UserNode(userAuthorisation);
            userAuthorisation.Roles.ToList().ForEach(r =>
            {
                var rn = GetRoleNode(r);
                rn.Parent = userNode;
                userNode.Roles.Add(rn);
            });
            return userNode;
        }
    }
}
