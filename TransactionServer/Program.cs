using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TransactionServer
{

    [System.ServiceModel.ServiceBehavior(InstanceContextMode=InstanceContextMode.Single,IncludeExceptionDetailInFaults =true,ConcurrencyMode =ConcurrencyMode.Reentrant)]
    class TransactionService : ContractsLib.ITransaction
    {
        public bool FundTransfer(string src, string dest, int amt)
        {
            System.Random _random = new Random();
            int otp= _random.Next(1000, 2000);
            Console.WriteLine($"SMS OTP {otp}");
           int recievedOtp= OperationContext.Current.GetCallbackChannel<ContractsLib.ICallBack>().GetOtp();
            if (otp == recievedOtp)
            {
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
                new System.ServiceModel.ServiceHost(typeof(TransactionService));
            _host.AddServiceEndpoint(typeof(ContractsLib.ITransaction), new NetTcpBinding(), "net.tcp://localhost:12345/ep");
            _host.Open();
            Console.WriteLine("transaction Server Started");
            Console.ReadKey();
        }
    }
}
