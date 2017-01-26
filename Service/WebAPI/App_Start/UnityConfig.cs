using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using DevelopmentInProgress.DipCore.Logger;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace DevelopmentInProgress.AuthorisationManager.WebAPI
{
    public static class UnityConfig
    {
        public static void Register(HttpConfiguration config)
        {
            IUnityContainer container = new UnityContainer();

            ConfigureContainer(container);

            container.RegisterType(typeof(IDipLog), typeof(LoggerFacade), new ContainerControlledLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);
        }

        private static void ConfigureContainer(IUnityContainer container)
        {
            var files = from f in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.RelativeSearchPath, "ServerConfiguration"))
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
                unityConfigSection.Configure(container);
            }
        }
    }
}