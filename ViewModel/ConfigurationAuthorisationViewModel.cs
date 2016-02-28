using System.Collections.Generic;
using System.Windows.Input;
using DevelopmentInProgress.AuthorisationManager.Model;
using DevelopmentInProgress.Origin.Context;
using DevelopmentInProgress.Origin.ViewModel;
using DevelopmentInProgress.WPFControls.Command;

namespace DevelopmentInProgress.AuthorisationManager.ViewModel
{
    public class ConfigurationAuthorisationViewModel : DocumentViewModel
    {
        public ConfigurationAuthorisationViewModel(ViewModelContext viewModelContext)
            : base(viewModelContext)
        {
            NewUserCommand = new WpfCommand(OnNewUser);
            NewRoleCommand = new WpfCommand(OnNewRole);
            NewActivityCommand = new WpfCommand(OnNewActivity);
            SaveCommand = new WpfCommand(OnEntitySave);
            DeleteCommand = new WpfCommand(OnEntityDelete);
            AddItemCommand = new WpfCommand(OnAddItem);
            RemoveItemCommand = new WpfCommand(OnRemoveItem);
            SelectItemCommand = new WpfCommand(OnSelectItem);
            DragDropCommand = new WpfCommand(OnDragDrop);
        }

        public ICommand NewUserCommand { get; set; }

        public ICommand NewRoleCommand { get; set; }

        public ICommand NewActivityCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand AddItemCommand { get; set; }

        public ICommand RemoveItemCommand { get; set; }

        public ICommand SelectItemCommand { get; set; }

        public ICommand DragDropCommand { get; set; }

        public List<RoleNode> Roles { get; set; }

        public List<ActivityNode> Activities { get; set; }

        public List<UserNode> Users { get; set; }

        protected override ProcessAsyncResult OnPublishedAsync(object data)
        {
            var activity1 = new ActivityNode() { Text = "Read Only" };
            var activity2 = new ActivityNode() { Text = "Write" };

            var role1 = new RoleNode() { Text = "Reader" };
            role1.Activities.Add(activity2);
            role1.Activities.Add(activity1);

            var role2 = new RoleNode() { Text = "Writer" };
            role2.Activities.Add(activity1);
            role2.Activities.Add(activity2);

            var user1 = new UserNode() { Text = "Grant" };
            user1.Roles.Add(role1);

            var user2 = new UserNode() { Text = "Melanie" };
            user2.Roles.Add(role2);

            Users = new List<UserNode>();
            Users.AddRange(new[] { user1, user2 });
            //Roles = new List<RoleNode>(new[] { role1, role2 });
            //Activities = new List<ActivityNode>(new[] { activity1, activity2 });

            return base.OnPublishedAsync(data);
        }

        protected override void OnPublishedAsyncCompleted(ProcessAsyncResult processAsyncResult)
        {
            base.OnPublishedAsyncCompleted(processAsyncResult);
        }

        protected override ProcessAsyncResult SaveDocumentAsync()
        {
            return base.SaveDocumentAsync();
        }

        private void OnNewUser(object param)
        {
            
        }

        private void OnNewRole(object param)
        {

        }

        private void OnNewActivity(object param)
        {

        }

        private void OnEntitySave(object param)
        {

        }

        private void OnEntityDelete(object param)
        {

        }

        private void OnAddItem(object param)
        {

        }

        private void OnRemoveItem(object param)
        {

        }

        private void OnSelectItem(object param)
        {

        }
        
        private void OnDragDrop(object param)
        {

        }
    }
}
