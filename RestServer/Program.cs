using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            System.ServiceModel.ServiceHost __communicationObject =
                new System.ServiceModel.ServiceHost(
                    typeof(ConfigurationProviderIntegrationServiceLib.ConfigurationProviderIntegrationService));
         //   //Rest Endpoint
         //System.ServiceModel.Description.ServiceEndpoint _restEndpoint=
         //       __communicationObject.AddServiceEndpoint(
         //       typeof(ConfigurationProviderIntegrationServiceContractLib.IConfigurationProviderIntegrationService),
         //       new System.ServiceModel.WebHttpBinding(),
         //       "http://localhost:9002/integration");
         //   //CustomBehaviors - Service,Endpoint,Operation
         //   //IServiceBehavior,IEndpointBehavior, IOperationBehavior

         //   System.ServiceModel.Description.WebHttpBehavior _restBehavior =
         //       new System.ServiceModel.Description.WebHttpBehavior();

         //   _restEndpoint.EndpointBehaviors.Add(_restBehavior);
            __communicationObject.Open();
            Console.WriteLine("Integration Service Started");
            Console.ReadKey();



        }
    }
}
