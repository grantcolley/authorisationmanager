using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<AuthorisationNodes> GetAuthorisationNodes()
        {
            var authorisationNodes = new AuthorisationNodes();
            var authorisation = await authorisationManagerServiceProxy.GetAuthorisation().ConfigureAwait(false);
            authorisation.Activities.ToList().ForEach(a => authorisationNodes.ActivityNodes.Add(GetActivityNode(a)));
            authorisation.Roles.ToList().ForEach(r => authorisationNodes.RoleNodes.Add(GetRoleNode(r)));
            authorisation.UserAuthorisations.ToList().ForEach(u => authorisationNodes.UserNodes.Add(GetUserNode(u)));
            return authorisationNodes;
        }

        public async Task<ActivityNode> SaveActivity(ActivityNode activityNode, IEnumerable<ActivityNode> activities)
        {
            var activity = await authorisationManagerServiceProxy.SaveActivity(activityNode.Activity).ConfigureAwait(false);
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

        public async Task<RoleNode> SaveRole(RoleNode roleNode, IEnumerable<RoleNode> roles)
        {
            var role = await authorisationManagerServiceProxy.SaveRole(roleNode.Role).ConfigureAwait(false);
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

        public async Task<UserNode> SaveUser(UserNode userNode, IEnumerable<UserNode> users)
        {
            var user = await authorisationManagerServiceProxy.SaveUserAuthorisation(userNode.UserAuthorisation).ConfigureAwait(false);
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

        public async Task<bool> DeleteActivity(ActivityNode activityNode, IList list)
        {
            var result = await authorisationManagerServiceProxy.DeleteActivity(activityNode.Id);
            if (result)
            {
                list.RemoveNested(activityNode, a => a.Id.Equals(activityNode.Id));
            }

            return result;
        }

        public async Task<bool> DeleteRole(RoleNode roleNode, IList list)
        {
            var result = await authorisationManagerServiceProxy.DeleteRole(roleNode.Id);
            if (result)
            {
                list.RemoveNested(roleNode, r => r.Id.Equals(roleNode.Id));
            }

            return result;
        }

        public async Task<bool> DeleteUserAuthorisation(UserNode userNode, IList list)
        {
            var result = await authorisationManagerServiceProxy.DeleteUserAuthorisation(userNode.Id);
            if (result)
            {
                list.RemoveNested(userNode, u => u.Id.Equals(userNode.Id));
            }

            return result;
        }

        public async Task<bool> RemoveActivityFromActivity(ActivityNode activityNode, IList<ActivityNode> activities)
        {
            if (activityNode.ParentType == ParentType.ActivityNode)
            {
                var result = await authorisationManagerServiceProxy.RemoveActivityFromActivity(activityNode.Id, activityNode.ParentId);
                if (result)
                {
                    var parentActivities = activities.Where(a => a.Id.Equals(activityNode.ParentId));
                    foreach (var activity in parentActivities)
                    {
                        activity.RemoveActivity(activityNode.Id);
                    }
                }

                return result;
            }

            return false;
        }

        public async Task<bool> RemoveActivityFromRole(ActivityNode activityNode, IList<RoleNode> roles)
        {
            if (activityNode.ParentType == ParentType.RoleNode)
            {
                var result = await authorisationManagerServiceProxy.RemoveActivityFromRole(activityNode.Id, activityNode.ParentId);
                if (result)
                {
                    var parentRoles = roles.Where(r => r.Id.Equals(activityNode.ParentId));
                    foreach (var role in parentRoles)
                    {
                        role.RemoveActivity(activityNode.Id);
                    }
                }

                return result;
            }

            return false;
        }

        public async Task<bool> RemoveRoleFromRole(RoleNode roleNode, IList<RoleNode> roles)
        {
            if (roleNode.ParentType == ParentType.RoleNode)
            {
                var result = await authorisationManagerServiceProxy.RemoveRoleFromRole(roleNode.Id, roleNode.ParentId);
                if (result)
                {
                    var parentRoles = roles.Where(r => r.Id.Equals(roleNode.ParentId));
                    foreach (var role in parentRoles)
                    {
                        role.RemoveRole(roleNode.Id);
                    }
                }

                return result;
            }

            return false;
        }

        public async Task<bool> RemoveRoleFromUser(RoleNode roleNode, IList<UserNode> users)
        {
            if (roleNode.ParentType == ParentType.UserNode)
            {
                var result = await authorisationManagerServiceProxy.RemoveRoleFromUser(roleNode.Id, roleNode.ParentId);
                if (result)
                {
                    var parentUsers = users.Where(u => u.Id.Equals(roleNode.ParentId));
                    foreach (var parent in parentUsers)
                    {
                        parent.RemoveRole(roleNode.Id);
                    }
                }

                return result;
            }

            return false;
        }

        public async Task<bool> AddActivity(ActivityNode activityNode, ActivityNode targetActivityNode, IEnumerable<ActivityNode> targets)
        {
            var result = await authorisationManagerServiceProxy.AddActivityToActivity(targetActivityNode.Id, activityNode.Id);
            if (result)
            {
                foreach (var activity in targets)
                {
                    if (activity.Activities.All(a => a.Id != activityNode.Id))
                    {
                        activity.AddActivity(activityNode);
                    }
                }
            }

            return result;
        }

        public async Task<bool> AddActivity(ActivityNode activityNode, RoleNode targetRoleNode, IEnumerable<RoleNode> targets)
        {
            var result = await authorisationManagerServiceProxy.AddActivityToRole(targetRoleNode.Id, activityNode.Id);
            if (result)
            {
                foreach (var role in targets)
                {
                    if (role.Activities.All(a => a.Id != activityNode.Id))
                    {
                        role.AddActivity(activityNode);
                    }
                }
            }

            return result;
        }

        public async Task<bool> AddRole(RoleNode roleNode, RoleNode targetRoleNode, IEnumerable<RoleNode> targets)
        {
            var result = await authorisationManagerServiceProxy.AddRoleToRole(targetRoleNode.Id, roleNode.Id);
            if (result)
            {
                foreach (var role in targets)
                {
                    if (role.Roles.All(r => r.Id != roleNode.Id))
                    {
                        role.AddRole(roleNode);
                    }
                }
            }

            return result;
        }

        public async Task<bool> AddRole(RoleNode roleNode, UserNode targetUserNode, IEnumerable<UserNode> targets)
        {
            var result = await authorisationManagerServiceProxy.AddRoleToUser(targetUserNode.Id, roleNode.Id);
            if (result)
            {
                foreach (var user in targets)
                {
                    if (user.Roles.All(r => r.Id != roleNode.Id))
                    {
                        user.AddRole(roleNode);
                    }
                }
            }

            return result;
        }

        private ActivityNode GetActivityNode(Activity activity)
        {
            var activityNode = new ActivityNode(activity);
            activity.Activities.ToList().ForEach(a =>
            {
                var an = GetActivityNode(a);
                an.ParentId = activity.Id;
                an.ParentType = ParentType.ActivityNode;

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
                an.ParentType = ParentType.RoleNode;

                roleNode.Activities.Add(an);
            });
            role.Roles.ToList().ForEach(r =>
            {
                var rn = GetRoleNode(r);
                rn.ParentId = role.Id;
                rn.ParentType = ParentType.RoleNode;

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
                rn.ParentType = ParentType.UserNode;

                userNode.Roles.Add(rn);
            });
            return userNode;
        }
    }
}
