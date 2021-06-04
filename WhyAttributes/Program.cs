using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhyAttributes
{
    [AuditAttribute(DeveloperName ="Venu", TimeStamp ="12345566")]
    class Device
    {
      public string DeviceId { get; set; }
        public string DeviceName { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class AuditAttribute:System.Attribute
    {
        public string TimeStamp { get; set; }
        public string DeveloperName { get; set; }


    }
    class Program
    {
        static void Main(string[] args)
        {
            CodeAudtorTool _tool = new CodeAudtorTool();
            _tool.Display(typeof(Device));
        }
    }

    class CodeAudtorTool
    {

        public void Display(Type type)
        {
           var attributes= type.GetCustomAttributes(typeof(AuditAttribute), true);
            Console.WriteLine((attributes[0] as AuditAttribute).DeveloperName);

        }
    }
}
