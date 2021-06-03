using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationProviderIntegrationServiceLib
{
    public class ConfigurationProviderIntegrationService:ConfigurationProviderIntegrationServiceContractLib.IConfigurationProviderIntegrationService
    {
        public int GetActiveHours() {

            return new Random().Next(10, 100);
        
        }
        public string GetServerName() {

            return System.Environment.MachineName;
        }
    }
}
