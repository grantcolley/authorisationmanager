using System.Collections.ObjectModel;

namespace DevelopmentInProgress.AuthorisationManager.WPF.Model
{
    public class ActivityNode : EntityBase
    {
        public ActivityNode()
        {
            Activities = new ObservableCollection<ActivityNode>();
        }

        public ObservableCollection<ActivityNode> Activities { get; set; }
    }
}
