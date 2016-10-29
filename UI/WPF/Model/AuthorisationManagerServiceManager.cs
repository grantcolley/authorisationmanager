using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DevelopmentInProgress.AuthorisationManager.Service;
using DevelopmentInProgress.DipCore;
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

        public AuthorisationNodes GetAuthorisationNodes()
        {
            var authorisationNodes = new AuthorisationNodes();
            var authorisation = authorisationManagerServiceProxy.GetAuthorisation();
            authorisation.Activities.ToList().ForEach(a => authorisationNodes.ActivityNodes.Add(GetActivityNode(a)));
            authorisation.Roles.ToList().ForEach(r => authorisationNodes.RoleNodes.Add(GetRoleNode(r)));
            authorisation.UserAuthorisations.ToList().ForEach(u => authorisationNodes.UserNodes.Add(GetUserNode(u)));
            return authorisationNodes;
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

        public void DeleteActivity(ActivityNode activityNode, IList list)
        {
            authorisationManagerServiceProxy.DeleteActivity(activityNode.Id);
            list.RemoveNested(activityNode, a => a.Id.Equals(activityNode.Id));
        }

        public void DeleteRole(RoleNode roleNode, IList list)
        {
            authorisationManagerServiceProxy.DeleteRole(roleNode.Id);
            list.RemoveNested(roleNode, r => r.Id.Equals(roleNode.Id));
        }

        public void DeleteUserAuthorisation(UserNode userNode, IList list)
        {
            authorisationManagerServiceProxy.DeleteUserAuthorisation(userNode.Id);
            list.RemoveNested(userNode, u => u.Id.Equals(userNode.Id));
        }

        public void RemoveActivityFromActivity(ActivityNode activityNode, IList<ActivityNode> activities)
        {
            var parentActivity = activityNode.Parent as ActivityNode;
            if (parentActivity != null)
            {
                authorisationManagerServiceProxy.RemoveActivityFromActivity(activityNode.Id, parentActivity.Id);
                var parentActivities = activities.Where(a => a.Id.Equals(parentActivity.Id));
                foreach (var activity in parentActivities)
                {
                    activity.RemoveActivity(activityNode.Id);
                }
            }
        }

        public void RemoveActivityFromRole(ActivityNode activityNode, IList<RoleNode> roles)
        {
            var parentRole = activityNode.Parent as RoleNode;
            if (parentRole != null)
            {
                authorisationManagerServiceProxy.RemoveActivityFromRole(activityNode.Id, parentRole.Id);
                var parentRoles = roles.Where(r => r.Id.Equals(parentRole.Id));
                foreach (var role in parentRoles)
                {
                    role.RemoveActivity(activityNode.Id);
                }
            }
        }

        public void RemoveRoleFromRole(RoleNode roleNode, IList<RoleNode> roles)
        {
            var parentRole = roleNode.Parent as RoleNode;
            if (parentRole != null)
            {
                authorisationManagerServiceProxy.RemoveRoleFromRole(roleNode.Id, parentRole.Id);
                var parentRoles = roles.Where(r => r.Id.Equals(parentRole.Id));
                foreach (var role in parentRoles)
                {
                    role.RemoveRole(roleNode.Id);
                }
            }
        }

        public void RemoveRoleFromUser(RoleNode roleNode, IList<UserNode> users)
        {
            var parentUser = roleNode.Parent as UserNode;
            if (parentUser != null)
            {
                authorisationManagerServiceProxy.RemoveRoleFromUser(roleNode.Id, parentUser.Id);
                var parentUsers = users.Where(u => u.Id.Equals(parentUser.Id));
                foreach (var parent in parentUsers)
                {
                    parent.RemoveRole(roleNode.Id);
                }
            }
        }

        public bool TryAddActivity(ActivityNode activityNode, IEnumerable<NodeEntityBase> targets, out string message)
        {
            message = string.Empty;

            foreach (var target in targets)
            {
                if (IsAncestor(target, activityNode))
                {
                    message =
                        string.Format(
                            "Invalid drop target. Activity {0} can't be added to itself of be an ancestor of the target.",
                            activityNode.Text);
                    return false;
                }

                if (target is RoleNode)
                {
                    if (((RoleNode) target).Activities.All(a => a.Id != activityNode.Id))
                    {
                        var dropRoleNode = (RoleNode) target;
                        dropRoleNode.AddActivity(activityNode);
                        authorisationManagerServiceProxy.AddActivityToRole(dropRoleNode.Id, activityNode.Id);
                    }
                }
                else if (target is ActivityNode)
                {
                    if (((ActivityNode)target).Activities.All(a => a.Id != activityNode.Id))
                    {
                        var dropActivityNode = (ActivityNode) target;
                        dropActivityNode.AddActivity(activityNode);
                        authorisationManagerServiceProxy.AddActivityToActivity(dropActivityNode.Id, activityNode.Id);
                    }
                }
                else
                {
                    message =
                        string.Format("Invalid drop target. Activity {0} can only be dropped on a role or another activity.",
                            activityNode.Text);
                    return false;
                }
            }

            return true;
        }

        public bool TryAddRole(RoleNode roleNode, IEnumerable<NodeEntityBase> targets, out string message)
        {
            message = string.Empty;

            foreach (var target in targets)
            {
                if (target is UserNode)
                {
                    if (((UserNode) target).Roles.All(r => r.Id != roleNode.Id))
                    {
                        var dropUserNode = (UserNode) target;
                        dropUserNode.AddRole(roleNode);
                        authorisationManagerServiceProxy.AddRoleToUser(dropUserNode.Id, roleNode.Id);
                    }
                }
                else if (IsAncestor(target, roleNode))
                {
                    message =
                        string.Format("Invalid drop target. Role {0} can't be added to itself or be an ancestor of the target.",
                            roleNode.Text);
                    return false;
                }
                else if (target is RoleNode)
                {
                    if (((RoleNode) target).Roles.All(r => r.Id != roleNode.Id))
                    {
                        var dropRoleNode = (RoleNode) target;
                        dropRoleNode.AddRole(roleNode);
                        authorisationManagerServiceProxy.AddRoleToRole(dropRoleNode.Id, roleNode.Id);
                    }
                }
                else
                {
                    message =
                        string.Format("Invalid drop target. Role {0} can only be dropped on a user or another role.",
                            roleNode.Text);
                    return false;
                }
            }

            return true;
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
                roleNode.Roles.Add(rn);
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

        private bool IsAncestor(NodeEntityBase target, NodeEntityBase candidate)
        {
            if (target.GetType() == candidate.GetType()
                && target.Id == candidate.Id)
            {
                return true;
            }

            if (target.Parent == null)
            {
                return false;
            }

            if (target.Parent == candidate
                || (target.Parent.GetType() == candidate.GetType()
                    && target.Parent.Id == candidate.Id))
            {
                return true;
            }

            return IsAncestor(target.Parent, candidate);
        }
    }
}
