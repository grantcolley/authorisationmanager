using System.ComponentModel;

namespace DevelopmentInProgress.AuthorisationManager.WPF.Model
{
    public abstract class EntityBase : INotifyPropertyChanged
    {
        private bool isVisible;

        protected EntityBase()
        {
            IsVisible = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual int Id { get; set; }

        public virtual string Text { get; set; }

        public virtual string Code { get; set; }

        public virtual string Description { get; set; }

        public bool IsReadOnly { get; set; }

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    OnPropertyChanged("IsVisible");
                }
            }
        }

        public bool CanModify
        {
            get { return !IsReadOnly; }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var propertyChangedHandler = PropertyChanged;
            if (propertyChangedHandler != null)
            {
                propertyChangedHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
