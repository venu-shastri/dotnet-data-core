using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ConcuurencyModeServerContractLib
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract()]
        string Echo(string msg);
        [OperationContract(IsOneWay =true)]
        void Submitt(string content);
    }
}
