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
                new CalculatorServiceProxy("lanclientcommunicationendpoint");
            Console.WriteLine("Proxy Instantiated");
            System.Threading.Thread.Sleep(5000);

            Random _random = new Random();
            while (true)
            {
                int result = _proxy.Add(_random.Next(1, 100), _random.Next(1, 100));
                Console.WriteLine(result);
                System.Threading.Thread.Sleep(2000);
            }
           
        }
    }
}
