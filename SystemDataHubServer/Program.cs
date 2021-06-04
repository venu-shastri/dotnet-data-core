using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SystemDataHubServer
{

    [System.ServiceModel.ServiceBehavior(InstanceContextMode =System.ServiceModel.InstanceContextMode.Single)]
    public class DataHubService:DataHubServicePubisherContractLib.IPublisher,
        DataHubServiceSubscriberContractLib.ISubScriber
    {
        public DataHubService()
        {
            Console.WriteLine("Service Instantiated");
        }
        Dictionary<string, DataHubServiceSubscriberContractLib.ICallBackContract> _subscribesTokens = 
            new Dictionary<string,DataHubServiceSubscriberContractLib.ICallBackContract>();
        public void Publish(string data) {
            Console.WriteLine($"Data From Agent :{data}");
            BroadCast(data);
        }

        private void BroadCast(string data)
        {
           foreach(var keypair in _subscribesTokens)
            {
                keypair.Value.Update(data);
            }
        }
        public string Subscribe() {
            string token= "Token :"+new Random().Next(1000, 2000);
            Console.WriteLine($"New Client Subscribed {token} ");
         DataHubServiceSubscriberContractLib.ICallBackContract _callbackInstanceProxy=
                OperationContext.Current.
                GetCallbackChannel<DataHubServiceSubscriberContractLib.ICallBackContract>();
            if (_callbackInstanceProxy != null)
            {

                _subscribesTokens.Add(token,_callbackInstanceProxy);
            }
            return token;
                }

        public bool UnSubscribe(string token) {

            if (_subscribesTokens.ContainsKey(token))
            {
                _subscribesTokens.Remove(token);
                return true;
            }
            return false;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            System.ServiceModel.ServiceHost _host = 
                new System.ServiceModel.ServiceHost(typeof(DataHubService));
            foreach(var endpoint in _host.Description.Endpoints)
            {
                endpoint.EndpointBehaviors.Add(new WCFExtensibilityLib.MessageInpectionEndpointBehavior());
            }
            _host.Open();
            Console.WriteLine("Hub Server Started");
            Console.ReadKey();
        }
    }
}
