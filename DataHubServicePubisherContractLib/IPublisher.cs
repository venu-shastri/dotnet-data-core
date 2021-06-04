using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHubServicePubisherContractLib
{
    [System.ServiceModel.ServiceContract]
    public interface IPublisher
    {
        [System.ServiceModel.OperationContract]
        void Publish(string data);
    }
}
