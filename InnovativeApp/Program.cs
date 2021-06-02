using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflect = System.Reflection;

namespace InnovativeApp
{
    class Program
    {
        static void Main(string[] args)
        {
        
            Reflect.Assembly _testComponentLib_1_0_0_0 =
                Reflect.Assembly.LoadFile
                (@"E:\DataCore\TestComponentLib\bin\Debug\1.0.0.0\TestComponentLib.dll");

            Reflect.Assembly _testComponentLib_1_0_0_1 =
                Reflect.Assembly.Load
                ("TestComponentLib,verison=1.0.0.1,culture=neutral,publickeytoken=3801a1a06d1fd0b5");

            //Search for Types / Class 
           System.Type _testClassType= _testComponentLib_1_0_0_0.GetType("TestComponentLib.TestClassType");
            if (_testClassType.IsClass && _testClassType.IsPublic)
            {
                //Instantiate 
                object _instance = System.Activator.CreateInstance(_testClassType);
                //Search For Method
                Reflect.MethodInfo _echoMethodRef = _testClassType.GetMethod("Echo",
                    Reflect.BindingFlags.Public | Reflect.BindingFlags.Instance);

                //invoke 
                object result = _echoMethodRef.Invoke(_instance, new object[] { "Lunch Break" });
                Console.WriteLine(result);
            }
                
         }
    }
}
