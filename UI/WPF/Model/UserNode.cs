using System.Collections.ObjectModel;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.WPF.Model
{
    public class UserNode : EntityBase
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
    }
}
