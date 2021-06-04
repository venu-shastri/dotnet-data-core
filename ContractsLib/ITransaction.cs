using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractsLib
{
    [System.ServiceModel.ServiceContract(CallbackContract =typeof(ICallBack))]
    public interface ITransaction
    {
        [System.ServiceModel.OperationContract()]
        bool FundTransfer(string src, string dest, int amt);
    }
    public interface ICallBack
    {
        [System.ServiceModel.OperationContract]
        int GetOtp();
    }

}
