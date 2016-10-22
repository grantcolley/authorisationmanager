using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.WPF.Model
{
    public class RoleNode : NodeEntityBase
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

        public void RemoveActivity(int id)
        {
            var activity = Role.Activities.FirstOrDefault(a => a.Id.Equals(id));
            if (activity != null)
            {
                Role.Activities.Remove(activity);
            }

            var activityNode = Activities.FirstOrDefault(a => a.Id.Equals(id));
            if (activityNode != null)
            {
                activityNode.Parent = null;
                Activities.Remove(activityNode);
            }
        }

        public void RemoveRole(int id)
        {
            var role = Role.Roles.FirstOrDefault(r => r.Id.Equals(id));
            if (role != null)
            {
                role.Roles.Remove(role);
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
