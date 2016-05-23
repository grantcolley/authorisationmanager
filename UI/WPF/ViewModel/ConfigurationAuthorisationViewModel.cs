using System.Collections.ObjectModel;
using System.Windows.Input;
using DevelopmentInProgress.AuthorisationManager.WPF.Model;
using DevelopmentInProgress.DipCore;
using DevelopmentInProgress.DipSecure;
using DevelopmentInProgress.Origin.Context;
using DevelopmentInProgress.Origin.Messages;
using DevelopmentInProgress.Origin.ViewModel;
using DevelopmentInProgress.WPFControls.Command;
using DevelopmentInProgress.WPFControls.FilterTree;

namespace DevelopmentInProgress.AuthorisationManager.WPF.ViewModel
{
    public class ConfigurationAuthorisationViewModel : DocumentViewModel
    {
        private EntityBase selectedItem;

        private readonly AuthorisationManagerServiceManager authorisationManagerServiceManager;

        public ConfigurationAuthorisationViewModel(ViewModelContext viewModelContext, AuthorisationManagerServiceManager authorisationManagerServiceManager)
            : base(viewModelContext)
        {
            this.authorisationManagerServiceManager = authorisationManagerServiceManager;

            NewUserCommand = new WpfCommand(OnNewUser);
            NewRoleCommand = new WpfCommand(OnNewRole);
            NewActivityCommand = new WpfCommand(OnNewActivity);
            SaveCommand = new WpfCommand(OnEntitySave);
            DeleteCommand = new WpfCommand(OnEntityDelete);
            RemoveItemCommand = new WpfCommand(OnRemoveItem);
            SelectItemCommand = new WpfCommand(OnSelectItem);
            DragDropCommand = new WpfCommand(OnDragDrop);
        }

        public ICommand NewUserCommand { get; set; }

        public ICommand NewRoleCommand { get; set; }

        public ICommand NewActivityCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand RemoveItemCommand { get; set; }

        public ICommand SelectItemCommand { get; set; }

        public ICommand DragDropCommand { get; set; }

        public ObservableCollection<ActivityNode> Activities { get; set; }

        public ObservableCollection<RoleNode> Roles { get; set; }

        public ObservableCollection<UserNode> Users { get; set; }

        public EntityBase SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        protected override ProcessAsyncResult OnPublishedAsync(object data)
        {
            return base.OnPublishedAsync(data);
        }

        protected override void OnPublishedAsyncCompleted(ProcessAsyncResult processAsyncResult)
        {
            base.OnPublishedAsyncCompleted(processAsyncResult);

            Activities = new ObservableCollection<ActivityNode>(authorisationManagerServiceManager.GetActivityNodes());
            Roles = new ObservableCollection<RoleNode>(authorisationManagerServiceManager.GetRoleNodes());
            Users = new ObservableCollection<UserNode>(authorisationManagerServiceManager.GetUserNodes());
        }

        protected override ProcessAsyncResult SaveDocumentAsync()
        {
            return base.SaveDocumentAsync();
        }

        private void OnSelectItem(object param)
        {
            SelectedItem = param as EntityBase;
        }

        private void OnNewUser(object param)
        {
            SelectedItem = new UserNode(new UserAuthorisation());
        }

        private void OnNewRole(object param)
        {
            SelectedItem = new RoleNode(new Role());
        }

        private void OnNewActivity(object param)
        {
            SelectedItem = new ActivityNode(new Activity());
        }

        private void OnEntitySave(object param)
        {
            var activityNode = param as ActivityNode;
            if (activityNode != null)
            {
                SaveActivity(activityNode);
                return;
            }

            var roleNode = param as RoleNode;
            if (roleNode != null)
            {
                SaveRole(roleNode);
                return;
            }

            var userNode = param as UserNode;
            if (userNode != null)
            {
                SaveUser(userNode);
            }
        }

        private void OnEntityDelete(object param)
        {
            var activityNode = param as ActivityNode;
            if (activityNode != null)
            {
                authorisationManagerServiceManager.DeleteActivity(activityNode.Id);
                Activities.RemoveNested(activityNode, a => a.Id.Equals(activityNode.Id), Roles, Users);
                SelectedItem = null;
                return;
            }

            var roleNode = param as RoleNode;
            if (roleNode != null)
            {
                authorisationManagerServiceManager.DeleteRole(roleNode.Id);
                Roles.RemoveNested(roleNode, r => r.Id.Equals(roleNode.Id), Users);
                SelectedItem = null;
                return;
            }

            var userNode = param as UserNode;
            if (userNode != null)
            {
                authorisationManagerServiceManager.DeleteUserAuthorisation(userNode.Id);
                Users.Remove(userNode);
                SelectedItem = null;
            }
        }

        private void OnRemoveItem(object param)
        {
            var activityNode = param as ActivityNode;
            if (activityNode != null)
            {
                RemoveActivity(activityNode);
                return;
            }

            var roleNode = param as RoleNode;
            if (roleNode != null)
            {
                RemoveRole(roleNode);
            }

            var userNode = param as UserNode;
            if (userNode != null)
            {
                RemoveUser(userNode);
            }
        }
        
        private void OnDragDrop(object param)
        {
            var dragDropArgs = param as FilterTreeDragDropArgs;
            if (dragDropArgs == null
                || dragDropArgs.DragItem == null)
            {
                return;
            }

            var target = dragDropArgs.DropTarget as EntityBase;
            if (target == null)
            {
                return;
            }

            var message = string.Empty;

            var dragActivityNode = dragDropArgs.DragItem as ActivityNode;
            if (dragActivityNode != null)
            {
                var targets = Activities.Flatten<EntityBase>(t => t.Id.Equals(target.Id) && t.Text.Equals(target.Text), Roles);
                if (!authorisationManagerServiceManager.TryAddActivity(dragActivityNode, targets, out message))
                {
                    var activityMsg = new Message()
                    {
                        MessageType = MessageTypeEnum.Warn,
                        Text = message
                    };

                    ShowMessage(activityMsg, true);
                }

                return;
            }

            var dragRoleNode = dragDropArgs.DragItem as RoleNode;
            if (dragRoleNode != null)
            {
                var targets = Roles.Flatten<EntityBase>(t => t.Id.Equals(target.Id) && t.Text.Equals(target.Text), Users);
                if (!authorisationManagerServiceManager.TryAddRole(dragRoleNode, targets, out message))
                {
                    var roleMsg = new Message()
                    {
                        MessageType = MessageTypeEnum.Warn,
                        Text = message
                    };

                    ShowMessage(roleMsg, true);
                }

                return;
            }

            message = "Invalid drag item.";

            var msg = new Message()
            {
                MessageType = MessageTypeEnum.Warn,
                Text = message
            };

            ShowMessage(msg, true);
        }

        private void SaveActivity(ActivityNode activityNode)
        {
            var newActivity = activityNode.Id.Equals(0);

            var duplicateActivities = Activities.Flatten<ActivityNode>(a => a.Id.Equals(activityNode.Id), Roles, Users);

            var savedActivity = authorisationManagerServiceManager.SaveActivity(activityNode, duplicateActivities);

            if (savedActivity != null)
            {
                if (newActivity)
                {
                    Activities.Add(activityNode);
                }
            }
        }

        private void SaveRole(RoleNode roleNode)
        {
            var newRole = roleNode.Id.Equals(0);

            var duplicateRoles = Roles.Flatten<RoleNode>(r => r.Id.Equals(roleNode.Id), Users);

            var savedRole = authorisationManagerServiceManager.SaveRole(roleNode, duplicateRoles);

            if (savedRole != null)
            {
                if (newRole)
                {
                    Roles.Add(roleNode);
                }
            }
        }

        private void SaveUser(UserNode userNode)
        {
            var newUser = userNode.Id.Equals(0);

            var duplicateUsers = Users.Flatten<UserNode>(u => u.Id.Equals(0));

            var savedUser = authorisationManagerServiceManager.SaveUser(userNode, duplicateUsers);

            if (savedUser != null)
            {
                if (newUser)
                {
                    Users.Add(userNode);
                }
            }
        }

        private void RemoveActivity(ActivityNode activityNode)
        {
            if (activityNode.Parent == null)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Info,
                    Text = string.Format("Can't remove activity {0} as it has no parent.", activityNode.Text)
                });
                return;
            }

            authorisationManagerServiceManager.RemoveActivity(activityNode);
        }

        private void RemoveRole(RoleNode roleNode)
        {
            if (roleNode.Parent == null)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Info,
                    Text = string.Format("Can't remove role {0} as it has no parent.", roleNode.Text)
                });
                return;
            }

            authorisationManagerServiceManager.RemoveRole(roleNode);
        }

        private void RemoveUser(UserNode userNode)
        {
            if (userNode.Parent == null)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Info,
                    Text = string.Format("Can't remove user {0} as the user has no parent.", userNode.Text)
                });
            }
        }
    }
}
