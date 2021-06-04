using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TransactionClient
{
    class TransactionProxyService :ClientBase<ContractsLib.ITransaction>, ContractsLib.ITransaction
    {

        public TransactionProxyService(InstanceContext callbackInstance,string endpointConfiguration) : base(callbackInstance, endpointConfiguration) { }
        public bool FundTransfer(string src, string dest, int amt)
        {
           return  base.Channel.FundTransfer(src, dest, amt);
                
        }
    }
    class TransactionCallbackService : ContractsLib.ICallBack
    {
        

        public int GetOtp()
        {
            Console.WriteLine("Enter OTP");
            int otp = Int32.Parse(Console.ReadLine());
            return otp;
        }
    }
    class Program
    {
        static System.Threading.AutoResetEvent _signal = new System.Threading.AutoResetEvent(false);

        static void Main(string[] args)
        {
            TransactionProxyService _proxy = new TransactionProxyService(new InstanceContext(new TransactionCallbackService()), "epAddress");
           bool status= _proxy.FundTransfer("sss", "ddd", 1000);
            Console.WriteLine(status);
            _signal.WaitOne();
        }
    }
}
