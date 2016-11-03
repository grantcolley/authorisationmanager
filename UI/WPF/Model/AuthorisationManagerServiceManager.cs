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

        public static bool TargetNodeIsDropCandidate(NodeEntityBase target, NodeEntityBase candidate)
        {
            if (target.GetType() == candidate.GetType()
                && target.Id == candidate.Id)
            {
                return true;
            }

            if (target.ParentId == candidate.Id
                && target.ParentType == (ParentType)System.Enum.Parse(typeof(ParentType), candidate.GetType().Name))
            {
                return true;
            }

            return false;
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
            if (activityNode.ParentType == ParentType.Activity)
            {
                authorisationManagerServiceProxy.RemoveActivityFromActivity(activityNode.Id, activityNode.ParentId);
                var parentActivities = activities.Where(a => a.Id.Equals(activityNode.ParentId));
                foreach (var activity in parentActivities)
                {
                    activity.RemoveActivity(activityNode.Id);
                }
            }
        }

        public void RemoveActivityFromRole(ActivityNode activityNode, IList<RoleNode> roles)
        {
            if (activityNode.ParentType == ParentType.Role)
            {
                authorisationManagerServiceProxy.RemoveActivityFromRole(activityNode.Id, activityNode.ParentId);
                var parentRoles = roles.Where(r => r.Id.Equals(activityNode.ParentId));
                foreach (var role in parentRoles)
                {
                    role.RemoveActivity(activityNode.Id);
                }
            }
        }

        public void RemoveRoleFromRole(RoleNode roleNode, IList<RoleNode> roles)
        {
            if (roleNode.ParentType == ParentType.Role)
            {
                authorisationManagerServiceProxy.RemoveRoleFromRole(roleNode.Id, roleNode.ParentId);
                var parentRoles = roles.Where(r => r.Id.Equals(roleNode.ParentId));
                foreach (var role in parentRoles)
                {
                    role.RemoveRole(roleNode.Id);
                }
            }
        }

        public void RemoveRoleFromUser(RoleNode roleNode, IList<UserNode> users)
        {
            if (roleNode.ParentType == ParentType.User)
            {
                authorisationManagerServiceProxy.RemoveRoleFromUser(roleNode.Id, roleNode.ParentId);
                var parentUsers = users.Where(u => u.Id.Equals(roleNode.ParentId));
                foreach (var parent in parentUsers)
                {
                    parent.RemoveRole(roleNode.Id);
                }
            }
        }

        public void AddActivity(ActivityNode activityNode, ActivityNode targetActivityNode, IEnumerable<ActivityNode> targets)
        {
            authorisationManagerServiceProxy.AddActivityToActivity(targetActivityNode.Id, activityNode.Id);
            foreach (var activity in targets)
            {
                if (activity.Activities.All(a => a.Id != activityNode.Id))
                {
                    activity.AddActivity(activityNode);
                }
            }
        }

        public void AddActivity(ActivityNode activityNode, RoleNode targetRoleNode, IEnumerable<RoleNode> targets)
        {
            authorisationManagerServiceProxy.AddActivityToRole(targetRoleNode.Id, activityNode.Id);
            foreach (var role in targets)
            {
                if (role.Activities.All(a => a.Id != activityNode.Id))
                {
                    role.AddActivity(activityNode);
                }
            }
        }

        public void AddRole(RoleNode roleNode, RoleNode targetRoleNode, IEnumerable<RoleNode> targets)
        {
            authorisationManagerServiceProxy.AddRoleToRole(targetRoleNode.Id, roleNode.Id);
            foreach (var role in targets)
            {
                if (role.Roles.All(r => r.Id != roleNode.Id))
                {
                    role.AddRole(roleNode);
                }
            }
        }

        public void AddRole(RoleNode roleNode, UserNode targetUserNode, IEnumerable<UserNode> targets)
        {
            authorisationManagerServiceProxy.AddRoleToUser(targetUserNode.Id, roleNode.Id);
            foreach (var user in targets)
            {
                if (user.Roles.All(r => r.Id != roleNode.Id))
                {
                    user.AddRole(roleNode);
                }
            }
        }

        private ActivityNode GetActivityNode(Activity activity)
        {
            var activityNode = new ActivityNode(activity);
            activity.Activities.ToList().ForEach(a =>
            {
                var an = GetActivityNode(a);
                an.ParentId = activity.Id;
                an.ParentType = ParentType.Activity;

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
                an.ParentId = role.Id;
                an.ParentType = ParentType.Role;

                roleNode.Activities.Add(an);
            });
            role.Roles.ToList().ForEach(r =>
            {
                var rn = GetRoleNode(r);
                rn.ParentId = role.Id;
                rn.ParentType = ParentType.Role;

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
                rn.ParentId = userAuthorisation.Id;
                rn.ParentType = ParentType.User;

                userNode.Roles.Add(rn);
            });
            return userNode;
        }
    }
}
