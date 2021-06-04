using ConcuurencyModeServerContractLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyModeServer
{
  
    [System.ServiceModel.ServiceBehavior(
        InstanceContextMode = System.ServiceModel.InstanceContextMode.Single,
       ConcurrencyMode =System.ServiceModel.ConcurrencyMode.Multiple)]
    public class Service : IService
    {
        private string cache;
        public Service(){

            Console.WriteLine("Service Instantiated");
            }
        public string Echo(string msg)
        {
            Console.WriteLine($"Client Message {msg} ");
            this.cache = msg;
            System.Threading.Thread.Sleep(1000);
            string content = this.cache;
            return content.ToUpper();
        }
        public void Submitt(string content)
        {
            Console.WriteLine($"Content Recieved : {content}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            System.ServiceModel.ServiceHost _host = new System.ServiceModel.ServiceHost(typeof(Service));
            foreach(var endpoint in _host.Description.Endpoints)
            {
                endpoint.EndpointBehaviors.Add(new WCFExtensibilityLib.MessageInpectionEndpointBehavior());
            }
            _host.Open();
            Console.ReadKey();

        }
    }
}
