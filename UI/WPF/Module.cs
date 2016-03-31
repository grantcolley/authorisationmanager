using System;
using DevelopmentInProgress.AuthorisationManager.WPF.View;
using DevelopmentInProgress.AuthorisationManager.WPF.ViewModel;
using DevelopmentInProgress.Origin.Module;
using DevelopmentInProgress.Origin.Navigation;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Unity;

namespace DevelopmentInProgress.AuthorisationManager.WPF
{
    public class Module : ModuleBase
    {
        public Module(IUnityContainer container, ModuleNavigator moduleNavigator, ILoggerFacade logger)
            : base (container, moduleNavigator, logger)
        {            
        }

        public const string ModuleName = "Authorisation Manager";

        public override void Initialize()
        {
            Container.RegisterType<object, ConfigureAuthorisationView>(typeof (ConfigureAuthorisationView).Name);
            Container.RegisterType<ConfigurationAuthorisationViewModel>(typeof(ConfigurationAuthorisationViewModel).Name);

            var authorisationManager = new ModuleSettings()
            {
                ModuleName = ModuleName,
                ModuleImagePath = @"/DevelopmentInProgress.AuthorisationManager.WPF;component/Images/AuthorisationManager.png"
            };

            var authorisationGroup = new ModuleGroup()
            {
                ModuleGroupName = "Authorisation"
            };

            var configureAuthorisation = new ModuleGroupItem()
            {
                ModuleGroupItemName = "Configure Authorisation",
                TargetView = typeof (ConfigureAuthorisationView).Name,
                TargetViewTitle = "Configure Authorisation",
                ModuleGroupItemImagePath =
                    @"\DevelopmentInProgress.AuthorisationManager.WPF;component/Images/Users.png"
            };

            authorisationGroup.ModuleGroupItems.Add(configureAuthorisation);
            authorisationManager.ModuleGroups.Add(authorisationGroup);
            ModuleNavigator.AddModuleNavigation(authorisationManager);

            Logger.Log(String.Format("Initialize {0} Complete", ModuleName), Category.Info, Priority.None);
        }
    }
}
