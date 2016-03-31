using System.Collections.Generic;
using System.Windows.Input;
using DevelopmentInProgress.AuthorisationManager.WPF.Model;
using DevelopmentInProgress.Origin.Context;
using DevelopmentInProgress.Origin.ViewModel;
using DevelopmentInProgress.WPFControls.Command;

namespace DevelopmentInProgress.AuthorisationManager.WPF.ViewModel
{
    public class ConfigurationAuthorisationViewModel : DocumentViewModel
    {
        private AuthorisationManagerService serviceManager;

        public ConfigurationAuthorisationViewModel(ViewModelContext viewModelContext, AuthorisationManagerService serviceManager)
            : base(viewModelContext)
        {
            this.serviceManager = serviceManager;

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
            return base.OnPublishedAsync(data);
        }

        protected override void OnPublishedAsyncCompleted(ProcessAsyncResult processAsyncResult)
        {
            base.OnPublishedAsyncCompleted(processAsyncResult);

            Activities = serviceManager.GetActivityNodes();
            Roles = serviceManager.GetRoleNodes();
            Users = serviceManager.GetUserNodes();
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
