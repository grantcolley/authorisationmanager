using System.Windows;
using System.Windows.Controls;
using DevelopmentInProgress.AuthorisationManager.WPF.Model;

namespace DevelopmentInProgress.AuthorisationManager.WPF.View
{
    public class SelectedItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ActivityNodeTemplate { get; set; }

        public DataTemplate RoleNodeTemplate { get; set; }
        
        public DataTemplate UserNodeTemplate { get; set; }
        
        public DataTemplate SecurityActionTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null
                && item is EntityBase)
            {
                switch (((EntityBase)item).GetType().Name)
                {
                    case "ActivityNode":
                        return ActivityNodeTemplate;
                    case "RoleNode":
                        return RoleNodeTemplate;
                    case "UserNode":
                        return UserNodeTemplate;
                }
            }

            return null;
        }
    }
}
