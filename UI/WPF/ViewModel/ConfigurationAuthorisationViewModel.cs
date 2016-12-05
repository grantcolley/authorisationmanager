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

        protected async override void OnPublished(object data)
        {
            IsBusy = true;

            var authorisationNodes = await authorisationManagerServiceManager.GetAuthorisationNodes();

            Activities = new ObservableCollection<ActivityNode>(authorisationNodes.ActivityNodes);
            Roles = new ObservableCollection<RoleNode>(authorisationNodes.RoleNodes);
            Users = new ObservableCollection<UserNode>(authorisationNodes.UserNodes);

            ResetStatus();
            base.OnPropertyChanged("");
        }

        protected async override void SaveDocument()
        {
            OnEntitySave(SelectedItem);
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
                return;
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

            var target = dragDropArgs.DropTarget as NodeEntityBase;
            if (target == null)
            {
                return;
            }

            if (dragDropArgs.DragItem is ActivityNode)
            {
                AddActivity((ActivityNode) dragDropArgs.DragItem, target);
            }
            else if (dragDropArgs.DragItem is RoleNode)
            {
                AddRole((RoleNode) dragDropArgs.DragItem, target);
            }
            else
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Warn,
                    Text = "Invalid drag item."
                }, true);
            }
        }

        private async void SaveActivity(ActivityNode activityNode)
        {
            try
            {
                IsBusy = true;

                var newActivity = activityNode.Id.Equals(0);

                var duplicateActivities = Activities.Flatten<ActivityNode>(a => a.Id.Equals(activityNode.Id), Roles,
                    Users);

                var savedActivity =
                    await authorisationManagerServiceManager.SaveActivity(activityNode, duplicateActivities);

                if (savedActivity != null)
                {
                    if (newActivity)
                    {
                        Activities.Add(activityNode);
                    }
                }

                ResetStatus();
            }
            catch (Exception ex)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Warn,
                    Text = ex.Message
                }, true);

                IsBusy = false;
            }
            finally
            {
                OnPropertyChanged("");   
            }
        }

        private async void SaveRole(RoleNode roleNode)
        {
            try
            {
                IsBusy = true;

                var newRole = roleNode.Id.Equals(0);

                var duplicateRoles = Roles.Flatten<RoleNode>(r => r.Id.Equals(roleNode.Id), Users);

                var savedRole = await authorisationManagerServiceManager.SaveRole(roleNode, duplicateRoles);

                if (savedRole != null)
                {
                    if (newRole)
                    {
                        Roles.Add(roleNode);
                    }
                }

                ResetStatus();
            }
            catch (Exception ex)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Warn,
                    Text = ex.Message
                }, true);

                IsBusy = false;
            }
            finally
            {
                OnPropertyChanged("");
            }
        }

        private async void SaveUser(UserNode userNode)
        {
            try
            {
                IsBusy = true;

                var newUser = userNode.Id.Equals(0);

                var duplicateUsers = Users.Flatten<UserNode>(u => u.Id.Equals(0));

                var savedUser = await authorisationManagerServiceManager.SaveUser(userNode, duplicateUsers);

                if (savedUser != null)
                {
                    if (newUser)
                    {
                        Users.Add(userNode);
                    }
                }

                ResetStatus();
            }
            catch (Exception ex)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Warn,
                    Text = ex.Message
                }, true);

                IsBusy = false;
            }
            finally
            {
                OnPropertyChanged("");
            }
        }

        private async void AddActivity(ActivityNode activityNode, NodeEntityBase target)
        {
            try
            {
                IsBusy = true;

                if (AuthorisationManagerServiceManager.TargetNodeIsDropCandidate(target, activityNode))
                {
                    return;
                }

                if (target is ActivityNode)
                {
                    var targets = Activities.Flatten<ActivityNode>(t => t.Id.Equals(target.Id), Roles, Users);
                    var result = await authorisationManagerServiceManager.AddActivity(activityNode, (ActivityNode) target, targets);
                }
                else if (target is RoleNode)
                {
                    var targets = Roles.Flatten<RoleNode>(t => t.Id.Equals(target.Id), Users);
                    var result = await authorisationManagerServiceManager.AddActivity(activityNode, (RoleNode)target, targets);
                }
                else
                {
                    throw new Exception(
                        string.Format(
                            "Invalid drop target. '{0}' can only be dropped onto a role or another activity.",
                            activityNode.Text));
                }

                ResetStatus();
            }
            catch (Exception ex)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Warn,
                    Text = ex.Message
                }, true);

                IsBusy = false;
            }
            finally
            {                
                OnPropertyChanged("");
            }
        }

        private async void AddRole(RoleNode roleNode, NodeEntityBase target)
        {
            try
            {
                IsBusy = true;

                if (AuthorisationManagerServiceManager.TargetNodeIsDropCandidate(target, roleNode))
                {
                    return;
                }

                if (target is RoleNode)
                {
                    var targets = Roles.Flatten<RoleNode>(t => t.Id.Equals(target.Id), Users);
                    var result = await authorisationManagerServiceManager.AddRole(roleNode, (RoleNode) target, targets);
                }
                else if (target is UserNode)
                {
                    var targets = Users.Where(t => t.Id.Equals(target.Id));
                    var result = await authorisationManagerServiceManager.AddRole(roleNode, (UserNode) target, targets);
                }
                else
                {
                    throw new Exception(
                        string.Format(
                            "Invalid drop target. '{0}' can only be dropped onto a user or another role.",
                            roleNode.Text));
                }

                ResetStatus();
            }
            catch (Exception ex)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Warn,
                    Text = ex.Message
                }, true);

                IsBusy = false;
            }
            finally
            {
                OnPropertyChanged("");
            }
        }

        private async void RemoveActivity(ActivityNode activityNode)
        {
            if (activityNode.ParentType == ParentType.None)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Info,
                    Text = string.Format("Can't remove activity {0} as it has no parent.", activityNode.Text)
                }, true);
                return;
            }

            try
            {
                IsBusy = true;

                if (activityNode.ParentType == ParentType.ActivityNode)
                {
                    var activities = Activities.Flatten<ActivityNode>(Roles, Users).ToList();
                    var result =
                        await authorisationManagerServiceManager.RemoveActivityFromActivity(activityNode, activities);
                }
                else if (activityNode.ParentType == ParentType.RoleNode)
                {
                    var roles = Roles.Flatten<RoleNode>(Users).ToList();
                    var result = await authorisationManagerServiceManager.RemoveActivityFromRole(activityNode, roles);
                }

                ResetStatus();
            }
            catch (Exception ex)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Warn,
                    Text = ex.Message
                }, true);

                IsBusy = false;
            }
            finally
            {
                OnPropertyChanged("");
            }
        }

        private async void RemoveRole(RoleNode roleNode)
        {
            if (roleNode.ParentType == ParentType.None)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Info,
                    Text = string.Format("Can't remove role {0} as it has no parent.", roleNode.Text)
                }, true);
                return;
            }

            try
            {
                IsBusy = true;

                if (roleNode.ParentType == ParentType.RoleNode)
                {
                    var roles = Roles.Flatten<RoleNode>(Users).ToList();
                    var result = await authorisationManagerServiceManager.RemoveRoleFromRole(roleNode, roles);
                }
                else if (roleNode.ParentType == ParentType.UserNode)
                {
                    var users = Users.Flatten<UserNode>().ToList();
                    var result = await authorisationManagerServiceManager.RemoveRoleFromUser(roleNode, users);
                }

                ResetStatus();
            }
            catch (Exception ex)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Warn,
                    Text = ex.Message
                }, true);

                IsBusy = false;
            }
            finally
            {
                OnPropertyChanged("");
            }
        }

        private async void RemoveUser(UserNode userNode)
        {
            if (userNode.ParentType == ParentType.None)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Info,
                    Text = string.Format("Can't remove user {0} as the user has no parent.", userNode.Text)
                }, true);
            }
        }

        private async void DeleteActivity(ActivityNode activityNode)
        {
            try
            {
                IsBusy = true;
                var aggregatedList = Activities.Merge(Roles, Users);
                var result = await authorisationManagerServiceManager.DeleteActivity(activityNode, aggregatedList);
                SelectedItem = null;
                ResetStatus();
            }
            catch (Exception ex)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Warn,
                    Text = ex.Message
                }, true);

                IsBusy = false;
            }
            finally
            {
                OnPropertyChanged("");
            }
        }

        private async void DeleteRole(RoleNode roleNode)
        {
            try
            {
                IsBusy = true;
                var aggregatedList = Roles.Merge(Users);
                var result = await authorisationManagerServiceManager.DeleteRole(roleNode, aggregatedList);
                SelectedItem = null;
                ResetStatus();
            }
            catch (Exception ex)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Warn,
                    Text = ex.Message
                }, true);

                IsBusy = false;
            }
            finally
            {
                OnPropertyChanged("");
            }
        }

        private async void DeleteUser(UserNode userNode)
        {
            try
            {
                IsBusy = true;
                var result = await authorisationManagerServiceManager.DeleteUserAuthorisation(userNode, Users);
                SelectedItem = null;
                ResetStatus();
            }
            catch (Exception ex)
            {
                ShowMessage(new Message()
                {
                    MessageType = MessageTypeEnum.Warn,
                    Text = ex.Message
                }, true);

                IsBusy = false;
            }
            finally
            {
                OnPropertyChanged("");
            }
        }
    }
}
