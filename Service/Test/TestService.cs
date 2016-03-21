using System.Collections.Generic;
using DevelopmentInProgress.AuthorisationManager.Model;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Service.Test
{
    public class TestService: IServiceFactory
    {
        public IList<Activity> GetActivities()
        {
            var activity1 = new Activity() { Id = 0, Name = "Read", ActivityCode = "READ" };
            var activity2 = new Activity() { Id = 1, Name = "Write", ActivityCode = "WRITE" };

            return new List<Activity>(new[] { activity1, activity2 });
        }

        public IList<Role> GetRoles()
        {
            var activities = GetActivities();

            var role1 = new Role() {Id = 0, Name = "Reader", RoleCode = "READER"};
            role1.Activities.Add(activities[0]);

            var role2 = new Role() { Id = 1, Name = "Writer", RoleCode = "WRITER" };
            role1.Activities.Add(activities[0]);
            role2.Activities.Add(activities[1]);

            return new List<Role>(new[] {role1, role2});
        }

        public IList<UserAuthorisation> GetUserAuthorisations()
        {
            var roles = GetRoles();

            var user1 = new UserAuthorisation("gcolley") {DisplayName = "Grant Colley"};
            user1.Roles.Add(roles[0]);

            var user2 = new UserAuthorisation("mcolley") { DisplayName = "Melanie Colley" };
            user2.Roles.Add(roles[1]);

            return new List<UserAuthorisation>(new[] {user1, user2});
        }
    }
}
