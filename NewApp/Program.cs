using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestComponentLib.TestClassType obj = new TestComponentLib.TestClassType();
            string echo_message = obj.Echo("Post Tea Break");
            Console.WriteLine(echo_message);
        }
    }
}
