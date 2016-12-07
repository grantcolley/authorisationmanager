using System.Configuration;
using System.IO;
using System.Linq;
using DevelopmentInProgress.DipCore.Logger;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace DevelopmentInProgress.AuthorisationManager.WCFServiceHost
{
    public class UnityBootstrapper
    {
        public IUnityContainer Container { get; protected set; }

        public void Run()
        {
            ConfigureContainer();
        }

        private void ConfigureContainer()
        {
            Container = new UnityContainer();

            var files = from f in Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "ServerConfiguration"))
                        where f.ToUpper().EndsWith("UNITY.CONFIG")
                        select f;
            foreach (string fileName in files)
            {
                var unityMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = fileName
                };

                var unityConfig = ConfigurationManager.OpenMappedExeConfiguration(unityMap, ConfigurationUserLevel.None);
                var unityConfigSection = (UnityConfigurationSection)unityConfig.GetSection("unity");
                unityConfigSection.Configure(Container);
            }

            Container.RegisterType(typeof (IDipLog), typeof (LoggerFacade));
        }
    }
}
