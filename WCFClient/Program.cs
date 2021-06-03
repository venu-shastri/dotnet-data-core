using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{

    class CalculatorServiceProxy : ClientBase<CalculatorServiceContractLib.ICalculatorService>, CalculatorServiceContractLib.ICalculatorService
    {
        
        public CalculatorServiceProxy(Binding binding, EndpointAddress remoteAddress):base(binding,remoteAddress)
        {

        }
        public CalculatorServiceProxy(string endpointConfigurationName) : base(endpointConfigurationName)
        {

        }
        public int Add(int x, int y)
        {
            //Endpoint
           return  base.Channel.Add(x, y); //Server Communication
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
              CalculatorServiceProxy _proxy =
                new CalculatorServiceProxy("onmachinecommunicationendpoint");


            int result= _proxy.Add(10,20);
            Console.WriteLine(result);
        }
    }
}
