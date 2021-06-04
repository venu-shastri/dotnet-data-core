using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHubServiceSubscriberContractLib
{

    [System.ServiceModel.ServiceContract]
    public interface ISubScriber
    {
        [System.ServiceModel.OperationContract]
        string Subscribe();
        

        [System.ServiceModel.OperationContract]
         bool UnSubscribe(string token);
        
    }
}
