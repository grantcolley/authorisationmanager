using DevelopmentInProgress.AuthorisationManager.WPF.ViewModel;
using DevelopmentInProgress.Origin.Context;
using DevelopmentInProgress.Origin.View;

namespace DevelopmentInProgress.AuthorisationManager.WPF.View
{
    /// <summary>
    /// Interaction logic for ConfigureAuthorisationView.xaml
    /// </summary>
    public partial class ConfigureAuthorisationView : DocumentViewBase
    {
        public ConfigureAuthorisationView(IViewContext viewContext, ConfigurationAuthorisationViewModel configurationAuthorisationViewModel)
            : base (viewContext, configurationAuthorisationViewModel, Module.ModuleName)
        {
            InitializeComponent();

            DataContext = configurationAuthorisationViewModel;
        }
    }
}
