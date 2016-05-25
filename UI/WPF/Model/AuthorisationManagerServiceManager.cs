using System.Collections.Generic;
using System.Linq;
using DevelopmentInProgress.AuthorisationManager.Service;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.WPF.Model
{
    public class AuthorisationManagerServiceManager
    {
        private readonly IAuthorisationManagerServiceProxy authorisationManagerServiceProxy;

        public AuthorisationManagerServiceManager(IAuthorisationManagerServiceProxy authorisationManagerServiceProxy)
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

        public ActivityNode SaveActivity(ActivityNode activityNode, IEnumerable<ActivityNode> activities)
        {
            var activity = authorisationManagerServiceProxy.SaveActivity(activityNode.Activity);
            var savedActivityNode = GetActivityNode(activity);

            if (activityNode.Id.Equals(0))
            {
                activityNode.Id = savedActivityNode.Id;
                activityNode.Text = savedActivityNode.Text;
                activityNode.Code = savedActivityNode.Code;
                activityNode.Description = savedActivityNode.Description;
            }

            foreach (var a in activities)
            {
                a.Text = savedActivityNode.Text;
                a.Code = savedActivityNode.Code;
                a.Description = savedActivityNode.Description;
            }

            return activityNode;
        }

        public RoleNode SaveRole(RoleNode roleNode, IEnumerable<RoleNode> roles)
        {
            var role = authorisationManagerServiceProxy.SaveRole(roleNode.Role);
            var savedRoleNode = GetRoleNode(role);

            if (roleNode.Id.Equals(0))
            {
                roleNode.Id = savedRoleNode.Id;
                roleNode.Text = savedRoleNode.Text;
                roleNode.Code = savedRoleNode.Code;
                roleNode.Description = savedRoleNode.Description;
            }

            foreach (var r in roles)
            {
                r.Text = savedRoleNode.Text;
                r.Code = savedRoleNode.Code;
                r.Description = savedRoleNode.Description;                
            }

            return roleNode;
        }

        public UserNode SaveUser(UserNode userNode, IEnumerable<UserNode> users)
        {
            var user = authorisationManagerServiceProxy.SaveUserAuthorisation(userNode.UserAuthorisation);
            var savedUserNode = GetUserNode(user);

            if (userNode.Id.Equals(0))
            {
                userNode.Id = savedUserNode.Id;
                userNode.Text = savedUserNode.Text;
                userNode.Description = savedUserNode.Description;
            }

            foreach (var u in users)
            {
                u.Text = savedUserNode.Text;
                u.Description = savedUserNode.Description;
            }

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

        public void RemoveActivity(ActivityNode activityNode)
        {
            var parentActivity = activityNode.Parent as ActivityNode;
            if (parentActivity != null)
            {
                authorisationManagerServiceProxy.RemoveActivityFromActivity(activityNode.Id, parentActivity.Id);
                parentActivity.Activities.Remove(activityNode);
                return;
            }

            var parentRole = activityNode.Parent as RoleNode;
            if (parentRole != null)
            {
                authorisationManagerServiceProxy.RemoveActivityFromActivity(activityNode.Id, parentRole.Id);
                parentRole.Activities.Remove(activityNode);
            }
        }

        public void RemoveRole(RoleNode roleNode)
        {
            var parentRole = roleNode.Parent as RoleNode;
            if (parentRole != null)
            {
                authorisationManagerServiceProxy.RemoveRoleFromRole(roleNode.Id, parentRole.Id);
                parentRole.Roles.Remove(roleNode);
            }

            var parentUser = roleNode.Parent as UserNode;
            if (parentUser != null)
            {
                authorisationManagerServiceProxy.RemoveRoleFromUser(roleNode.Id, parentUser.Id);
                parentUser.Roles.Remove(roleNode);
            }
        }

        public bool TryAddActivity(ActivityNode activityNode, IEnumerable<EntityBase> targets, out string message)
        {
            message = string.Empty;

            foreach (var target in targets)
            {
                var dropRoleNode = target as RoleNode;
                if (dropRoleNode != null)
                {
                    dropRoleNode.Activities.Add(activityNode);

                    // save role

                }

                var dropActivityNode = target as ActivityNode;
                if (dropActivityNode != null)
                {
                    dropActivityNode.Activities.Add(activityNode);

                    // save activity

                }
            }

            message =
                string.Format("Invalid drop target. Activity {0} can only be dropped on a role or another activity.",
                    activityNode.Text);

            return false;
        }

        public bool TryAddRole(RoleNode roleNode, IEnumerable<EntityBase> targets, out string message)
        {
            message = string.Empty;

            foreach (var target in targets)
            {
                var dropUserNode = target as UserNode;
                if (dropUserNode != null)
                {
                    dropUserNode.Roles.Add(roleNode);

                    // save user

                }

                var dropRoleNode = target as RoleNode;
                if (dropRoleNode != null)
                {
                    dropRoleNode.Roles.Add(roleNode);

                    // save role

                }
            }

            message = string.Format("Invalid drop target. Role {0} can only be dropped on a user or another role.",
                roleNode.Text);

            return false;
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
