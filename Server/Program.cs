using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wcf = System.ServiceModel;
using CalculatorServiceLib;
namespace Server
{
    class Program
    {
        static System.Threading.AutoResetEvent _handle = new System.Threading.AutoResetEvent(false); 
            
        static void Main(string[] args)
        {

            wcf.ServiceHost _communicationObject = new wcf.ServiceHost(typeof(CalculatorService));
            _communicationObject.Closed += _communicationObject_Closed;
            //Add ServiceEndpoit
            //Contract :- Methods,Message Structure
            //Binding :- Communication Channel(transport,encoder,formatter,security.....)
            //Address : Network Address
            System.Type _contractType = typeof(CalculatorServiceContractLib.ICalculatorService);
            wcf.NetNamedPipeBinding _communicationChannel = new wcf.NetNamedPipeBinding();
            string address = "net.pipe://localhost/calculatorservicepipe";
            _communicationObject.AddServiceEndpoint(_contractType, _communicationChannel, address);

             _communicationObject.Open();
            Console.WriteLine("Server Started");
            _handle.WaitOne();
        }

        private static void _communicationObject_Closed(object sender, EventArgs e)
        {
            _handle.Set();
        }
    }
}
