using System.Collections.ObjectModel;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.WPF.Model
{
    public class ActivityNode : EntityBase
    {
        public ActivityNode(Activity activity)
        {
            Activity = activity;

            Activities = new ObservableCollection<ActivityNode>();
        }

        public ObservableCollection<ActivityNode> Activities { get; set; }

        public Activity Activity { get; private set; }

        public override int Id
        {
            get { return Activity.Id; }
            set
            {
                Activity.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public override string Text
        {
            get { return Activity.Name; }
            set
            {
                Activity.Name = value;
                OnPropertyChanged("Text");
            }
        }

        public override string Code
        {
            get { return Activity.ActivityCode; }
            set
            {
                Activity.ActivityCode = value;
                OnPropertyChanged("Code");
            }
        }

        public override string Description
        {
            get { return Activity.Description; }
            set
            {
                Activity.Description = value;
                OnPropertyChanged("Description");
            }
        }
    }
}
