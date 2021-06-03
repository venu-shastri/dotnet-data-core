using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationProviderServiceLib
{
    public class ConfigurationProvierService:ConfigurationProvierServiceContractLib.IConfigurationProvierService
    {


        public ConfigurationServiceDataContractsLib.ConfigurationData GetConfigurationDetails()
        {
            return new ConfigurationServiceDataContractsLib.ConfigurationData
            {
                ServerName = "ABC123",
                DownTime = 40,
                OperationalHours = 20
            };

        }
    }
}
