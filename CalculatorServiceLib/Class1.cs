using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorServiceLib
{
    [System.ServiceModel.ServiceBehavior(InstanceContextMode =System.ServiceModel.InstanceContextMode.PerCall)]
    public class CalculatorService:CalculatorServiceContractLib.ICalculatorService
    {

        public CalculatorService()
        {
            Console.WriteLine("Service Instantiated");
        }

        public int Add(int x,int y)
        {
            Console.WriteLine("Add Opertaion Invoked");
            return x + y;
        }
    }
}
