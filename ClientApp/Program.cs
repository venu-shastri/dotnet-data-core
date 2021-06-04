using DataHubServiceSubscriberContractLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApp
{
    class SystemDataHubServerProxy : ClientBase<ISubScriber>, ISubScriber
    {
        public SystemDataHubServerProxy(string endpointName) : base(endpointName)
        {
        }
        public SystemDataHubServerProxy(InstanceContext callbackInstance, string endpointConfigurationName) : base(callbackInstance, endpointConfigurationName)
        {

        }

        public string Subscribe()
        {
            return Channel.Subscribe();
        }

        public bool UnSubscribe(string token)
        {
            return Channel.UnSubscribe(token);
        }
    }

    class CallBackService : DataHubServiceSubscriberContractLib.ICallBackContract
    {
        public void Update(string data)
        {
            Console.WriteLine($"Data From Server  {data}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CallBackService _callBackServiceInstance = new CallBackService();
            InstanceContext _callBackServiceInstanceContext = new InstanceContext(_callBackServiceInstance);
            var proxy = new SystemDataHubServerProxy( _callBackServiceInstanceContext,"tcpep");
            var token = proxy.Subscribe();
            Console.WriteLine($"Token Value {token}");
           /// Thread.Sleep(1000);
            //proxy.UnSubscribe(token);
            Console.Read();
        }
    }
}
