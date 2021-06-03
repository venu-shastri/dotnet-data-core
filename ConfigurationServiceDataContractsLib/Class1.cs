using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ConfigurationServiceDataContractsLib
{
    [DataContract]
    public class ConfigurationData
    {
        [DataMember]
        public string ServerName { get; set; }
        [DataMember(Name ="ActiveHours")]
        public int OperationalHours { get; set; }
        [IgnoreDataMember]
        public int DownTime { get; set; }
    }
}
