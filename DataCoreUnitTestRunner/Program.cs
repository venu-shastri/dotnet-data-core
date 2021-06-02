using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCoreUnitTestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            string testcodeLibPath = args[1];
            //Reflection
          System.Reflection.Assembly _testCodeAssembly=
                System.Reflection.Assembly.LoadFile(testcodeLibPath);
            //Get All Classes 
           System.Type[] types= _testCodeAssembly.GetTypes();
            foreach(Type type in types)
            {
                if (type.IsClass)
                {
                   Object[] attributes=
                        type.GetCustomAttributes(typeof(DataCoueUnitTestLib.TestFixtureAttribute), true);
                    if (attributes.Length > 0)
                    {
                       System.Reflection.MethodInfo[] methods=
                            type.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                        foreach(System.Reflection.MethodInfo method in methods)
                        {
                           object[] testAttributes= method.GetCustomAttributes(typeof(DataCoueUnitTestLib.TestAttribute), true);
                            if(testAttributes.Length>0)
                            {

                            }
                        }
                    }
                }
            }

            //Filter - [TestFixtureAttribute]
            

        }
    }
}
