using System.ComponentModel;

namespace DevelopmentInProgress.AuthorisationManager.WPF.Model
{
    public abstract class EntityBase : INotifyPropertyChanged
    {
        private string text;
        private bool isVisible;

        protected EntityBase()
        {
            IsVisible = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        public string Code { get; set; }

        public string Description { get; set; }

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

        public bool IsReadOnly { get; set; }

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
