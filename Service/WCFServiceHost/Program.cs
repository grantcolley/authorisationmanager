using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using DevelopmentInProgress.AuthorisationManager.Server;
using DevelopmentInProgress.DipCore.Logger;

namespace DevelopmentInProgress.AuthorisationManager.WCFServiceHost
{
    class Program
    {
        private static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8733/Design_Time_Addresses/AuthorisationManager");
            ServiceHost selfHost = new ServiceHost(typeof (AuthorisationManagerServer), baseAddress);

            try
            {
                var unityBootstrapper = new UnityBootstrapper();
                unityBootstrapper.Run();

                IDipLog logger = (IDipLog)unityBootstrapper.Container.Resolve(typeof (IDipLog), "");

                var logBaseAddress = "Created URI to server as base address: " + baseAddress;
                Console.WriteLine(logBaseAddress);
                logger.Log(logBaseAddress, LogCategory.Info, LogPriority.None);

                selfHost.AddServiceEndpoint(typeof (IAuthorisationManagerServer), new WSHttpBinding(),
                    "AuthorisationManagerServer");
                Console.WriteLine("Add the service endpoint - Contract=IAuthorisationManagerServer; Address=AuthorisationManagerServer.");
                logger.Log("", LogCategory.Info, LogPriority.None);

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior() {HttpGetEnabled = true};
                selfHost.Description.Behaviors.Add(smb);
                Console.WriteLine("Service metadata exchange behavior enabled.");
                logger.Log("", LogCategory.Info, LogPriority.None);

                selfHost.Description.Behaviors.Add(new UnityServiceBehavior(unityBootstrapper.Container));
                Console.WriteLine("Unity service behavior enabled.");
                logger.Log("", LogCategory.Info, LogPriority.None);

                selfHost.Open();
                Console.WriteLine("AuthorisationManager service is open.");
                logger.Log("", LogCategory.Info, LogPriority.None);

                Console.WriteLine("Press any key to close.");
                Console.ReadLine();

                selfHost.Close();
            }
            catch (Exception ex)
            {
                selfHost.Abort();

                Console.WriteLine("Error starting the AuthorisationManager service : " + ex.Message);
                Console.ReadLine();
            }
        }
    }
}
