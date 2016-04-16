using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Data;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.WPF.Model
{
    public class RoleNode : EntityBase
    {
        public RoleNode(Role role)
        {
            Role = role;

            Roles = new ObservableCollection<RoleNode>();
            Activities= new ObservableCollection<ActivityNode>();
        }

        public ObservableCollection<RoleNode> Roles { get; set; }

        public ObservableCollection<ActivityNode> Activities { get; set; }

        public IList Items
        {
            get
            {
                return new CompositeCollection()
                {
                    new CollectionContainer() {Collection = Activities},
                    new CollectionContainer() {Collection = Roles}
                };
            }
        }

        public Role Role { get; private set; }

        public override int Id
        {
            get { return Role.Id; }
            set
            {
                Role.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public override string Text
        {
            get { return Role.Name; }
            set
            {
                Role.Name = value;
                OnPropertyChanged("Text");
            }
        }

        public override string Code
        {
            get { return Role.RoleCode; }
            set
            {
                Role.RoleCode = value;
                OnPropertyChanged("Code");
            }
        }

        public override string Description
        {
            get { return Role.Description; }
            set
            {
                Role.Description = value;
                OnPropertyChanged("Description");
            }
        }
    }
}
