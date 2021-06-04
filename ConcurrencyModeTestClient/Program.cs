using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyModeTestClient
{
    class ConcurrencyModeServerProxy : ClientBase<ConcuurencyModeServerContractLib.IService>, ConcuurencyModeServerContractLib.IService
    {
        public ConcurrencyModeServerProxy(string configurationName) : base(configurationName) { }
        public string Echo(string msg)
        {
            return base.Channel.Echo(msg);
        }

        public void Submitt(string content)
        {
            base.Channel.Submitt(content);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrencyModeServerProxy _proxy = new ConcurrencyModeServerProxy("tcpep");
            System.Random _random = new Random();
            Console.WriteLine("Click To Begin");
           _proxy.Submitt( Console.ReadLine());

            //while (true)
            //{

            //    string msg = $"message +{_random.Next(10, 100)}";
            //    Console.WriteLine($"client Message {msg}");
            //   Console.WriteLine( _proxy.Echo(msg));
            //    System.Threading.Thread.Sleep(2000);
            //}

        }
    }
}
