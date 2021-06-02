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
            Binding _communcationChannel = new NetNamedPipeBinding();
            EndpointAddress _address = new EndpointAddress("net.pipe://localhost/calculatorservicepipe");
            CalculatorServiceProxy _service = new CalculatorServiceProxy(_communcationChannel,_address);
            int result=_service.Add(10,20);
            Console.WriteLine(result);
        }
    }
}
