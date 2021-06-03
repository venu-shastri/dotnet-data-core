using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationProviderIntegrationServiceContractLib
{
    [System.ServiceModel.ServiceContract]
    public interface IConfigurationProviderIntegrationService
    {
        [System.ServiceModel.OperationContract]
        [System.ServiceModel.Web.WebInvoke(UriTemplate="server/activehours",Method ="GET",ResponseFormat =System.ServiceModel.Web.WebMessageFormat.Json)]
        int GetActiveHours();

        [System.ServiceModel.OperationContract]
        [System.ServiceModel.Web.WebInvoke(UriTemplate = "server/name", Method = "GET", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        string GetServerName();
        
    }
}
