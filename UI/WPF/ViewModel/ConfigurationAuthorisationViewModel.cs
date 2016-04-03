using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using DevelopmentInProgress.AuthorisationManager.WPF.Model;
using DevelopmentInProgress.DipSecure;
using DevelopmentInProgress.Origin.Context;
using DevelopmentInProgress.Origin.ViewModel;
using DevelopmentInProgress.WPFControls.Command;

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
                
                return;
            }

            var roleNode = param as RoleNode;
            if (roleNode != null)
            {

                return;
            }

            var userNode = param as UserNode;
            if (userNode != null)
            {
                
            }
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

        private void SaveActivity(ActivityNode activityNode)
        {
            var newActivity = activityNode.Id.Equals(0);

            var saved = serviceManager.TrySaveActivity(activityNode);

            if (saved)
            {
                if (newActivity)
                {
                    Activities.Add(activityNode);
                }
                else
                {
                    var updatedActivity = Activities.First(a => a.Id.Equals(activityNode.Id));
                    updatedActivity.Text = activityNode.Text;
                    updatedActivity.Code = activityNode.Code;
                    updatedActivity.Description = activityNode.Description;
                }
            }
        }

        private void SaveRole(RoleNode roleNode)
        {

        }

        private void SaveUser(UserNode userNode)
        {

        }
    }
}
