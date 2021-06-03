using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationProvierServiceContractLib
{
    [System.ServiceModel.ServiceContract]
    public interface IConfigurationProvierService
    {

        [System.ServiceModel.OperationContract]
         ConfigurationServiceDataContractsLib.ConfigurationData GetConfigurationDetails();
        
    }
}
