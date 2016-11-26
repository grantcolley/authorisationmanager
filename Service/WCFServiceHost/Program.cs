using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using DevelopmentInProgress.AuthorisationManager.Server;
using DevelopmentInProgress.AuthorisationManager.Service;

namespace DevelopmentInProgress.AuthorisationManager.WCFServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8733/Design_Time_Addresses/AuthorisationManager");
            Console.WriteLine("Created URI to server as base address: http://localhost:8733/Design_Time_Addresses/AuthorisationManager");
        
            ServiceHost selfHost = new ServiceHost(typeof (AuthorisationManagerServer), baseAddress);
            Console.WriteLine("Create the service host: AuthorisationManagerServer.");

            try
            {
                var unityBootstrapper = new UnityBootstrapper();
                unityBootstrapper.Run();

                selfHost.AddServiceEndpoint(typeof(IAuthorisationManagerService), new WSHttpBinding(), "AuthorisationManagerService");
                Console.WriteLine("Add the service endpoint: AuthorisationManagerService.");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior() {HttpGetEnabled = true};
                selfHost.Description.Behaviors.Add(smb);
                Console.WriteLine("Service metadata exchange behavior enabled.");

                selfHost.Description.Behaviors.Add(new UnityServiceBehavior(unityBootstrapper.Container));
                Console.WriteLine("Unity service behavior enabled.");

                selfHost.Open();
                Console.WriteLine("AuthorisationManager service is open.");
                Console.WriteLine("Press any key to close.");
                Console.ReadLine();

                selfHost.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error starting the AuthorisationManager service : " + ex.Message);
                selfHost.Abort();
                Console.ReadLine();
            }
        }
    }
}
