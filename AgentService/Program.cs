using DataHubServicePubisherContractLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AgentService
{
    class SystemDataHubServerProxy : ClientBase<IPublisher>, IPublisher
    {
        public SystemDataHubServerProxy(string endpointName) : base(endpointName)
        {
        }

        public void Publish(string data)
        {
            Channel.Publish(data);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string agentName = $"Agent : {random.Next(1, 100)}";

            Console.WriteLine(agentName);

            var proxy = new SystemDataHubServerProxy("httpep");

            while (true)
            {
                var data = $"Data Update {random.Next(1, 100)} from {agentName}";
                proxy.Publish(data);
                Thread.Sleep(1000);
            }
        }
    }
}
