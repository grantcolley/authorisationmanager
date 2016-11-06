using System;
using System.Collections.ObjectModel;
using System.Linq;
using DevelopmentInProgress.DipCore;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.WPF.Model
{
    [Serializable]
    public class ActivityNode : NodeEntityBase
    {
        public ActivityNode() : this(new Activity()){}

        public ActivityNode(Activity activity)
        {
            Activity = activity;

            Activities = new ObservableCollection<ActivityNode>();
        }

        public ObservableCollection<ActivityNode> Activities { get; set; }

        public Activity Activity { get; set; }

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

        public void AddActivity(ActivityNode activity)
        {
            if (!Activities.Any(a => a.Id.Equals(activity.Id)))
            {
                var clone = activity.DeepClone();
                clone.ParentType = ParentType.ActivityNode;
                clone.ParentId = Id;

                Activities.Add(clone);

                if (!Activity.Activities.Any(a => a.Id.Equals(activity.Id)))
                {
                    Activity.Activities.Add(clone.Activity);
                }
            }
        }

        public void RemoveActivity(int id)
        {
            var activity = Activity.Activities.FirstOrDefault(a => a.Id.Equals(id));
            if (activity != null)
            {
                Activity.Activities.Remove(activity);
            }

            var activityNode = Activities.FirstOrDefault(a => a.Id.Equals(id));
            if (activityNode != null)
            {
                Activities.Remove(activityNode);
            }
        }
    }
}
