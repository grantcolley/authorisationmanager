using System;
using System.Collections.ObjectModel;
using System.Linq;
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

            var authorisationNodes = authorisationManagerServiceManager.GetAuthorisationNodes();
            Activities = new ObservableCollection<ActivityNode>(authorisationNodes.ActivityNodes);
            Roles = new ObservableCollection<RoleNode>(authorisationNodes.RoleNodes);
            Users = new ObservableCollection<UserNode>(authorisationNodes.UserNodes);
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
            try
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
            catch (Exception ex)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Warn,
                    Text = ex.Message
                }, true);
            }
        }

        private void OnEntityDelete(object param)
        {
            try
            {
                var activityNode = param as ActivityNode;
                if (activityNode != null)
                {
                    DeleteActivity(activityNode);
                    return;
                }

                var roleNode = param as RoleNode;
                if (roleNode != null)
                {
                    DeleteRole(roleNode);
                    return;
                }

                var userNode = param as UserNode;
                if (userNode != null)
                {
                    DeleteUser(userNode);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Warn,
                    Text = ex.Message
                }, true);
            }
        }

        private void OnRemoveItem(object param)
        {
            try
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
                    return;
                }

                var userNode = param as UserNode;
                if (userNode != null)
                {
                    RemoveUser(userNode);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Warn,
                    Text = ex.Message
                }, true);
            }
        }

        private void OnDragDrop(object param)
        {
            try
            {
                var dragDropArgs = param as FilterTreeDragDropArgs;
                if (dragDropArgs == null
                    || dragDropArgs.DragItem == null)
                {
                    return;
                }

                var target = dragDropArgs.DropTarget as NodeEntityBase;
                if (target == null)
                {
                    return;
                }

                var message = string.Empty;

                if (dragDropArgs.DragItem is ActivityNode)
                {
                    var dragActivityNode = (ActivityNode) dragDropArgs.DragItem;
                    var targets =
                        Activities.Flatten<NodeEntityBase>(t => t.Id.Equals(target.Id) && t.Text.Equals(target.Text),
                            Roles, Users);
                    if (authorisationManagerServiceManager.TryAddActivity(dragActivityNode, targets, out message))
                    {
                        return;
                    }
                }
                else if (dragDropArgs.DragItem is RoleNode)
                {
                    var dragRoleNode = (RoleNode) dragDropArgs.DragItem;
                    var targets =
                        Roles.Flatten<NodeEntityBase>(t => t.Id.Equals(target.Id) && t.Text.Equals(target.Text),
                            Users);
                    if (authorisationManagerServiceManager.TryAddRole(dragRoleNode, targets, out message))
                    {
                        return;
                    }
                }
                else
                {
                    message = "Invalid drag item.";
                }

                if (!string.IsNullOrEmpty(message))
                {
                    ShowMessage(new Message()
                    {
                        MessageType = MessageTypeEnum.Warn,
                        Text = message
                    }, true);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Warn,
                    Text = ex.Message
                }, true);
            }
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
                }, true);
                return;
            }

            if (activityNode.Parent is ActivityNode)
            {
                var activities = Activities.Flatten<ActivityNode>(Roles, Users).ToList();
                authorisationManagerServiceManager.RemoveActivityFromActivity(activityNode, activities);
            }
            else if (activityNode.Parent is RoleNode)
            {
                var roles = Roles.Flatten<RoleNode>(Users).ToList();
                authorisationManagerServiceManager.RemoveActivityFromRole(activityNode, roles);                
            }
        }
        
        private void RemoveRole(RoleNode roleNode)
        {
            if (roleNode.Parent == null)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Info,
                    Text = string.Format("Can't remove role {0} as it has no parent.", roleNode.Text)
                }, true);
                return;
            }

            if (roleNode.Parent is RoleNode)
            {
                var roles = Roles.Flatten<RoleNode>(Users).ToList();
                authorisationManagerServiceManager.RemoveRoleFromRole(roleNode, roles);
            }
            else if (roleNode.Parent is UserNode)
            {
                var users = Users.Flatten<UserNode>().ToList();
                authorisationManagerServiceManager.RemoveRoleFromUser(roleNode, users);
            }
        }

        private void RemoveUser(UserNode userNode)
        {
            if (userNode.Parent == null)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Info,
                    Text = string.Format("Can't remove user {0} as the user has no parent.", userNode.Text)
                }, true);
            }
        }

        private void DeleteActivity(ActivityNode activityNode)
        {
            var aggregatedList = Activities.Merge(Roles, Users);
            authorisationManagerServiceManager.DeleteActivity(activityNode, aggregatedList);            
            SelectedItem = null;
        }

        private void DeleteRole(RoleNode roleNode)
        {
            var aggregatedList = Roles.Merge(Users);
            authorisationManagerServiceManager.DeleteRole(roleNode, aggregatedList);
            SelectedItem = null;
        }

        private void DeleteUser(UserNode userNode)
        {
            authorisationManagerServiceManager.DeleteUserAuthorisation(userNode, Users);
            SelectedItem = null;
        }
    }
}
