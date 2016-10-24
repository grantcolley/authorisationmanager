using System.Collections.ObjectModel;
using System.Linq;
using DevelopmentInProgress.DipCore;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.WPF.Model
{
    public class UserNode : NodeEntityBase
    {
        public UserNode(UserAuthorisation userAuthorisation)
        {
            UserAuthorisation = userAuthorisation;

            Roles = new ObservableCollection<RoleNode>();
        }

        public ObservableCollection<RoleNode> Roles { get; set; }

        public UserAuthorisation UserAuthorisation { get; private set; }

        public override int Id
        {
            get { return UserAuthorisation.Id; }
            set
            {
                UserAuthorisation.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public override string Text
        {
            get { return UserAuthorisation.UserName; }
            set
            {
                UserAuthorisation.UserName = value;
                OnPropertyChanged("Text");
            }
        }

        public override string Description
        {
            get { return UserAuthorisation.DisplayName; }
            set
            {
                UserAuthorisation.DisplayName = value;
                OnPropertyChanged("Description");
            }
        }

        public void AddRole(RoleNode role)
        {
            if (!Roles.Any(r => r.Id.Equals(role.Id)))
            {
                var clone = role.DeepClone();
                clone.Parent = this;
                Roles.Add(clone);

                if (!UserAuthorisation.Roles.Any(r => r.Id.Equals(role.Id)))
                {
                    UserAuthorisation.Roles.Add(clone.Role);
                }
            }
        }

        public void RemoveRole(int id)
        {
            var role = UserAuthorisation.Roles.FirstOrDefault(r => r.Id.Equals(id));
            if (role != null)
            {
                UserAuthorisation.Roles.Remove(role);
            }

            var roleNode = Roles.FirstOrDefault(r => r.Id.Equals(id));
            if (roleNode != null)
            {
                roleNode.Parent = null;
                Roles.Remove(roleNode);
            }
        }
    }
}
