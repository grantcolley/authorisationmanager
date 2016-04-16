using System.Collections.ObjectModel;
using System.Windows.Input;
using DevelopmentInProgress.AuthorisationManager.WPF.Model;
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

        private readonly AuthorisationManagerService serviceManager;

        public ConfigurationAuthorisationViewModel(ViewModelContext viewModelContext, AuthorisationManagerService serviceManager)
            : base(viewModelContext)
        {
            this.serviceManager = serviceManager;

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

            Activities = new ObservableCollection<ActivityNode>(serviceManager.GetActivityNodes());
            Roles = new ObservableCollection<RoleNode>(serviceManager.GetRoleNodes());
            Users = new ObservableCollection<UserNode>(serviceManager.GetUserNodes());
        }

        protected override ProcessAsyncResult SaveDocumentAsync()
        {
            return base.SaveDocumentAsync();
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
            if (param == null)
            {
                return;
            }

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
            if (param == null)
            {
                return;
            }

            var activityNode = param as ActivityNode;
            if (activityNode != null)
            {
                serviceManager.DeleteActivity(activityNode.Id);
                Activities.Remove(activityNode);
                SelectedItem = null;
                return;
            }

            var roleNode = param as RoleNode;
            if (roleNode != null)
            {
                serviceManager.DeleteRole(roleNode.Id);
                Roles.Remove(roleNode);
                SelectedItem = null;
                return;
            }

            var userNode = param as UserNode;
            if (userNode != null)
            {
                serviceManager.DeleteUserAuthorisation(userNode.Id);
                Users.Remove(userNode);
                SelectedItem = null;
            }
        }

        private void OnRemoveItem(object param)
        {

        }

        private void OnSelectItem(object param)
        {
            SelectedItem = param as EntityBase;
        }
        
        private void OnDragDrop(object param)
        {
            var dragDropArgs = param as FilterTreeDragDropArgs;
            if (dragDropArgs == null)
            {
                return;
            }

            var dragActivityNode = dragDropArgs.DragItem as ActivityNode;
            if (dragActivityNode != null)
            {
                var dropRoleNode = dragDropArgs.DropTarget as RoleNode;
                if (dropRoleNode != null)
                {
                    // drag activity onto a role

                    dropRoleNode.Activities.Add(dragActivityNode);
                    return;
                }

                var dropActivityNode = dragDropArgs.DropTarget as ActivityNode;
                if (dropActivityNode != null)
                {
                    // drag activity onto another activity

                    dropActivityNode.Activities.Add(dragActivityNode);
                    return;
                }

                var activityMsg = new Message()
                {
                    MessageType = MessageTypeEnum.Warn,
                    Text =
                        string.Format("Invalid drop target. Activity {0} can only be dropped on a role or another activity.",
                            dragActivityNode.Text)
                };

                ShowMessage(activityMsg, true);
                return;
            }

            var dragRoleNode = dragDropArgs.DragItem as RoleNode;
            if (dragRoleNode != null)
            {
                var dropUserNode = dragDropArgs.DropTarget as UserNode;
                if (dropUserNode != null)
                {
                    // drag role onto a user

                    dropUserNode.Roles.Add(dragRoleNode);
                    return;
                }

                var dropRoleNode = dragDropArgs.DropTarget as RoleNode;
                if (dropRoleNode != null)
                {
                    // drag role onto another role

                    dropRoleNode.Roles.Add(dragRoleNode);
                    return;
                }

                var roleMsg = new Message()
                {
                    MessageType = MessageTypeEnum.Warn,
                    Text =
                        string.Format("Invalid drop target. Role {0} can only be dropped on a user or another role.",
                            dragRoleNode.Text)
                };

                ShowMessage(roleMsg, true);
                return;
            }

            var msg = new Message()
            {
                MessageType = MessageTypeEnum.Warn,
                Text = "Invalid drag item."
            };

            ShowMessage(msg, true);
        }

        private void SaveActivity(ActivityNode activityNode)
        {
            var newActivity = activityNode.Id.Equals(0);

            var savedActivity = serviceManager.SaveActivity(activityNode);

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

            var savedRole = serviceManager.SaveRole(roleNode);

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

            var savedUser = serviceManager.SaveUser(userNode);

            if (savedUser != null)
            {
                if (newUser)
                {
                    Users.Add(userNode);
                }
            }
        }
    }
}
