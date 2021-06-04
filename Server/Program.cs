using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wcf = System.ServiceModel;
using CalculatorServiceLib;
using System.ServiceModel.Description;

namespace Server
{
    class Program
    {
        static System.Threading.AutoResetEvent _handle = new System.Threading.AutoResetEvent(false); 
            
        static void Main(string[] args)
        {
            wcf.InstanceContext

            wcf.ServiceHost _cakculatorServiceTypecommunicationObject =
                new wcf.ServiceHost(typeof(CalculatorService));
            _cakculatorServiceTypecommunicationObject.Closed += _communicationObject_Closed;
            //foreach(ServiceEndpoint ep in _cakculatorServiceTypecommunicationObject.Description.Endpoints)
            //{
            //    ep.EndpointBehaviors.Add(new WCFExtensibilityLib.MessageInpectionEndpointBehavior());
            //}
            _cakculatorServiceTypecommunicationObject.Open();

            wcf.ServiceHost _configurationProviderServiceTypeCommunicationObject =
                new wcf.ServiceHost(typeof(ConfigurationProviderServiceLib.ConfigurationProvierService));
            _configurationProviderServiceTypeCommunicationObject.Open();

            Console.WriteLine("Server Started");
            _handle.WaitOne();
        }

        private static void _communicationObject_Closed(object sender, EventArgs e)
        {
            _handle.Set();
        }
    }
}
